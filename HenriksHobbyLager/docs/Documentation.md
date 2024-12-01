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