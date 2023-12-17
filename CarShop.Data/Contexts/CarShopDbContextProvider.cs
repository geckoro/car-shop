namespace CarShop.Data.Contexts;

public class CarShopDbContextProvider
{
    #region Static Fields and Constants
    public static CarShopDbContext Context = new CarShopDbContext();
    #endregion

    #region Public members
    public static void CreateNew()
    {
        Context = new CarShopDbContext();
    }
    #endregion
}
