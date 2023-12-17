using System;
using System.Collections.ObjectModel;
using CarShop.BusinessLogic.Services;
using CarShop.Data.Contexts;
using CarShop.General.Interfaces;
using CarShop.General.Services;
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
    RelayCommand? CreateCommand { get; }
    ObservableCollection<T> Items { get; }
    RelayCommand? RemoveCommand { get; }
    RelayCommand? SaveCommand { get; }
    T? SelectedItem { get; set; }
    string Title { get; }
    RelayCommand? UpdateCommand { get; }
    bool WereChangesMade { get; }
    #endregion
}

public abstract class TableViewModel<T> : ObservableObject, ITableViewModel<T> where T : class, IIdentifiable
{
    #region Fields
    private readonly IAlertViewModelFactory _alertViewModelFactory;
    private readonly IDialogService _dialogService;
    private readonly IEntityViewModelFactory _entityViewModelFactory;
    private readonly IBaseService<T> _baseService;
    private ObservableCollection<T> _items;
    private T? _selectedItem;
    private bool _wereChangesMade;
    #endregion

    #region Properties and Indexers
    public RelayCommand? CreateCommand { get; private set; }

    public ObservableCollection<T> Items
    {
        get => _items;
        private set
        {
            _items = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand? RemoveCommand { get; private set; }
    public RelayCommand? SaveCommand { get; private set; }

    public T? SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    public string Title { get; }
    public RelayCommand? UpdateCommand { get; private set; }

    public bool WereChangesMade
    {
        get => _wereChangesMade;
        private set
        {
            _wereChangesMade = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Events
    protected event Action<object> AddedItem;
    protected event Action<object> UpdatedItem;
    #endregion

    #region Constructors
    protected TableViewModel(string title, IBaseService<T> baseService, IDialogService dialogService,
        IAlertViewModelFactory alertViewModelFactory,
        IEntityViewModelFactory entityViewModelFactory)
    {
        _baseService = baseService;
        _dialogService = dialogService;
        _alertViewModelFactory = alertViewModelFactory;
        _entityViewModelFactory = entityViewModelFactory;
        Title = title;
        Items = new ObservableCollection<T>(_baseService.Get());
        InitializeCommands();
        WereChangesMade = false;
    }
    #endregion

    #region Private members
    private bool CanCreate(object obj)
    {
        return SelectedItem == null;
    }

    private bool CanRemove(object obj)
    {
        return SelectedItem != null;
    }

    private bool CanSave(object obj)
    {
        return WereChangesMade;
    }

    private bool CanUpdate(object obj)
    {
        return SelectedItem != null;
    }

    private void Create(object obj)
    {
        var entityViewModel = _entityViewModelFactory.Create(typeof(T));
        if (!_dialogService.ShowDialog(entityViewModel)) return;
        AddedItem.Invoke(entityViewModel);
        WereChangesMade = true;
    }

    private void InitializeCommands()
    {
        CreateCommand = new RelayCommand(Create, CanCreate);
        RemoveCommand = new RelayCommand(Remove, CanRemove);
        SaveCommand = new RelayCommand(Save, CanSave);
        UpdateCommand = new RelayCommand(Update, CanUpdate);
    }

    private void Remove(object obj)
    {
        if (SelectedItem == null)
            throw new InvalidOperationException(
                "Something went wrong, the command mustn't execute when there is no selection.");
        _baseService.Remove(SelectedItem!.Id);
        Items.Remove(SelectedItem);
        WereChangesMade = true;
    }

    private void Save(object obj)
    {
        _baseService.SaveChanges();
        _dialogService.ShowDialog(_alertViewModelFactory.Create("Saved the changes to the database."));
        WereChangesMade = false;
        CarShopDbContextProvider.CreateNew();
        Items = new ObservableCollection<T>(_baseService.Get());
    }

    private void Update(object obj)
    {
        if (SelectedItem == null)
            throw new InvalidOperationException(
                "Something went wrong, the command mustn't execute when there is no selection.");
        var entityViewModel = _entityViewModelFactory.Create(typeof(T), SelectedItem);
        if (!_dialogService.ShowDialog(entityViewModel)) return;
        UpdatedItem.Invoke(entityViewModel);
        WereChangesMade = true;
    }
    #endregion
}
