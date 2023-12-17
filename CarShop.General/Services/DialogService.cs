using System.Windows;

namespace CarShop.General.Services;

public interface IDialogService
{
    #region Public members
    bool ShowDialog(object content);
    #endregion
}

public class DialogService : IDialogService
{
    #region Static Fields and Constants
    private static DialogService? _instance;
    #endregion

    #region Properties and Indexers
    public static DialogService Instance => _instance ??= new DialogService();
    private Dictionary<Type, Type> RegisteredWindows { get; } = new();
    #endregion

    #region Constructors
    private DialogService()
    {
    }
    #endregion

    #region Interface Implementations
    public bool ShowDialog(object content)
    {
        if (!RegisteredWindows.TryGetValue(content.GetType(), out var value)) return false;
        if (Activator.CreateInstance(value) is not Window window) return false;
        window.DataContext = content;
        try
        {
            window.ShowDialog();
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
    #endregion

    #region Public members
    public static bool TryRegisterWindow(Type viewModelType, Type windowType)
    {
        return Instance.RegisteredWindows.TryAdd(viewModelType, windowType);
    }
    #endregion
}
