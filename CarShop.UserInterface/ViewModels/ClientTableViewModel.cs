using System.Collections.ObjectModel;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General;
using CarShop.UserInterface.General;
using CarShop.UserInterface.ViewModels.Interfaces;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface IClientTableViewModel
    {
    }

    public class ClientTableViewModel : ObservableObject, IClientTableViewModel, ITableViewModel<ClientDTO>
    {
        #region Properties and Indexers
        public ObservableCollection<ClientDTO> Items { get; set; }
        public string Title { get; set; }
        #endregion

        #region Constructors
        static ClientTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(ClientTableViewModel), typeof(ClientTableWindow));
        }

        public ClientTableViewModel()
        {
            Title = "List of clients";
        }
        #endregion
    }
}
