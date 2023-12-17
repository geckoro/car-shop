using CarShop.BusinessLogic.Services;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Services;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface IClientTableViewModel
    {
    }

    public class ClientTableViewModel : TableViewModel<ClientDTO>, IClientTableViewModel
    {
        #region Constructors
        static ClientTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(ClientTableViewModel), typeof(ClientTableWindow));
        }

        public ClientTableViewModel(ClientService clientService) : base(clientService)
        {
        }
        #endregion
    }
}
