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