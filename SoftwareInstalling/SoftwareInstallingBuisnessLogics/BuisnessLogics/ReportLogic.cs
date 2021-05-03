using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.HelperModels;
using SoftwareInstallingBuisnessLogic.Interfaces;
using SoftwareInstallingBuisnessLogic.ViewModels;
using SoftwareInstallingBuisnessLogic.Enums;

namespace SoftwareInstallingBuisnessLogic.BuisnessLogics
{
    public class ReportLogic
    {
        private readonly IPackageStorage _packageStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IWarehouseStorage _warehouseStorage;

        public ReportLogic(IPackageStorage packageStorage, IOrderStorage orderStorage, IWarehouseStorage warehouseStorage)
        {
            _packageStorage = packageStorage;
            _orderStorage = orderStorage;
            _warehouseStorage = warehouseStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportComponentPackageViewModel> GetComponentPackage()
        {
            var packages = _packageStorage.GetFullList();
            var list = new List<ReportComponentPackageViewModel>();
            foreach (var package in packages)
            {
                var record = new ReportComponentPackageViewModel
                {
                    PackageName = package.PackageName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in package.PackageComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких складах они хранятся
        /// </summary>
        /// <returns></returns>
        public List<ReportComponentWarehouseViewModel> GetComponentWarehouse()
        {
            var warehouses = _warehouseStorage.GetFullList();
            var list = new List<ReportComponentWarehouseViewModel>();
            foreach (var warehouse in warehouses)
            {
                var record = new ReportComponentWarehouseViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PackageName = x.PackageName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            })
            .ToList();
        }/// <summary>
         /// Получение списка заказов сгруппированных по дате
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrdersGroupByDate()
        {
            return _orderStorage.GetFullList().GroupBy(x => x.DateCreate.Date)
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.Key,
                Count = x.Count(),
                Sum = x.Sum(rec => rec.Sum),
            }).ToList();
        }
        /// <summary>
        /// Сохранение изделия в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SavePackagesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Packages = _packageStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentPackageToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                ComponentPackages = GetComponentPackage()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentWarehouseToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                ComponentWarehouses = GetComponentWarehouse()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocWarehouse(new WordInfoWarehouse
            {
                FileName = model.FileName,
                Title = "Таблица складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }
        public void SaveAllOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocAllOrders(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersGroupByDate()
            });
        }
    }
}
