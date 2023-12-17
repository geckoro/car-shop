using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface ICarService : IBaseService<CarDTO>
{
}

public class CarService : BaseService<CarDTO>, ICarService
{
    #region Constructors
    public CarService(ICarRepository carRepository, IMapper mapper) : base(carRepository, mapper)
    {
    }
    #endregion
}
