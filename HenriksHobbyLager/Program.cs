using HenriksHobbyLager.Facades;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using HenriksHobbyLager.Repositories;

namespace HenriksHobbyLager
{
    static class Program
    {
        static async Task Main()
        {
            var productRepository = new ProductRepository();
            IProductFacade productFacade = new ProductFacade(productRepository);

            // Skapa en ny produkt
            var newProduct = new Product
            {
                Id = 1,
                Name = "Röd liten Helikopter",
                Price = 2999.99m,
                Stock = 20,
                Category = "Elektronik",
                Created = DateTime.Now
            };

            await productFacade.CreateProductAsync(newProduct);

            // Hämta alla produkter
            var allProducts = await productFacade.GetAllProductsAsync();

            foreach (var product in allProducts)
                Console.WriteLine($"{product.Name} - {product.Price:C}");

            // Sök efter produkter
            var searchResults = await productFacade.SearchProductsAsync("Röd liten Helikopter");

            foreach (var product in searchResults)
                Console.WriteLine($"{product.Name} - {product.Price:C}");
        }
    }
}
