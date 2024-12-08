## Task 1.1.1: Identifiera nuvarande kodproblem
* Det st�rsta problemet med den nuvarande koden �r att f�r mycket logik ligger i Main-metoden
vilket bryter mot principen om enkel ansvarighet och g�r koden sv�r att underh�lla, testa och ut�ka.
Main-metoden hanterar anv�ndarinmatning, styr menyn och utf�r olika �tg�rder som att l�gga till, uppdatera och ta bort produkter.
Detta leder till en metod som �r sv�r att hantera.

* Det finns ingen databas att spara mina produkter i vilket �r ett stort problem just nu

* Det finns ingen validering

* H�rd kodad anv�ndargr�nssnitt

* D�lig exception handling

### 

## Task 1.1.3 - Dokumentera nuvarande kodstruktur och problemomr�den:
* Main metoden ansvarar �ver allt, den g�r �ven aff�rslogik vilket bryter mot Single Responsibility Principle som jag str�var efter.

* Produktlogik ligger i Product-klassen som statiska metoder. 

* Inget Repository Pattern som jag str�var efter.

* Allm�nt st�kigt.

* Ingen databas �n


# Feature 1.4: Till�mpa SOLID-principerna

### Task 1.4.1: Implementera Single Responsibility i alla klasser
Just nu uppfyller jag SRP i alla klasser f�rutom Main & ProductRepository. Varf�r jag inte v�ljer att g�ra n�got �t detta
�r f�r att jag senare kommer att skapa en SQLITE databas och implementera logik f�r att lagra min data i den. P� s� vis kommer jag uppfylla SRP med tiden
utan att beh�va g�ra justeringar just nu.

### Task 1.4.2: Kontrollera Open/Closed i metod- och klassdesign

Min kod f�ljer OCP bra. IRepository och IProductFacade �r �ppna f�r ut�kning vilket inneb�r att jag kan implementera nya versioner
utan att �ndra de befintliga klasserna.

Klasserna ProductRepository och ProductFacade �r ocks� designade f�r att vara st�ngda f�r modifiering men �ppna f�r ut�kning,
vilket g�r det m�jligt att l�gga till nya funktioner utan att beh�va �ndra den befintliga logiken.

### Task 1.4.3: Se till att Liskov Substitution fungerar med gr�nssnitt
Min kod uppfyller Liskov Substitution Principle genom att anv�nda interfaces vilket g�r det m�jligt att byta ut implementeringar utan att p�verka funktionaliteten.
Alla mina klasser som implementerar gr�nssnitten kan ers�ttas med andra utan att g� s�nder.

### Task 1.4.4: Segregera stora interfaces till mindre, fokuserade
Jag har delat upp mina interface i mindre mer fokuserade.
Genom att skapa separata gr�nssnitt f�r l�s- och skrivoperationer
(t.ex. IReadProductFacade och IWriteProductFacade) har jag s�kerst�llt att varje gr�nssnitt har ett tydligt och avgr�nsat ansvar.

### Task 1.4.5: Inf�r Dependency Injection d�r det �r relevant
Jag tycker inte det �r relevant att g�ra n�gra f�r�ndringar just nu.

### Task 1.4.5: Task 3.1.3: Dokumentera gr�nssnittets struktur och arbetsfl�de

Startmeny visar en lista med alternativ:
* Visa alla produkter
* L�gg till ny produkt
* Uppdatera produkt
* Ta bort produkt
* S�k produkter
* Avsluta

#### Alternativ 1: Visa alla produkter:
Anropar ShowAllProducts() som h�mtar och visar alla produkter via IProductFacade.GetAllProductsAsync().

#### Alternativ 2: L�gg till ny produkt:
Anropar AddProduct() som samlar in produktinformation fr�n anv�ndaren och skapar en ny produkt via IProductFacade.CreateProductAsync().

#### Alternativ 3: Uppdatera produkt:
Anropar UpdateProduct() som l�ter anv�ndaren uppdatera en produkt via IProductFacade.GetProductByIdAsync(id) och IProductFacade.UpdateProductAsync().

#### Alternativ 4: Ta bort produkt:
Anropar DeleteProduct() som tar bort en produkt via IProductFacade.GetProductByIdAsync(id) och IProductFacade.DeleteProductAsync().

#### Alternativ 5: S�k produkter (kommenterad kod, kan implementeras i framtiden):
Anropar SearchProducts() som skulle s�ka efter produkter via IProductFacade.Search().

#### Alternativ 6: Avsluta:
Avslutar programmet via Environment.Exit(0).

### Task 5.1.1: Beskriv projektets syfte och funktioner

#### Syfte 
Henriks Hobby Lager �r ett lagerhanteringssystem f�r hobbyprodukter.
Projektet syftar till att hj�lpa Henrik att organisera och hantera sina produkter.

#### Funktioner
*  Visa produkter: En lista �ver alla produkter i lagret kan h�mtas och visas i konsolen.
L�gg till ny produkt: Anv�ndaren kan l�gga till en ny produkt genom att ange namn, pris, lagerm�ngd, och kategori.

* Uppdatera produkt: En befintlig produkt kan uppdateras med ny information. Anv�ndaren kan �ndra valfria egenskaper.

* Ta bort produkt: Anv�ndaren kan ta bort en produkt fr�n lagret permanent.

* S�kning av produkt:
S�k produkter baserat p� namn eller kategori. Programmet s�ker oberoende av versaler eller gemener och returnerar alla matchande produkter.

Programmet anv�nder en SQLite-databas f�r att lagra produktinformation. Det finns en konsolmeny som guidar anv�ndaren genom olika operationer. Validering �r inbyggd f�r att s�kerst�lla korrekt input.
5. 
Programmet anv�nder Dependency Injection (DI), f�r att skapa l�st kopplade komponenter som �r l�ttare att testa, �teranv�nda och underh�lla. Tj�nster som IProductFacade och IRepository<Product> injiceras automatiskt vid behov.