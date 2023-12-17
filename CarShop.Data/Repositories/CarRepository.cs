using CarShop.Data.Contexts;
using CarShop.Data.Models;

namespace CarShop.Data.Repositories;

public interface ICarRepository : IBaseRepository<Car>
{
}

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    #region Constructors
    public CarRepository(CarShopDbContext carShopDbContext) : base(carShopDbContext)
    {
    }
    #endregion
}
