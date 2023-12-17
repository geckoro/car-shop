namespace CarShop.DataTransfer.DataTransferObjects;

// ReSharper disable once InconsistentNaming
public class ClientDTO : IdentifiableDTO
{
    #region Properties and Indexers
    public ICollection<CarDTO>? Cars { get; set; } = new List<CarDTO>();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    #endregion
}
