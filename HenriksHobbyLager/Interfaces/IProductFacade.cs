using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Interfaces
{
    // Metoderna är asynkrona för att stödja långsamma operationer som databasanrop.
    public interface IProductFacade
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    }
}