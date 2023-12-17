using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.General.Interfaces;

namespace CarShop.BusinessLogic.Services;

public interface IBaseService<out T> where T : class, IIdentifiable
{
    #region Public members
    IEnumerable<T> Get();
    void Remove(Guid id);
    void SaveChanges();
    #endregion
}

public abstract class BaseService<T> : IBaseService<T> where T : class, IIdentifiable
{
    #region Fields
    private readonly IBaseRepository<IIdentifiable> _baseRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    protected BaseService(IBaseRepository<IIdentifiable> baseRepository, IMapper mapper)
    {
        _baseRepository = baseRepository;
        _mapper = mapper;
    }
    #endregion

    #region Interface Implementations
    public IEnumerable<T> Get()
    {
        return _mapper.Map<IEnumerable<T>>(_baseRepository.Get());
    }

    public void Remove(Guid id)
    {
        _baseRepository.Remove(id);
    }

    public void SaveChanges()
    {
        _baseRepository.SaveChanges();
    }
    #endregion

    #region Protected members
    protected void Create(IIdentifiable identifiable)
    {
        _baseRepository.Create(identifiable);
    }
    #endregion
}
