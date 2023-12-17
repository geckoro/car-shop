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
        CreateMap<Client, ClientDTO>();
    }
    #endregion
}
