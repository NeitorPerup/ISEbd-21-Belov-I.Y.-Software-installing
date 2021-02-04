using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallingBuisnessLogic.Interfaces
{
    public interface IPackageStorage
    {
        List<PackageViewModel> GetFullList();

        List<PackageViewModel> GetFilteredList(PackageBindingModel model);
        
        PackageViewModel GetElement(PackageBindingModel model);
        
        void Insert(PackageBindingModel model);
       
        void Update(PackageBindingModel model);
        
        void Delete(PackageBindingModel model);
    }
}
