using AutoMapper;
using CarShop.Data.Contexts;
using CarShop.General.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data.Repositories;

public interface IBaseRepository<out T> where T : class, IIdentifiable
{
    #region Public members
    Task CreateAsync(IIdentifiable identifiable);
    IQueryable<T> Get();
    Task RemoveAsync(Guid id);
    Task SaveChangesAsync();
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
    public async Task CreateAsync(IIdentifiable identifiable)
    {
        var entity = _mapper.Map<T>(identifiable);
        await _carShopDbContext.AddAsync(entity);
    }

    public IQueryable<T> Get()
    {
        return _carShopDbContext.Set<T>();
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await SingleOrDefaultAsync(id);
        if (entity == null) return;
        _carShopDbContext.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _carShopDbContext.SaveChangesAsync();
    }
    #endregion

    #region Private members
    private async Task<T?> SingleOrDefaultAsync(Guid id)
    {
        return await _carShopDbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
    }
    #endregion
}
