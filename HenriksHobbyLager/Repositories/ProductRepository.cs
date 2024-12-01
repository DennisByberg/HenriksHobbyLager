using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly List<Product> _products = [];

        // Hämtar alla produkter
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        // Hämtar en produkt baserat på ID
        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(product);
        }

        // Lägger till en produkt
        public async Task AddAsync(Product entity)
        {
            _products.Add(entity);

            await Task.CompletedTask;
        }

        // Uppdaterar en produkt
        public async Task UpdateAsync(Product entity)
        {
            var product = _products.FirstOrDefault(p => p.Id == entity.Id);
            if (product != null)
            {
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.Stock = entity.Stock;
                product.Category = entity.Category;
                product.LastUpdated = entity.LastUpdated;
            }

            await Task.CompletedTask;
        }

        // Tar bort en produkt
        public async Task DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null) _products.Remove(product);

            await Task.CompletedTask;
        }

        // Söker produkter baserat på ett villkor
        public async Task<IEnumerable<Product>> SearchAsync(Func<Product, bool> predicate)
        {
            var result = _products.Where(predicate).ToList();
            return await Task.FromResult(result);
        }
    }
}
