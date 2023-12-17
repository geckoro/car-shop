using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models;

public abstract class Identifiable
{
    [Key]
    public Guid Id { get; set; }
}
