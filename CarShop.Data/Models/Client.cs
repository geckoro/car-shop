namespace CarShop.Data.Models;

public class Client : Identifiable
{
    #region Properties and Indexers
    public ICollection<Car>? Cars { get; set; } = new List<Car>();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    #endregion
}
