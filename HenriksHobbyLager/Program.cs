using HenriksHobbyLager.Data;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using HenriksHobbyLager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HenriksHobbyLager
{
    static class Program
    {
        static async Task Main()
        {
            // Konfigurera DI-container
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>() // Registrera AppDbContext
                .AddScoped<IRepository<Product>, ProductRepository>() // Registrera repository
                .BuildServiceProvider();

            try
            {
                // Hämta instans av AppDbContext och IRepository<Product> från DI-container
                var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
                var productRepository = serviceProvider.GetRequiredService<IRepository<Product>>();

                // Skapar databasen om den inte finns
                await dbContext.Database.EnsureCreatedAsync();

                // Skapa en ny produkt
                var newProduct = new Product
                {
                    Name = "Röd liten Helikopter",
                    Price = 2999.99m,
                    Stock = 20,
                    Category = "Elektronik",
                    Created = DateTime.Now
                };

                // Lägg till produkt via repository
                await productRepository.AddAsync(newProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }
        }
    }
}
