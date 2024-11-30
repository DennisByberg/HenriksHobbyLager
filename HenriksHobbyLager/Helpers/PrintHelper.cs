namespace HenriksHobbyLager.Helpers
{
    internal static class PrintHelper
    {
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Henriks HobbyLager™ 1.0 ===");
            Console.WriteLine("1. Visa alla produkter");
            Console.WriteLine("2. Lägg till produkt");
            Console.WriteLine("3. Uppdatera produkt");
            Console.WriteLine("4. Ta bort produkt");
            Console.WriteLine("5. Sök produkter");
            Console.WriteLine("6. Avsluta");
        }
    }
}
