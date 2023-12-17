using AutoMapper;
using CarShop.Data.Contexts;
using CarShop.General.Interfaces;

namespace CarShop.Data.Repositories;

public interface IBaseRepository<out T> where T : class, IIdentifiable
{
    #region Public members
    void Create(IIdentifiable identifiable);
    IQueryable<T> Get();
    void Remove(Guid id);
    void SaveChanges();
    #endregion
}

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IIdentifiable
{
    #region Fields
    private readonly CarShopDbContext _carShopDbContext;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    protected BaseRepository(CarShopDbContext carShopDbContext, IMapper mapper)
    {
        _carShopDbContext = carShopDbContext;
        _mapper = mapper;
    }
    #endregion

    #region Interface Implementations
    public void Create(IIdentifiable identifiable)
    {
        var entity = _mapper.Map<T>(identifiable);
        _carShopDbContext.Add((object)entity);
    }

    public IQueryable<T> Get()
    {
        return _carShopDbContext.Set<T>();
    }

    public void Remove(Guid id)
    {
        var entity = SingleOrDefault(id);
        if (entity == null) return;
        _carShopDbContext.Remove(entity);
    }

    public void SaveChanges()
    {
        _carShopDbContext.SaveChanges();
    }
    #endregion

    #region Private members
    private T? SingleOrDefault(Guid id)
    {
        return _carShopDbContext.Set<T>().SingleOrDefault(e => e.Id == id);
    }
    #endregion
}
