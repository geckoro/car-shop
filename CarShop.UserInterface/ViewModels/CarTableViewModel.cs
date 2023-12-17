using CarShop.BusinessLogic.Services;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Services;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface ICarTableViewModelFactory
    {
        #region Public members
        ICarTableViewModel Create();
        #endregion
    }

    public interface ICarTableViewModel
    {
    }

    public class CarTableViewModel : TableViewModel<CarDTO>, ICarTableViewModel
    {
        #region Fields
        private readonly ICarService _carService;
        #endregion

        #region Constructors
        static CarTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(CarTableViewModel), typeof(CarTableWindow));
        }

        public CarTableViewModel(ICarService carService, IDialogService dialogService,
            IAlertViewModelFactory alertViewModelFactory, IEntityViewModelFactory entityViewModelFactory) : base(
            "List of cars", carService, dialogService, alertViewModelFactory, entityViewModelFactory)
        {
            _carService = carService;
            AddedItem += OnAddedItem;
            UpdatedItem += OnUpdatedItem;
        }
        #endregion

        #region Private members
        private void OnAddedItem(object obj)
        {
            if (obj is not IEntityViewModel entityViewModel) return;
            var car = CarDTO.CreateFromListOfPropertyNameAndValue(entityViewModel.PropertyNamesAndValues);
            _carService.Create(car);
            Items.Add(car);
        }

        private void OnUpdatedItem(object obj)
        {
            if (obj is not IEntityViewModel entityViewModel) return;
            var car = CarDTO.CreateFromListOfPropertyNameAndValue(entityViewModel.PropertyNamesAndValues);
            _carService.Update(car);
            SelectedItem = car;
        }
        #endregion
    }
}
