using System.ComponentModel.DataAnnotations;

namespace CarShop.Data.Models;

public abstract class Identifiable
{
    #region Properties and Indexers
    [Key]
    public Guid Id { get; set; }
    #endregion
}
