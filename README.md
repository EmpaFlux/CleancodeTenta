﻿# Tentamen i Clean code och testbar kod

- Datum: 2021-01-21
- Program: C#-utvecklare
- Lärare: David Sundelius

## Introduktion
Vi har ett system som idag läser en lista på filmer från en json-fil på internet (https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json). Den innehåller titel, id och IMDB-ranking på filerna. Tjänsten som vi utvecklar har två stycken endpoints:
En som returnerar en lista på alla filmers titlar, ordnad efter ranking (stigande eller fallande)
En som returnerar all information vi har om en specifik film utifrån dess id.

## Uppgift
Din uppgift är nu att refaktorera programmet enligt de principer vi gått igenom i kursen. När uppgiften är färdig så ska programmet uppfylla följande egenskaper:
Koden är läsbar och tydlig i enlighet med Clean code-principer.
- Logiken i programmet, såsom sorteringen, är enhetstestad.
- Programmet ska innehålla en rimlig nivå av felhantering, användaren ska få rimliga meddelanden om något är fel.
- Programmet ska innehålla ett motiverat designmönster.
- Koden ska inte innehålla buggen (något som avviker från beskrivningen ovan) som finns i programmet från början.

Utöver detta ska du bygga ut programmet med en ny funktion. Detta är att läsa in data från ytterligare en endpoint (https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json). Denna data ska slås ihop med datan vi redan har och kunna presenteras på samma sätt. Det ska inte förekomma dubbletter av filmer i listan och den ska gå att sortera på samma villkor.

## Hjälpmedel
Alla hjälpmedel är tillåtna: internet, böcker, egenskrivet material och tidigare labbar/annan kod är godkänt exempelvis. Det enda ni inte får göra är att kommunicera med en annan människa under tentans gång, det inkluderar bland annat fysiska personer, telefon och chat.

## Redovisning
Källkoden ska vara pushad till ett eget publikt repository på GitHub. Ert fullständiga namn, samt en *kort* reflektion över dina arkitekturella val, såsom:

- Vad du valt att testa och varför?
- Vilket/vilka designmönster har du valt, varför? Hade det gått att göra på ett annat sätt?
- Hur mycket valde du att optimera koden, varför är det en rimlig nivå för vårt program?

ska finnas med i README.md i repots main-branch (master).


//

Har bara valt att testa grundläggande sortering och sökfunktion.
Då det är två olika delar som ska kopplas samman och slås ihop för att kunna ge den lista som behövs i specifikationen, och programmet behöver deserialisera json till användbara listor så skulle jag vilja hävda att den använder sig av adapter pattern för det. Kanske är det inte i sin renaste form (då det egentligen oftast haterar interfaces som ska kunna prata med varandra), men
programmet ändrar om data för att passa in där den behövs i slutändan på ett sätt som efterliknar mänstret för adapter.  https://code-maze.com/adapter/
Koden är nu strukturerad i betydligt fler separata filer och skulle antagligen bidra för enkel vidare integration, då det tex underlättar för modularitet om tex Docker skulle implementeras. Kod hålls separerad till funktioner kring ett specifikt område och finktioner ska egentligen bara göra en sak, samt att de över lag är nerbantade i storlek. Clean Code s.34+

