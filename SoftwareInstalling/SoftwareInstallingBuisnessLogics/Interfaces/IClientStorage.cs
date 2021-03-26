using SoftwareInstallingBuisnessLogic.BindingModels;
using SoftwareInstallingBuisnessLogic.ViewModels;
using System.Collections.Generic;

namespace SoftwareInstallingBuisnessLogic.Interfaces
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();

        List<ClientViewModel> GetFilteredList(ClientBindingModel model);

        ClientViewModel GetElement(ClientBindingModel model);

        void Insert(ClientBindingModel model);

        void Update(ClientBindingModel model);

        void Delete(ClientBindingModel model);
    }
}
