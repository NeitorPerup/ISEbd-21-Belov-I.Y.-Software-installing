using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.Enums;
using SoftwareInstallingBuisnessLogic.Interfaces;
using SoftwareInstallingBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;


namespace SoftwareInstallingBuisnessLogic.BuisnessLogics
{
    public class PackageLogic
    {
        private readonly IPackageStorage _packageStorage;
        public PackageLogic(IPackageStorage componentStorage)
        {
            _packageStorage = componentStorage;
        }

        public List<PackageViewModel> Read(PackageBindingModel model)
        {
            if (model == null)
            {
                return _packageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PackageViewModel> { _packageStorage.GetElement(model) };
            }
            return _packageStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(PackageBindingModel model)
        {
            var element = _packageStorage.GetElement(new PackageBindingModel
            {
               ProductName = model.ProductName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _packageStorage.Update(model);
            }
            else
            {
                _packageStorage.Insert(model);
            }
        }
        public void Delete(PackageBindingModel model)
        {
            var element = _packageStorage.GetElement(new PackageBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _packageStorage.Delete(model);
        }
    }
}
