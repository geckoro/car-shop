using CarShop.General.Models;

namespace CarShop.DataTransfer.DataTransferObjects;

// ReSharper disable once InconsistentNaming
public class ClientDTO : IdentifiableDTO
{
    #region Properties and Indexers
    public ICollection<CarDTO>? Cars { get; set; } = new List<CarDTO>();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    #endregion

    #region Public members
    public static ClientDTO CreateFromListOfPropertyNameAndValue(List<PropertyNameAndValue> propertyNameAndValues)
    {
        var dto = new ClientDTO();
        foreach (var propertyNameAndValue in propertyNameAndValues)
        {
            var type = propertyNameAndValue.Type;
            var value = propertyNameAndValue.Value ?? (type.IsValueType ? Activator.CreateInstance(type) : null);
            typeof(ClientDTO).GetProperty(propertyNameAndValue.Name)?.SetValue(dto, value);
        }
        return dto;
    }
    #endregion
}
