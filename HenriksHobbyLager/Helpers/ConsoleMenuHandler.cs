using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Helpers
{
    public class ConsoleMenuHandler(IProductFacade productFacade)
    {
        private readonly IProductFacade _productFacade = productFacade;

        public async Task DisplayMenu()
        {
            while (true)
            {
                Console.Clear(); // Rensar skärmen så det ser proffsigt ut
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
                        await SearchProducts();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val! Är du säker på att du tryckte på rätt knapp?");
                        break;
                }
            }
        }

        // Visar alla produkter som finns i databasen
        private async Task ShowAllProducts()
        {
            var products = await _productFacade.GetAllProductsAsync();

            if (!products.Any())
            {
                Console.WriteLine("Inga produkter finns i lagret. Dags att shoppa grossist!");
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

        // Lägger till en ny produkt i databasen
        private async Task AddProduct()
        {
            Console.WriteLine("=== Lägg till ny produkt ===");

            Console.Write("Namn: ");
            var name = Console.ReadLine();

            Console.Write("Pris: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Ogiltigt pris! Använd punkt istället för komma (lärde mig den hårda vägen)");
                return;
            }

            Console.Write("Antal i lager: ");
            if (!int.TryParse(Console.ReadLine(), out var stock))
            {
                Console.WriteLine("Ogiltig lagermängd! Hela tal endast (kan inte sälja halva helikoptrar)");
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

        // Uppdaterar en befintlig produkt
        private async Task UpdateProduct()
        {
            Console.Write("Ange produkt-ID att uppdatera (finns i listan ovan): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID! Bara siffror tack!");
                return;
            }

            var product = await _productFacade.GetProductByIdAsync(id);

            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte! Är du säker på att du skrev rätt?");
                return;
            }

            Console.Write("Nytt namn (tryck bara enter om du vill behålla det gamla): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) product.Name = name;

            Console.Write("Nytt pris (tryck bara enter om du vill behålla det gamla): ");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(priceInput) && decimal.TryParse(priceInput, out decimal price))
                product.Price = price;

            Console.Write("Ny lagermängd (tryck bara enter om du vill behålla den gamla): ");
            var stockInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(stockInput) && int.TryParse(stockInput, out int stock))
                product.Stock = stock;

            Console.Write("Ny kategori (tryck bara enter om du vill behålla den gamla): ");
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
            Console.Write("Ange produkt-ID att ta bort (dubbel-check att det är rätt, går inte att ångra!): ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID! Bara siffror är tillåtna här.");
                return;
            }

            var product = await _productFacade.GetProductByIdAsync(id);

            if (product == null)
            {
                Console.WriteLine("Produkt hittades inte! Puh, inget blev raderat av misstag!");
                return;
            }

            await _productFacade.DeleteProductAsync(id);
            Console.WriteLine("Produkt borttagen! (Hoppas det var meningen)");
            Console.WriteLine("Tryck på en tangent för att fortsätta...");
            Console.ReadKey();
        }

        private async Task SearchProducts()
        {
            Console.Write("Sök (namn eller kategori - versaler spelar ingen roll!): ");
            var searchTerm = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                Console.WriteLine("Sökordet får inte vara tomt. Försök igen.");
                return;
            }

            var products = await _productFacade.SearchProductsAsync(searchTerm);

            if (!products.Any())
            {
                Console.WriteLine("Inga produkter matchade sökningen. Prova med något annat!");
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

        private void DisplayProduct(Product product)
        {
            // Snygga streck som separerar produkterna
            Console.WriteLine($"ID: {product.Id}");
            Console.WriteLine($"Namn: {product.Name}");
            Console.WriteLine($"Pris: {product.Price:C}"); // :C gör att det blir kronor automatiskt!
            Console.WriteLine($"Lager: {product.Stock}");
            Console.WriteLine($"Kategori: {product.Category}");
            Console.WriteLine($"Skapad: {product.Created}");
            if (product.LastUpdated.HasValue) // Kollar om produkten har uppdaterats någon gång
                Console.WriteLine($"Senast uppdaterad: {product.LastUpdated}");
            Console.WriteLine(new string('-', 40)); // Snyggt streck mellan produkterna
        }
    }
}
