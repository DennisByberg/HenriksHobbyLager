# Tekniskt Rapport av Dennis Byberg 💥

## Vilka SOLID-principer du implementerat och hur
* SRP: Varje klass har ett tydligt ansvar. Till exempel ansvarar `ProductRepository` enbart för databasoperationer medan `ProductFacade` hanterar affärslogik.
* OCP: Projektet är utformat så att nya funktioner kan läggas till utan att behöva ändra befintlig kod.
* LSP: `IRepository<Product>` och dess implementering `ProductRepositor` kan bytas ut utan att påverka systemets funktion.
* ISP: Jag har separerat läs- och skrivoperationer i gränssnitt vilket gör det enklare att implementera bara det som behövs.
* DIP: Dependency Injection används genom hela applikationen för att minska beroenden mellan konkreta klasser.

## Beskrivning av din databasimplementation
Jag använde Entity Framework Core med SQLite som databashanterare.
`AppDbContext` definierar dataasen och DbSet används för att interagera med Produkt-tabellen.
Jag har valt att konfigurera databasen i en OnConfig för att inte strula till något, hehe :)

## Patterns du använt och varför
* Repository Pattern: För att kunna isolera databaslogik från applikationen och gör den testbar samt lätt att utbyta datalager.
* Facade Pattern: Agerar som en abstraktion över flera metoder och förenklar användningen för gränssnittet.
* Dependency Injection: Detta löser beroenden vid runtime vilket möjliggör enkel testning och minskar hårda kopplingar i koden.

## Särskilda tekniska utmaningar och lösningar
Min största utmaning var att förhindra hårda beroenden mellan lager, både i praktiken och teorin.
Efter att ha läst på om detta lite extra använde jag gränssnitt och dependency injection för att separera implementeringar.

## Hur du planerade arbetet
Jag började att skapa datalager för att hantera all interaktion med databasen.
Efter det implementerade logik i ProductFacade och kopplade detta till gränssnittet via ConsoleMenuHandler.

## Vilka val du gjorde och varför
Jag valde att hålla allt väldigt enkelt för att kunna göra ett så snyggt projekt som möjligt samtidigt som jag förstod varje del i min kod
för att kunna göra förändringar snabbt om något skulle gå fel. Detta ledde till att min main ser extremt minimal och clean ut.

## Lärdomar under projektets gång
Jag har lärt mig hur man använder dependency injection på ett nybörjarvänligt sett. Jag tycker även jag har fått en bredare förståelse för
hur man använder sig av Facader och Repository pattern

## Vad du skulle göra annorlunda nästa gång
Det finns mycket som jag hade velat ändra på om jag fick mer tid. Jag hade börjat med unit testing för att kunna testa mina metoder för att vara
helt säker på att dom fungerar som dom ska. Jag hade även gjort en lite mer vänligare meny där man kan få lite mer val och kunna gå tillbaks t.ex.

## Tre exempel på där du är särskilt nöjd med din kod (kod exempel)
1. Dependency Injection i Program.cs
```csharp
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>()
    .AddScoped<IRepository<Product>, ProductRepository>()
    .AddScoped<IProductFacade, ProductFacade>()
    .BuildServiceProvider();
```

2. IProductFacade
```csharp
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
```
3. IRepository
```csharp
    // Läsoperationer
    public interface IReadRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> SearchAsync(Expression<Func<Product, bool>> predicate);
    }

    // Skrivoperationer
    public interface IWriteRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    // både läs- och skrivoperationer
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>;
```

## Förklaring varför dessa exempel är bra
De visar hur principerna SRP och DIP appliceras i praktiken och mina interfaces som följer ISP tycker jag är lättläsliga och enkla att kunna
bygga ut. Samt riktigt snygg kod enligt mig :D

## Eventuella alternativa lösningar du övervägde
Direkt användning av DbContext i affärslogiken: Användes inte eftersom jag isåfall skulle bryta mot SRP.

Manuell hantering av beroenden: Användes inte eftersom DI-container gör hanteringen mer robust och modulär efter jag läst på om det.