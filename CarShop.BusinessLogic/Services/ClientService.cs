using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface IClientService : IBaseService<ClientDTO>
{
    #region Public members
    void Create(ClientDTO client);
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
    public void Create(ClientDTO client)
    {
        base.Create(client);
    }
    #endregion
}
