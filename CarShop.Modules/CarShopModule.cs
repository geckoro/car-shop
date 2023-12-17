using AutoMapper;
using CarShop.BusinessLogic.Services;
using CarShop.Data.Contexts;
using CarShop.Data.Repositories;
using CarShop.DataTransfer;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Services;
using CarShop.UserInterface.ViewModels;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace CarShop.Loaders;

public class CarShopModule : NinjectModule
{
    #region Public members
    public override void Load()
    {
        // Data layer
        Bind<ICarRepository>().To<CarRepository>();
        Bind<IClientRepository>().To<ClientRepository>();

        // Business logic layer
        Bind<ICarService, IBaseService<CarDTO>>().To<CarService>();
        Bind<IClientService, IBaseService<ClientDTO>>().To<ClientService>();

        // User interface layer
        Bind<IAlertViewModel>().To<AlertViewModel>();
        Bind<IAlertViewModelFactory>().ToFactory();
        Bind<ICarTableViewModel>().To<CarTableViewModel>();
        Bind<ICarTableViewModelFactory>().ToFactory();
        Bind<IClientTableViewModel>().To<ClientTableViewModel>();
        Bind<IClientTableViewModelFactory>().ToFactory();
        Bind<IEntityViewModel>().To<EntityViewModel>();
        Bind<IEntityViewModelFactory>().ToFactory();
        Bind<IMenuViewModel>().To<MenuViewModel>();

        // AutoMapper
        Bind<IMapper>().ToMethod(ctx =>
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DataTransferObjectProfile>();
            });
            return mapConfig.CreateMapper();
        }).InSingletonScope();

        // Others
        Bind<CarShopDbContext>().ToConstant(new CarShopDbContext());
        Bind<IDialogService>().ToConstant(DialogService.Instance);
    }
    #endregion
}
