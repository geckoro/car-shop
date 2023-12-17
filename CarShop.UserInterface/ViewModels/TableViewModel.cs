using System;
using System.Collections.ObjectModel;
using CarShop.BusinessLogic.Services;
using CarShop.General.Interfaces;
using CarShop.UserInterface.General;

namespace CarShop.UserInterface.ViewModels;

/// <summary>
///     Used as XAML proxy.
/// </summary>
public interface ITableViewModel : ITableViewModel<object>
{
}

public interface ITableViewModel<T>
{
    #region Properties and Indexers
    RelayCommand? DeleteCommand { get; }
    ObservableCollection<T> Items { get; }
    RelayCommand? SaveCommand { get; }
    T? SelectedItem { get; set; }
    string Title { get; }
    #endregion
}

public abstract class TableViewModel<T> : ObservableObject, ITableViewModel<T> where T : class, IIdentifiable
{
    #region Properties and Indexers
    public RelayCommand? DeleteCommand { get; private set; }
    public ObservableCollection<T> Items { get; }
    public RelayCommand? SaveCommand { get; private set; }
    public T? SelectedItem { get; set; }
    public string Title { get; }
    #endregion

    #region Constructors
    protected TableViewModel(IBaseService<T> baseService)
    {
        Title = "List of clients";
        Items = new ObservableCollection<T>(baseService.Get());
        InitializeCommands();
    }
    #endregion

    #region Private members
    private bool CanDelete(object obj)
    {
        return SelectedItem != null;
    }

    private bool CanSave(object obj)
    {
        throw new NotImplementedException();
    }

    private void Delete(object obj)
    {
        throw new NotImplementedException();
    }

    private void InitializeCommands()
    {
        DeleteCommand = new RelayCommand(Delete, CanDelete);
        SaveCommand = new RelayCommand(Save, CanSave);
    }

    private void Save(object obj)
    {
        throw new NotImplementedException();
    }
    #endregion
}
