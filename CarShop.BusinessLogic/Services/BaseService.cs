using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.General.Interfaces;

namespace CarShop.BusinessLogic.Services;

public interface IBaseService<out T> where T : class, IIdentifiable
{
    #region Public members
    IEnumerable<T> Get();
    Task RemoveAsync(Guid id);
    Task SaveChangesAsync();
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

    public async Task RemoveAsync(Guid id)
    {
        await _baseRepository.RemoveAsync(id);
    }

    public async Task SaveChangesAsync()
    {
        await _baseRepository.SaveChangesAsync();
    }
    #endregion

    #region Protected members
    protected async Task CreateAsync(IIdentifiable identifiable)
    {
        await _baseRepository.CreateAsync(identifiable);
    }
    #endregion
}
