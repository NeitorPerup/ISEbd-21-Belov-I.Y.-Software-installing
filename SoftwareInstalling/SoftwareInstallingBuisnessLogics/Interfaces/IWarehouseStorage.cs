using System;
using System.Collections.Generic;
using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.ViewModels;
using System.Text;

namespace SoftwareInstallingBuisnessLogic.Interfaces
{
    public interface IWarehouseStorage
    {
        List<WarehouseViewModel> GetFullList();

        List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model);

        WarehouseViewModel GetElement(WarehouseBindingModel model);

        void Insert(WarehouseBindingModel model);

        void Update(WarehouseBindingModel model);

        void Delete(WarehouseBindingModel model);

        bool Unrestocking(int Count, int PackageId);
    }
}
