using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface ICarService
{
    #region Public members
    IEnumerable<CarDTO> Get();
    IEnumerable<CarDTO> Get(Guid id);
    #endregion
}

public class CarService : ICarService
{
    #region Fields
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public CarService(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }
    #endregion

    #region Interface Implementations
    public IEnumerable<CarDTO> Get()
    {
        return _mapper.Map<IEnumerable<CarDTO>>(_carRepository.Get());
    }

    public IEnumerable<CarDTO> Get(Guid id)
    {
        return _mapper.Map<IEnumerable<CarDTO>>(_carRepository.Get(id));
    }
    #endregion
}
