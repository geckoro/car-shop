using System.Windows;

namespace CarShop.UserInterface.Views;

public partial class AlertWindow : Window
{
    #region Constructors
    public AlertWindow()
    {
        InitializeComponent();
    }
    #endregion

    #region Private members
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
    #endregion
}
