# Installationsguide 🔌
1. Börja med att klona projektet
```
git clone https://github.com/DennisByberg/HenriksHobbyLager.git
```

2. Öppna projektet i ditt favorit IDE.

3. Se till att du har följande plugin: Microsoft.EntityFrameworkCore.Sqlite för att kunna koppla dig till databasen.

4. Starta projektet och börja hanteringen av produkter, allt kommer sparas till en SQLITE databas.

# Solid Exempel 🧩
## Single Responsibility Principle (SRP)
Jag använder mig bara av klasser som har ett ansvarsområde. Ett exempel är mitt `ProductRepository`.
Denna klass hanterar endast produktdata i databasen (CRUD-operationer).

```csharp
public class ProductRepository : IRepository<Product>
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task AddAsync(Product entity)
    {
        await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> SearchAsync(Expression<Func<Product, bool>> predicate)
    {
        return await _dbContext.Products.Where(predicate).ToListAsync();
    }
}
```

## Open/Closed Principle (OCP)
Om man vill lägga till nya entiteter, till exempel en `Order`-entitet behöver man inte ändra befintliga `ProductRepository`.
Istället kan man skapa en ny `OrderRepository` som implementerar `IRepository<Order>`.

```csharp
// Interface för generiska repository-metoder
public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> { }

// Interface för facadens funktionalitet
public interface IProductFacade : IReadProductFacade, IWriteProductFacade { }
```

## Interface Segregation Principle (ISP)
Jag har separata interface för läsoperationer och skrivoperationer som säkerställer att klasser
som bara behöver läsa data inte tvingas implementera metoder för att skriva data.

```csharp
public interface IReadRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate);
}

public interface IWriteRepository<T>
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> { }
```

## Dependency Inversion Principle (DIP)

```csharp
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>()                           
    .AddScoped<IRepository<Product>, ProductRepository>()   
    .AddScoped<IProductFacade, ProductFacade>()             
    .BuildServiceProvider();

```

Förklaring: Här injiceras abstraktionerna (`IRepository<Product>` och `IProductFacade`) istället för konkreta klasser.
Det säkerställer att högre nivåer av kod (`ConsoleMenuHandler`) inte är direkt beroende av de specifika implementationerna av repositories eller facader.