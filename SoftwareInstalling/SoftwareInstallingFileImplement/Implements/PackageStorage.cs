using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.Interfaces;
using SoftwareInstallingBuisnessLogic.ViewModels;
using SoftwareInstallingFileImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallingFileImplement.Implements
{
    public class PackageStorage : IPackageStorage
    {
        private readonly FileDataListSingleton source;

        public PackageStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<PackageViewModel> GetFullList()
        {
            return source.Products.Select(CreateModel).ToList();
        }

        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Products.Where(rec => rec.ProductName.Contains(model.PackageName))
                .Select(CreateModel).ToList();
        }

        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var product = source.Products
                .FirstOrDefault(rec => rec.ProductName == model.PackageName || rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }

        public void Insert(PackageBindingModel model)
        {
            int maxId = source.Products.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Package
            {
                Id = maxId + 1,
                ProductComponents = new Dictionary<int, int>()
            };
            source.Products.Add(CreateModel(model, element));
        }

        public void Update(PackageBindingModel model)
        {
            var element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }

        public void Delete(PackageBindingModel model)
        {
            Package element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private Package CreateModel(PackageBindingModel model, Package product)
        {
            product.ProductName = model.PackageName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.PackageComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.PackageComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] =
                    model.PackageComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key,
                    model.PackageComponents[component.Key].Item2);
                }
            }
            return product;
        }

        private PackageViewModel CreateModel(Package product)
        {
            return new PackageViewModel
            {
                Id = product.Id,
                PackageName = product.ProductName,
                Price = product.Price,
                PackageComponents = product.ProductComponents
                    .ToDictionary(recPC => recPC.Key, recPC =>
                    (source.Components.FirstOrDefault(recC => recC.Id ==
                    recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
