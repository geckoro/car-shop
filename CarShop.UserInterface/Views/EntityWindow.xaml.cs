using System.Windows;

namespace CarShop.UserInterface.Views;

public partial class EntityWindow : Window
{
    #region Constructors
    public EntityWindow()
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
