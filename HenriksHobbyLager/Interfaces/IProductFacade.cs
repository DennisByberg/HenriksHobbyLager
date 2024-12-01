using HenriksHobbyLager.Models;

namespace HenriksHobbyLager.Interfaces
{
    // Läsoperationer
    public interface IReadProductFacade
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
    }

    // Skrivoperationer
    public interface IWriteProductFacade
    {
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }

    // Läs- och skrivoperationer
    public interface IProductFacade : IReadProductFacade, IWriteProductFacade
    {
    }
}