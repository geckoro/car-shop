using CarShop.General.Interfaces;

namespace CarShop.DataTransfer.DataTransferObjects;

// ReSharper disable once InconsistentNaming
public class IdentifiableDTO : IIdentifiable
{
    #region Properties and Indexers
    public Guid Id { get; set; }
    #endregion
}
