using CarShop.General.Services;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels;

public interface IAlertViewModelFactory
{
    #region Public members
    IAlertViewModel Create(string message);
    #endregion
}

public interface IAlertViewModel
{
    #region Properties and Indexers
    string Message { get; }
    #endregion
}

public class AlertViewModel : IAlertViewModel
{
    #region Properties and Indexers
    public string Message { get; }
    #endregion

    #region Constructors
    static AlertViewModel()
    {
        DialogService.TryRegisterWindow(typeof(AlertViewModel), typeof(AlertWindow));
    }

    public AlertViewModel(string message)
    {
        Message = message;
    }
    #endregion
}
