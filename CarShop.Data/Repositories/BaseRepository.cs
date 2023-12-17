using AutoMapper;
using CarShop.Data.Contexts;
using CarShop.General.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data.Repositories;

public interface IBaseRepositoryFactory<out T> where T : class, IIdentifiable
{
    #region Public members
    IBaseRepository<T> Create(CarShopDbContext carShopDbContext);
    #endregion
}

public interface IBaseRepository<out T> where T : class, IIdentifiable
{
    #region Public members
    void Create(IIdentifiable identifiable);
    IQueryable<T> Get();
    void Remove(Guid id);
    void SaveChanges();
    void Update(IIdentifiable identifiable);
    #endregion
}

/// <summary>
///     Base implementation of a repository. Helps with reducing code duplication.
/// </summary>
public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IIdentifiable
{
    #region Fields
    private readonly IMapper _mapper;
    private CarShopDbContext _carShopDbContext;
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
        _carShopDbContext = new CarShopDbContext();
        var entity = _mapper.Map<T>(identifiable);
        _carShopDbContext.Add((object)entity);
        _carShopDbContext.SaveChanges();
    }

    public IQueryable<T> Get()
    {
        _carShopDbContext = new CarShopDbContext();
        return _carShopDbContext.Set<T>().AsNoTracking();
    }

    public void Remove(Guid id)
    {
        _carShopDbContext = new CarShopDbContext();
        var entity = SingleOrDefault(id);
        if (entity == null) return;
        _carShopDbContext.Remove(entity);
        _carShopDbContext.SaveChanges();
    }

    public void SaveChanges()
    {
        _carShopDbContext.SaveChanges();
    }

    public void Update(IIdentifiable identifiable)
    {
        _carShopDbContext = new CarShopDbContext();
        var entity = _mapper.Map<T>(identifiable);
        _carShopDbContext.Update(entity);
        _carShopDbContext.SaveChanges();
    }
    #endregion

    #region Private members
    private T? SingleOrDefault(Guid id)
    {
        return _carShopDbContext.Set<T>().AsNoTracking().SingleOrDefault(e => e.Id == id);
    }
    #endregion
}
