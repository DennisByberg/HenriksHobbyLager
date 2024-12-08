## Task 1.1.1: Identifiera nuvarande kodproblem
* Det största problemet med den nuvarande koden är att för mycket logik ligger i Main-metoden
vilket bryter mot principen om enkel ansvarighet och gör koden svår att underhålla, testa och utöka.
Main-metoden hanterar användarinmatning, styr menyn och utför olika åtgärder som att lägga till, uppdatera och ta bort produkter.
Detta leder till en metod som är svår att hantera.

* Det finns ingen databas att spara mina produkter i vilket är ett stort problem just nu

* Det finns ingen validering

* Hård kodad användargränssnitt

* Dålig exception handling

### 

## Task 1.1.3 - Dokumentera nuvarande kodstruktur och problemområden:
* Main metoden ansvarar över allt, den gör även affärslogik vilket bryter mot Single Responsibility Principle som jag strävar efter.

* Produktlogik ligger i Product-klassen som statiska metoder. 

* Inget Repository Pattern som jag strävar efter.

* Allmänt stökigt.

* Ingen databas än


# Feature 1.4: Tillämpa SOLID-principerna

### Task 1.4.1: Implementera Single Responsibility i alla klasser
Just nu uppfyller jag SRP i alla klasser förutom Main & ProductRepository. Varför jag inte väljer att göra något åt detta
är för att jag senare kommer att skapa en SQLITE databas och implementera logik för att lagra min data i den. På så vis kommer jag uppfylla SRP med tiden
utan att behöva göra justeringar just nu.

### Task 1.4.2: Kontrollera Open/Closed i metod- och klassdesign

Min kod följer OCP bra. IRepository och IProductFacade är öppna för utökning vilket innebär att jag kan implementera nya versioner
utan att ändra de befintliga klasserna.

Klasserna ProductRepository och ProductFacade är också designade för att vara stängda för modifiering men öppna för utökning,
vilket gör det möjligt att lägga till nya funktioner utan att behöva ändra den befintliga logiken.

### Task 1.4.3: Se till att Liskov Substitution fungerar med gränssnitt
Min kod uppfyller Liskov Substitution Principle genom att använda interfaces vilket gör det möjligt att byta ut implementeringar utan att påverka funktionaliteten.
Alla mina klasser som implementerar gränssnitten kan ersättas med andra utan att gå sönder.

### Task 1.4.4: Segregera stora interfaces till mindre, fokuserade
Jag har delat upp mina interface i mindre mer fokuserade.
Genom att skapa separata gränssnitt för läs- och skrivoperationer
(t.ex. IReadProductFacade och IWriteProductFacade) har jag säkerställt att varje gränssnitt har ett tydligt och avgränsat ansvar.

### Task 1.4.5: Inför Dependency Injection där det är relevant
Jag tycker inte det är relevant att göra några förändringar just nu.

### Task 1.4.5: Task 3.1.3: Dokumentera gränssnittets struktur och arbetsflöde

Startmeny visar en lista med alternativ:
* Visa alla produkter
* Lägg till ny produkt
* Uppdatera produkt
* Ta bort produkt
* Sök produkter
* Avsluta

#### Alternativ 1: Visa alla produkter:
Anropar ShowAllProducts() som hämtar och visar alla produkter via IProductFacade.GetAllProductsAsync().

#### Alternativ 2: Lägg till ny produkt:
Anropar AddProduct() som samlar in produktinformation från användaren och skapar en ny produkt via IProductFacade.CreateProductAsync().

#### Alternativ 3: Uppdatera produkt:
Anropar UpdateProduct() som låter användaren uppdatera en produkt via IProductFacade.GetProductByIdAsync(id) och IProductFacade.UpdateProductAsync().

#### Alternativ 4: Ta bort produkt:
Anropar DeleteProduct() som tar bort en produkt via IProductFacade.GetProductByIdAsync(id) och IProductFacade.DeleteProductAsync().

#### Alternativ 5: Sök produkter (kommenterad kod, kan implementeras i framtiden):
Anropar SearchProducts() som skulle söka efter produkter via IProductFacade.Search().

#### Alternativ 6: Avsluta:
Avslutar programmet via Environment.Exit(0).

### Task 5.1.1: Beskriv projektets syfte och funktioner

#### Syfte 
Henriks Hobby Lager är ett lagerhanteringssystem för hobbyprodukter.
Projektet syftar till att hjälpa Henrik att organisera och hantera sina produkter.

#### Funktioner
*  Visa produkter: En lista över alla produkter i lagret kan hämtas och visas i konsolen.
Lägg till ny produkt: Användaren kan lägga till en ny produkt genom att ange namn, pris, lagermängd, och kategori.

* Uppdatera produkt: En befintlig produkt kan uppdateras med ny information. Användaren kan ändra valfria egenskaper.

* Ta bort produkt: Användaren kan ta bort en produkt från lagret permanent.

* Sökning av produkt:
Sök produkter baserat på namn eller kategori. Programmet söker oberoende av versaler eller gemener och returnerar alla matchande produkter.

Programmet använder en SQLite-databas för att lagra produktinformation. Det finns en konsolmeny som guidar användaren genom olika operationer. Validering är inbyggd för att säkerställa korrekt input.
5. 
Programmet använder Dependency Injection (DI), för att skapa löst kopplade komponenter som är lättare att testa, återanvända och underhålla. Tjänster som IProductFacade och IRepository<Product> injiceras automatiskt vid behov.