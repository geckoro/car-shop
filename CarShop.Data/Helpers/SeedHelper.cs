using CarShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Data.Helpers;

public static class SeedHelper
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasData(
                new Car
                {
                    Id = Guid.NewGuid(),
                    Mileage = 0,
                    Model = "Tesla"
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Mileage = 31120,
                    Model = "Mazda"
                },
                new Car
                {
                    Id = Guid.NewGuid(),
                    Mileage = 91234,
                    Model = "Audi"
                }
            );
        modelBuilder.Entity<Client>()
            .HasData(
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mike",
                    LastName = "Smith"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Joanna",
                    LastName = "Christens"
                },
                new Client
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bob",
                    LastName = "Kennedy"
                }
            );
    }
}
