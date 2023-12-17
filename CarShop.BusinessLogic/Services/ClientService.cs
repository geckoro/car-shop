using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface IClientService : IBaseService<ClientDTO>
{
}

public class ClientService : BaseService<ClientDTO>, IClientService
{
    #region Constructors
    public ClientService(IClientRepository clientRepository, IMapper mapper) : base(clientRepository, mapper)
    {
    }
    #endregion
}
