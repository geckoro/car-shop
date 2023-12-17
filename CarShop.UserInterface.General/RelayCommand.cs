using System.Windows.Input;

public class RelayCommand : RelayCommand<object>
{
    #region Constructors
    public RelayCommand(Action<object>? execute, Predicate<object>? canExecute = null) : base(execute, canExecute)
    {
    }
    #endregion

    #region Public members
    public void Execute()
    {
        base.Execute(null);
    }
    #endregion
}

public class RelayCommand<T> : ICommand
{
    #region Fields
    private readonly Predicate<T>? _canExecute;
    private readonly Action<T>? _execute;
    #endregion

    #region Constructors
    public RelayCommand(Action<T>? execute, Predicate<T>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    #endregion

    #region ICommand Members
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute((T)parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public void Execute(object? parameter)
    {
        _execute?.Invoke((T)parameter);
    }
    #endregion
}
