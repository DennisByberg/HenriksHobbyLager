# Individuell Rapport

Svara på frågorna nedan och lämna in det som en del av din inlämning.

## Hur fungerade gruppens arbete?
Jag gjorde inlämningen själv vilket innebar att jag ansvarade för samtliga delar av projektet.
Min "grupp" fungerade utmärkt eftersom jag kunde fatta alla beslut och arbeta i min egen takt :)

## Beskriv gruppens databasimplementation
Databasen implementerades med hjälp av Entity Framework Core och en SQLite-databas.
Modellen jag använder har egenskaper som Id, Name, Price, Stock, Category, Created, och LastUpdated.

## Vilka SOLID-principer implementerade ni och hur?
* SRP: Varje klass har ett tydligt ansvar. Till exempel ansvarar `ProductRepository` enbart för databasoperationer medan `ProductFacade` hanterar affärslogik.
* OCP: Projektet är utformat så att nya funktioner kan läggas till utan att behöva ändra befintlig kod.
* LSP: `IRepository<Product>` och dess implementering `ProductRepositor` kan bytas ut utan att påverka systemets funktion.
* ISP: Jag har separerat läs- och skrivoperationer i gränssnitt vilket gör det enklare att implementera bara det som behövs.
* DIP: Dependency Injection används genom hela applikationen för att minska beroenden mellan konkreta klasser.

## Vilka patterns använde ni och varför?
* Repository Pattern: För att kunna isolera databaslogik från applikationen och gör den testbar samt lätt att utbyta datalager.
* Facade Pattern: Agerar som en abstraktion över flera metoder och förenklar användningen för gränssnittet.
* Dependency Injection: Detta löser beroenden vid runtime vilket möjliggör enkel testning och minskar hårda kopplingar i koden.

## Vilka tekniska utmaningar stötte ni på och hur löste ni dem?
Min största utmaning var att förhindra hårda beroenden mellan lager, både i praktiken och teorin.
Efter att ha läst på om detta lite extra använde jag gränssnitt och dependency injection för att separera implementeringar.

## Hur planerade du ditt arbete?
Jag började att skapa datalager för att hantera all interaktion med databasen.
Efter det implementerade logik i ProductFacade och kopplade detta till gränssnittet via ConsoleMenuHandler.

## Vilka dela gjorde du?
Alla delar, eftersom jag arbeta själv.

## Vilka utmaningar stötte du på och hur löste du dem?
En stor utmaning var att kunna diskutera hur man ska lösa ett problem eftersom jag var själv. Jag tog hjälp av ChatGPT för att inte känna mig ensam och kunna bolla lite idéer :)

## Vad skulle du göra annorlunda nästa gång?
Jobba i grupp för att kunna diskutera lösningar och problem.