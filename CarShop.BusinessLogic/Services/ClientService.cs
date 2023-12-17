using AutoMapper;
using CarShop.Data.Repositories;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.BusinessLogic.Services;

public interface IClientService
{
    #region Public members
    IEnumerable<ClientDTO> Get();
    IEnumerable<ClientDTO> Get(Guid id);
    #endregion
}

public class ClientService : IClientService
{
    #region Fields
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }
    #endregion

    #region Interface Implementations
    public IEnumerable<ClientDTO> Get()
    {
        return _mapper.Map<IEnumerable<ClientDTO>>(_clientRepository.Get());
    }

    public IEnumerable<ClientDTO> Get(Guid id)
    {
        return _mapper.Map<IEnumerable<ClientDTO>>(_clientRepository.Get(id));
    }
    #endregion
}
