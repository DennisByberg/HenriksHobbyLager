using HenriksHobbyLager.Models;
using Microsoft.EntityFrameworkCore;

namespace HenriksHobbyLager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: Gömma min databas sträng?
            optionsBuilder.UseSqlite("Data Source=ProductInventory.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                // TODO: Lägg oå mer kontroller
                entity.HasKey(p => p.Id); // Primary Key
            });
        }
    }
}
