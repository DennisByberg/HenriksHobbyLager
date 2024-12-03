using HenriksHobbyLager.Data;
using HenriksHobbyLager.Facades;
using HenriksHobbyLager.Helpers;
using HenriksHobbyLager.Interfaces;
using HenriksHobbyLager.Models;
using HenriksHobbyLager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HenriksHobbyLager
{
    static class Program
    {
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<AppDbContext>()                           // Registrera AppDbContext
                .AddScoped<IRepository<Product>, ProductRepository>()   // Registrera Repository
                .AddScoped<IProductFacade, ProductFacade>()             // Registrera Facade
                .BuildServiceProvider();                                // Bygg DI-container

            // Hämta instans av IProductFacade från DI-container
            var productFacade = serviceProvider.GetRequiredService<IProductFacade>();

            // Skapa en instans av ConsoleMenuHandler
            var menuHandler = new ConsoleMenuHandler(productFacade);

            // Starta menyn
            await menuHandler.DisplayMenu();
        }
    }
}
