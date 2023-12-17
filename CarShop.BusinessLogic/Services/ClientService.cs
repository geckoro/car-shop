using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface IClientService : IBaseService<ClientDTO>
{
    #region Public members
    Task CreateAsync(ClientDTO client);
    #endregion
}

public class ClientService : BaseService<ClientDTO>, IClientService
{
    #region Constructors
    public ClientService(IClientRepository clientRepository, IMapper mapper) : base(clientRepository, mapper)
    {
    }
    #endregion

    #region Interface Implementations
    public async Task CreateAsync(ClientDTO client)
    {
        await base.CreateAsync(client);
    }
    #endregion
}
