using HenriksHobbyLager.Models;
using HenriksHobbyLager.Repositories;

namespace HenriksHobbyLager
{
    static class Program
    {
        static async Task Main()
        {
            var productRepo = new ProductRepository();

            // Skapa en ny produkt
            var newProduct = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 7999.99m,
                Stock = 10,
                Category = "Elektronik",
                Created = DateTime.Now
            };

            // Lägg till produkt
            await productRepo.AddAsync(newProduct);

            // Hämta alla produkter
            var products = await productRepo.GetAllAsync();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }
        }
    }
}
