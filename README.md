Projektbeskrivning  Restaurangguide
Restaurangguide är ett webbaserat system som riktar sig till både invånare och besökare i Göteborg. Projektets syfte är att göra det enkelt att hitta och läsa om olika restauranger i staden både välkända och mindre kända restauranger. Till skillnad från stora, anonyma recensionssajter bygger denna plattform på en lokal, personlig användarupplevelse med fokus på Göteborgs restaurangscen.
Projektets struktur
API:t har färdiga CRUD-funktioner (Create, Read, Update, Delete) som är tillgängliga för administratörer. Det innebär att en admin kan:
Lägga till nya restauranger


Uppdatera befintlig information


Radera restauranger som inte längre är aktuella


B. MVC-projekt (Restaurangguider) ops!!! både API som är Resturang Omdome och MVC projektet mvc måste köras samtidigt för att det ska kunna fungera API i hemsidan 
Detta är den del användarna möter – ett webbgränssnitt där man kan: 
Se restaurangens namn, bild och pris
Läsa beskrivningar
Se mer info i video 
Teknik och programmering
Projektet bygger på moderna tekniker:
Programmeringsspråk: C#


Ramverk: ASP.NET Core MVC och ASP.NET Web API


Databas: SQLite


Datautbyte: JSON-format


Kommunikation mellan MVC och API: HTTP-anrop via HttpClient
Så fungerar systemet så
Administratören loggar in med användarnamn (restaurang@gudien.se) och ett lösenord (Admin123) och kan därefter använda API:ts CRUD-funktioner för att lägga till, redigera eller ta bort restauranger.
MVC-applikationen skickar en HTTP-förfrågan till API:t för att hämta restauranginformationen.
Användaren ser restaurangerna i ett enkelt och visuellt gränssnitt med namn, bild och pris.
Vad som lagras i databasen
I API-projektets databas lagras följande information:
Restauranger: Namn, bildlänk, beskrivning


Omdömen (om funktionen aktiveras i framtiden): Text, tidpunkt, restaurangID
Framtida utvecklingsmöjligheter
Det finns god potential att vidareutveckla Restaurangguide med fler funktioner, exempelvis:
Betygsystem där användare kan ge stjärnor


Filtrering av restauranger baserat på stadsdel eller prisklass


Sortering efter högsta betyg eller flest omdömen


Inloggning för användare för att spara favoritrestauranger eller tidigare omdömen


