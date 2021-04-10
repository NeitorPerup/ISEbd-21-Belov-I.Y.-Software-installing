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
        private readonly IComponentStorage _componentStorage;

        private readonly IPackageStorage _packageStorage;

        private readonly IOrderStorage _orderStorage;

        public ReportLogic(IPackageStorage packageStorage, IComponentStorage
        componentStorage, IOrderStorage orderStorage)
        {
            _packageStorage = packageStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
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
                    if (package.PackageComponents.ContainsKey(component.Key))
                    {
                        record.Components.Add(new Tuple<string, int>(component.Value.Item1,
                        package.PackageComponents[component.Key].Item2));
                        record.TotalCount += package.PackageComponents[component.Key].Item2;
                    }
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
    }
}
