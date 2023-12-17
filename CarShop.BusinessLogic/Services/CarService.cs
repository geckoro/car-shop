using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface ICarService : IBaseService<CarDTO>
{
    #region Public members
    void Create(CarDTO car);
    #endregion
}

public class CarService : BaseService<CarDTO>, ICarService
{
    #region Constructors
    public CarService(ICarRepository carRepository, IMapper mapper) : base(carRepository, mapper)
    {
    }
    #endregion

    #region Interface Implementations
    public void Create(CarDTO car)
    {
        base.Create(car);
    }
    #endregion
}
