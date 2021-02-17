using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.Interfaces;
using SoftwareInstallingBuisnessLogic.ViewModels;
using SoftwareInstallingListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallingListImplements.Implements
{
    public class PackageStorage : IPackageStorage
    {
        private readonly DataListSingleton source;
        public PackageStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PackageViewModel> GetFullList()
        {
            List<PackageViewModel> result = new List<PackageViewModel>();
            foreach (var component in source.Packages)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<PackageViewModel> result = new List<PackageViewModel>();
            foreach (var package in source.Packages)
            {
                if (package.PackageName.Contains(model.PackageName))
                {
                    result.Add(CreateModel(package));
                }
            }
            return result;
        }
        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var package in source.Packages)
            {
                if (package.Id == model.Id || package.PackageName ==
                model.PackageName)
                {
                    return CreateModel(package);
                }
            }
            return null;
        }

        public void Insert(PackageBindingModel model)
        {
            Package tempPackage = new Package
            {
                Id = 1,
                PackageComponents = new
            Dictionary<int, int>()
            };
            foreach (var package in source.Packages)
            {
                if (package.Id >= tempPackage.Id)
                {
                    tempPackage.Id = package.Id + 1;
                }
            }
            source.Packages.Add(CreateModel(model, tempPackage));
        }
        public void Update(PackageBindingModel model)
        {
            Package tempPackage = null;
            foreach (var package in source.Packages)
            {
                if (package.Id == model.Id)
                {
                    tempPackage = package;
                }
            }
            if (tempPackage == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempPackage);
        }
        public void Delete(PackageBindingModel model)
        {
            for (int i = 0; i < source.Packages.Count; ++i)
            {
                if (source.Packages[i].Id == model.Id)
                {
                    source.Packages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Package CreateModel(PackageBindingModel model, Package package)
        {
            package.PackageName = model.PackageName;
            package.Price = model.Price;
            // удаляем убранные
            foreach (var key in package.PackageComponents.Keys.ToList())
            {
                if (!model.PackageComponents.ContainsKey(key))
                {
                    package.PackageComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.PackageComponents)
            {
                if (package.PackageComponents.ContainsKey(component.Key))
                {
                    package.PackageComponents[component.Key] =
                    model.PackageComponents[component.Key].Item2;
                }
                else
                {
                    package.PackageComponents.Add(component.Key,
                    model.PackageComponents[component.Key].Item2);
                }
            }
            return package;
        }
        private PackageViewModel CreateModel(Package package)
        {
            // требуется дополнительно получить список компонентов для изделия с
            //названиями и их количество
            Dictionary<int, (string, int)> packageComponents = new
            Dictionary<int, (string, int)>();
            foreach (var pc in package.PackageComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                packageComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new PackageViewModel
            {
                Id = package.Id,
                PackageName = package.PackageName,
                Price = package.Price,
                PackageComponents = packageComponents
            };

        }
    }
}
