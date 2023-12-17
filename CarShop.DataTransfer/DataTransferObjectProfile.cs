using AutoMapper;
using CarShop.Data.Models;
using CarShop.DataTransfer.DataTransferObjects;

namespace CarShop.DataTransfer;

public class DataTransferObjectProfile : Profile
{
    #region Constructors
    public DataTransferObjectProfile()
    {
        CreateMap<Car, CarDTO>();
        CreateMap<CarDTO, Car>();
        CreateMap<Client, ClientDTO>();
        CreateMap<ClientDTO, Client>();
    }
    #endregion
}
