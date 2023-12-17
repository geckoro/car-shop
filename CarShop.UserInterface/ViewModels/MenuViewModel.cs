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
    private readonly ICarTableViewModelFactory _carTableViewModelFactory;
    private readonly IClientTableViewModelFactory _clientTableViewModelFactory;
    private readonly IDialogService _dialogService;
    #endregion

    #region Properties and Indexers
    public RelayCommand? OpenCarTableCommand { get; private set; }
    public RelayCommand? OpenClientTableCommand { get; private set; }
    #endregion

    #region Constructors
    public MenuViewModel(IDialogService dialogService, ICarTableViewModelFactory carTableViewModelFactory,
        IClientTableViewModelFactory clientTableViewModelFactory)
    {
        _dialogService = dialogService;
        _carTableViewModelFactory = carTableViewModelFactory;
        _clientTableViewModelFactory = clientTableViewModelFactory;
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
        _dialogService.ShowDialog(_carTableViewModelFactory.Create());
    }

    private void OpenClientTable(object obj)
    {
        _dialogService.ShowDialog(_clientTableViewModelFactory.Create());
    }
    #endregion
}
