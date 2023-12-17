using CarShop.Data.Contexts;
using CarShop.General.Interfaces;

namespace CarShop.Data.Repositories;

public interface IBaseRepository<out T> where T : class, IIdentifiable
{
    #region Public members
    IQueryable<T> Get();
    IQueryable<T> Get(Guid id);
    #endregion
}

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IIdentifiable
{
    #region Fields
    private readonly CarShopDbContext _carShopDbContext;
    #endregion

    #region Constructors
    protected BaseRepository(CarShopDbContext carShopDbContext)
    {
        _carShopDbContext = carShopDbContext;
    }
    #endregion

    #region Interface Implementations
    public IQueryable<T> Get()
    {
        return _carShopDbContext.Set<T>();
    }

    public IQueryable<T> Get(Guid id)
    {
        return _carShopDbContext.Set<T>().Where(e => e.Id == id);
    }
    #endregion
}
