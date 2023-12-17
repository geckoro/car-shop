using System.Collections.ObjectModel;

namespace CarShop.UserInterface.ViewModels.Interfaces;

/// <summary>
///     Used as XAML proxy.
/// </summary>
public interface ITableViewModel : ITableViewModel<object>
{
}

public interface ITableViewModel<T>
{
    #region Properties and Indexers
    public ObservableCollection<T> Items { get; set; }
    public string Title { get; set; }
    #endregion
}
