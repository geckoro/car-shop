using CarShop.BusinessLogic.Services;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Services;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface IClientTableViewModelFactory
    {
        #region Public members
        IClientTableViewModel Create();
        #endregion
    }

    public interface IClientTableViewModel
    {
    }

    public class ClientTableViewModel : TableViewModel<ClientDTO>, IClientTableViewModel
    {
        #region Fields
        private readonly IClientService _clientService;
        #endregion

        #region Constructors
        static ClientTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(ClientTableViewModel), typeof(ClientTableWindow));
        }

        public ClientTableViewModel(IClientService clientService, IDialogService dialogService,
            IAlertViewModelFactory alertViewModelFactory, IEntityViewModelFactory entityViewModelFactory) : base(
            "List of clients", clientService, dialogService,
            alertViewModelFactory, entityViewModelFactory)
        {
            _clientService = clientService;
            AddedItem += OnAddedItem;
            UpdatedItem += OnUpdatedItem;
        }
        #endregion

        #region Private members
        private void OnAddedItem(object obj)
        {
            if (obj is not IEntityViewModel entityViewModel) return;
            var client = ClientDTO.CreateFromListOfPropertyNameAndValue(entityViewModel.PropertyNamesAndValues);
            _clientService.Create(client);
            Items.Add(client);
        }

        private void OnUpdatedItem(object obj)
        {
            if (obj is not IEntityViewModel entityViewModel) return;
            var client = ClientDTO.CreateFromListOfPropertyNameAndValue(entityViewModel.PropertyNamesAndValues);
            _clientService.Update(client);
            SelectedItem = client;
        }
        #endregion
    }
}
