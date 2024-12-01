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