using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager
{
    public class ConsoleMenuHandler
    {
        private readonly IProductFacade _productFacade;

        public ConsoleMenuHandler(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        public async Task DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Henriks Hobby Lager ===");
                Console.WriteLine("1. Visa alla produkter");
                Console.WriteLine("2. Lägg till ny produkt");
                Console.WriteLine("3. Uppdatera produkt");
                Console.WriteLine("4. Ta bort produkt");
                Console.WriteLine("5. Sök produkter");
                Console.WriteLine("6. Avsluta");
                Console.Write("Välj ett alternativ (1-6): ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await ShowAllProducts();
                        break;
                    case "2":
                        await AddProduct();
                        break;
                    case "3":
                        await UpdateProduct();
                        break;
                    case "4":
                        await DeleteProduct();
                        break;
                    case "5":
                        //await SearchProducts();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }
            }
        }

        private async Task ShowAllProducts()
        {
            var products = await _productFacade.GetAllProductsAsync();

            if (!products.Any())
            {
                Console.WriteLine("Inga produkter finns.");
            }
            else
            {
                foreach (var product in products)
                {
                    DisplayProduct(product);
                }
            }
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        private async Task AddProduct()
        {
            Console.WriteLine("Lägg till ny produkt:");

            Console.Write("Namn: ");
            var name = Console.ReadLine();

            Console.Write("Pris: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Ogiltigt pris.");
                return;
            }

            Console.Write("Antal i lager: ");
            if (!int.TryParse(Console.ReadLine(), out var stock))
            {
                Console.WriteLine("Ogiltig lagermängd.");
                return;
            }

            Console.Write("Kategori: ");
            var category = Console.ReadLine();

            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Stock = stock,
                Category = category,
                Created = DateTime.Now
            };

            await _productFacade.CreateProductAsync(newProduct);
            Console.WriteLine("Produkt tillagd!");
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        private async Task UpdateProduct()
        {
            Console.Write("Ange produkt-ID att uppdatera: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            var product = await _productFacade.GetProductByIdAsync(id);

            if (product == null)
            {
                Console.WriteLine("Produkt inte hittad.");
                return;
            }

            Console.Write("Nytt namn (lämna tomt för att behålla nuvarande): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) product.Name = name;

            Console.Write("Nytt pris (lämna tomt för att behålla nuvarande): ");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(priceInput) && decimal.TryParse(priceInput, out decimal price))
                product.Price = price;

            Console.Write("Ny lagermängd (lämna tomt för att behålla nuvarande): ");
            var stockInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(stockInput) && int.TryParse(stockInput, out int stock))
                product.Stock = stock;

            Console.Write("Ny kategori (lämna tomt för att behålla nuvarande): ");
            var category = Console.ReadLine();
            if (!string.IsNullOrEmpty(category)) product.Category = category;

            product.LastUpdated = DateTime.Now;

            await _productFacade.UpdateProductAsync(product);
            Console.WriteLine("Produkt uppdaterad!");
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        private async Task DeleteProduct()
        {
            Console.Write("Ange produkt-ID att ta bort: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            var product = await _productFacade.GetProductByIdAsync(id);

            if (product == null)
            {
                Console.WriteLine("Produkt inte hittad.");
                return;
            }

            await _productFacade.DeleteProductAsync(id);
            Console.WriteLine("Produkt borttagen!");
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        //private async Task SearchProducts()
        //{
        //    Console.Write("Sök (namn eller kategori): ");
        //    var searchTerm = Console.ReadLine();
        //    var products = await _productFacade.Search(searchTerm);

        //    if (!products.Any())
        //    {
        //        Console.WriteLine("Inga produkter matchade sökningen.");
        //    }
        //    else
        //    {
        //        foreach (var product in products)
        //        {
        //            DisplayProduct(product);
        //        }
        //    }
        //    Console.WriteLine("Tryck på en tangent för att fortsätta...");
        //    Console.ReadKey();
        //}

        private void DisplayProduct(Product product)
        {
            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Namn: {product.Name}");
            Console.WriteLine($"Pris: {product.Price:C}");
            Console.WriteLine($"Lager: {product.Stock}");
            Console.WriteLine($"Kategori: {product.Category}");
            Console.WriteLine($"Skapad: {product.Created}");
            if (product.LastUpdated.HasValue)
                Console.WriteLine($"Senast uppdaterad: {product.LastUpdated}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
