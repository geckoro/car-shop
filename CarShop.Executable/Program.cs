using System.Windows;
using CarShop.Loaders;
using CarShop.UserInterface.ViewModels;
using CarShop.UserInterface.Views;
using Ninject;

namespace CarShop.Executable;

public abstract class Program
{
    #region Private members
    private static IKernel CreateAndInitializeKernel()
    {
        var result = new StandardKernel();
        // Load the module with the bindings for all services
        result.Load(new CarShopModule());
        return result;
    }

    [STAThread]
    private static void Main()
    {
        // The kernel will create the instances for every service that will be need
        var kernel = CreateAndInitializeKernel();
        var window = kernel.Get<MenuWindow>();
        window.DataContext = kernel.Get<IMenuViewModel>();

        var application = new Application();
        application.Run(window);
    }
    #endregion
}
