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