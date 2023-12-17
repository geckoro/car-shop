using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models;

public class Car : Identifiable
{
    #region Properties and Indexers
    [ForeignKey("ClientId")]
    public Client? Client { get; set; }

    public int Mileage { get; set; }
    public string Model { get; set; }
    #endregion
}
