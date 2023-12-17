namespace CarShop.DataTransfer.DataTransferObjects;

// ReSharper disable once InconsistentNaming
public class CarDTO : IdentifiableDTO
{
    #region Properties and Indexers
    public ClientDTO? Client { get; set; }
    public int Mileage { get; set; }
    public string Model { get; set; }
    #endregion
}
