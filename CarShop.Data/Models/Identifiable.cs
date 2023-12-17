using System.ComponentModel.DataAnnotations;
using CarShop.General.Interfaces;

namespace CarShop.Data.Models;

public abstract class Identifiable : IIdentifiable
{
    #region Properties and Indexers
    [Key]
    public Guid Id { get; set; }
    #endregion
}
