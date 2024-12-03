using HenriksHobbyLager.Data;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HenriksHobbyLager.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly AppDbContext _dbContext;

        // Konstruktor som tar emot DbContext
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Hämtar alla produkter
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        // Hämtar en produkt baserat på ID
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        // Lägger till en produkt
        public async Task AddAsync(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Uppdaterar en produkt
        public async Task UpdateAsync(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Tar bort en produkt
        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Söker produkter baserat på ett villkor
        public async Task<IEnumerable<Product>> SearchAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _dbContext.Products.Where(predicate).ToListAsync();
        }
    }
}
