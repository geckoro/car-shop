namespace CarShop.Data.Models;

public class Client : Identifiable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Car>? Cars { get; set; } = new List<Car>();
}
