using System.Windows;
using System.Windows.Controls;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Models;

namespace CarShop.UserInterface;

public class EntityDataTemplateSelector : DataTemplateSelector
{
    #region Properties and Indexers
    public DataTemplate ComboBoxTemplate { get; set; }
    public DataTemplate TextTemplate { get; set; }
    #endregion

    #region Private members
    private DataTemplate SelectTemplate(PropertyNameAndValue propertyNameAndValue)
    {
        if (propertyNameAndValue.Type == typeof(ClientDTO)) return ComboBoxTemplate;
        return TextTemplate;
    }
    #endregion

    #region Public members
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        return SelectTemplate(item as PropertyNameAndValue);
    }
    #endregion
}
