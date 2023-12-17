using System;
using System.Collections.Generic;
using System.Linq;
using CarShop.DataTransfer.DataTransferObjects;
using CarShop.General.Models;
using CarShop.General.Services;
using CarShop.UserInterface.Views;

namespace CarShop.UserInterface.ViewModels;

public interface IEntityViewModelFactory
{
    #region Public members
    IEntityViewModel Create(Type type);
    #endregion
}

public interface IEntityViewModel
{
    #region Properties and Indexers
    List<PropertyNameAndValue> PropertyNamesAndValues { get; set; }
    #endregion
}

public class EntityViewModel : IEntityViewModel
{
    #region Properties and Indexers
    public List<PropertyNameAndValue> PropertyNamesAndValues { get; set; }
    #endregion

    #region Constructors
    static EntityViewModel()
    {
        DialogService.TryRegisterWindow(typeof(EntityViewModel), typeof(EntityWindow));
    }

    public EntityViewModel(Type type)
    {
        PropertyNamesAndValues = type.GetProperties()
            .Where(p => p.Name != nameof(IdentifiableDTO.Id) && p.Name != nameof(ClientDTO.Cars))
            .Select(p => new PropertyNameAndValue(p.Name, string.Empty, p.PropertyType))
            .ToList();
    }
    #endregion
}
