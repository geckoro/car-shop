using CarShop.Constants;
using CarShop.Data.Helpers;
using CarShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data.Contexts;

public sealed class CarShopDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(StringConstants.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedHelper.Seed(modelBuilder);
    }
}
