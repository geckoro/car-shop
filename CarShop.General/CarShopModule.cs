using CarShop.BusinessLogic.Services;
using CarShop.Data.Repositories;
using CarShop.UserInterface.ViewModels;
using Ninject.Modules;

namespace CarShop.General;

public class CarShopModule : NinjectModule
{
    #region Public members
    public override void Load()
    {
        // Data layer
        Bind<ICarRepository>().To<CarRepository>();
        Bind<IClientRepository>().To<ClientRepository>();

        // Business logic layer
        Bind<ICarService>().To<CarService>();
        Bind<IClientService>().To<ClientService>();

        // User interface layer
        Bind<ICarTableViewModel>().To<CarTableViewModel>();
        Bind<IClientTableViewModel>().To<ClientTableViewModel>();
        Bind<IMenuViewModel>().To<MenuViewModel>();
    }
    #endregion
}
