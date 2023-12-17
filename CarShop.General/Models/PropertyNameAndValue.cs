using CarShop.UserInterface.General;

namespace CarShop.General.Models;

public class PropertyNameAndValue : ObservableObject
{
    #region Fields
    private object? _value;
    #endregion

    #region Properties and Indexers
    public string Name { get; set; }
    public Type Type { get; set; }

    public object? Value
    {
        get => _value;
        set
        {
            if (value == _value)
                return;
            _value = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Constructors
    public PropertyNameAndValue(string name, object? value, Type type)
    {
        Type = type;
        Name = name;
        Value = value;
    }
    #endregion
}
