using CarShop.General.Services;
using CarShop.UserInterface.General;

namespace CarShop.UserInterface.ViewModels;

public interface IMenuViewModel
{
    #region Properties and Indexers
    RelayCommand? OpenCarTableCommand { get; }
    RelayCommand? OpenClientTableCommand { get; }
    #endregion
}

public class MenuViewModel : ObservableObject, IMenuViewModel
{
    #region Fields
    private readonly ICarTableViewModel _carTableViewModel;
    private readonly IClientTableViewModel _clientTableViewModel;
    private readonly IDialogService _dialogService;
    #endregion

    #region Properties and Indexers
    public RelayCommand? OpenCarTableCommand { get; private set; }
    public RelayCommand? OpenClientTableCommand { get; private set; }
    #endregion

    #region Constructors
    public MenuViewModel(IDialogService dialogService, ICarTableViewModel carTableViewModel,
        IClientTableViewModel clientTableViewModel)
    {
        _dialogService = dialogService;
        _carTableViewModel = carTableViewModel;
        _clientTableViewModel = clientTableViewModel;
        InitializeCommands();
    }
    #endregion

    #region Private members
    private void InitializeCommands()
    {
        OpenCarTableCommand = new RelayCommand(OpenCarTable);
        OpenClientTableCommand = new RelayCommand(OpenClientTable);
    }

    private void OpenCarTable(object obj)
    {
        _dialogService.ShowDialog(_carTableViewModel);
    }

    private void OpenClientTable(object obj)
    {
        _dialogService.ShowDialog(_clientTableViewModel);
    }
    #endregion
}
