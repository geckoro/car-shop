using CarShop.General;
using CarShop.UserInterface.General;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels
{
    public interface IClientTableViewModel
    {
    }

    public class ClientTableViewModel : ObservableObject, IClientTableViewModel
    {
        #region Constructors
        static ClientTableViewModel()
        {
            DialogService.TryRegisterWindow(typeof(ClientTableViewModel), typeof(ClientTableWindow));
        }
        #endregion
    }
}
