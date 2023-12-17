using CarShop.BusinessLogic.Services;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Services;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface ICarTableViewModel
    {
    }

    public class CarTableViewModel : TableViewModel<CarDTO>, ICarTableViewModel
    {
        #region Constructors
        static CarTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(CarTableViewModel), typeof(CarTableWindow));
        }

        public CarTableViewModel(CarService carService) : base(carService)
        {
        }
        #endregion
    }
}
