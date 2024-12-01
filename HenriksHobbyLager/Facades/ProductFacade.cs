using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Facades
{
    internal class ProductFacade : IProductFacade
    {
        private readonly IRepository<Product> _productRepository;

        // Konstruktor som tar emot ett IRepository<Product> för att kunna kommunicera med datalagret
        public ProductFacade(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // Hämtar alla produkter
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // Hämtar en produkt baserat på ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // Skapar en ny produkt
        public async Task CreateProductAsync(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            await _productRepository.AddAsync(product);
        }

        // Uppdaterar en produkt
        public async Task UpdateProductAsync(Product product)
        {
            // Lägg till validering, t.ex. kolla om produktens ID finns i datalagret innan du uppdaterar.
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException("Produkt hittas inte, kan inte uppdateras.");

            await _productRepository.UpdateAsync(product);
        }

        // Tar bort en produkt
        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                throw new KeyNotFoundException("Produkt hittas inte, kan inte tas bort.");

            await _productRepository.DeleteAsync(id);
        }

        // Söker produkter baserat på ett sökord
        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            return await _productRepository.SearchAsync(p =>
                p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
    }
}