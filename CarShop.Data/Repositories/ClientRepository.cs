using AutoMapper;
using CarShop.Data.Contexts;
using CarShop.Data.Models;

namespace CarShop.Data.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
}

public class ClientRepository : BaseRepository<Client>, IClientRepository
{
    #region Constructors
    public ClientRepository(CarShopDbContext carShopDbContext, IMapper mapper) : base(carShopDbContext, mapper)
    {
    }
    #endregion
}
