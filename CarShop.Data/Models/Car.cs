using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models;

public class Car : Identifiable
{
    [ForeignKey("ClientId")]
    public Client? Client { get; set; }
    public string Model { get; set; }
    public int Mileage { get; set; }
}
