using System;
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
    #region Properties and Indexers
    public RelayCommand? OpenCarTableCommand { get; private set; }
    public RelayCommand? OpenClientTableCommand { get; private set; }
    #endregion

    #region Constructors
    public MenuViewModel()
    {
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
        throw new NotImplementedException();
    }

    private void OpenClientTable(object obj)
    {
        throw new NotImplementedException();
    }
    #endregion
}
