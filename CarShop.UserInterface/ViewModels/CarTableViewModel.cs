using CarShop.General;
using CarShop.UserInterface.General;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface ICarTableViewModel
    {
    }

    public class CarTableViewModel : ObservableObject, ICarTableViewModel
    {
        #region Constructors
        static CarTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(CarTableViewModel), typeof(CarTableWindow));
        }
        #endregion
    }
}
