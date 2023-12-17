using CarShop.General.Models;

namespace CarShop.DataTransfer.DataTransferObjects;

// ReSharper disable once InconsistentNaming
public class CarDTO : IdentifiableDTO
{
    #region Properties and Indexers
    public ClientDTO? Client { get; set; }
    public int Mileage { get; set; }
    public string Model { get; set; }
    #endregion

    #region Public members
    public static CarDTO CreateFromListOfPropertyNameAndValue(List<PropertyNameAndValue> propertyNameAndValues)
    {
        var dto = new CarDTO();
        foreach (var propertyNameAndValue in propertyNameAndValues)
        {
            var type = propertyNameAndValue.Type;
            try
            {
                propertyNameAndValue.Value = Convert.ChangeType(propertyNameAndValue.Value, propertyNameAndValue.Type);
            }
            catch
            {
                propertyNameAndValue.Value = null;
            }
            typeof(CarDTO).GetProperty(propertyNameAndValue.Name)?.SetValue(dto, propertyNameAndValue.Value);
        }
        return dto;
    }
    #endregion
}
