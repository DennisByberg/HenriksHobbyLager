using HenriksHobbyLager.Helpers;

namespace HenriksHobbyLager
{

    static class Program
    {
        static void Main()
        {
            // Huvudloopen - Stäng inte av programmet, då försvinner allt!
            while (true)
            {
                PrintHelper.PrintMenu();
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Product.ShowAllProducts();
                        break;
                    case "2":
                        Product.AddProduct();
                        break;
                    case "3":
                        Product.UpdateProduct();
                        break;
                    case "4":
                        Product.DeleteProduct();
                        break;
                    case "5":
                        Product.SearchProducts();
                        break;
                    case "6":
                        return;  // OBS! All data försvinner om du väljer denna!
                    default:
                        Console.WriteLine("Ogiltigt val! Är du säker på att du tryckte på rätt knapp?");
                        break;
                }

                Console.WriteLine("\nTryck på valfri tangent för att fortsätta... (helst inte ESC)");
                Console.ReadKey();
            }
        }
    }
}