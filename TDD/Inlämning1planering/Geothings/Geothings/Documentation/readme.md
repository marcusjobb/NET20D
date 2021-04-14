# Testplanering

## GeometricCalulator
* Testa GetPerimeter[]
* Testa GetArea[]

## Square
* Testa GetPerimeter
* Testa GetArea
* Testa constructorn (om den gör beräkningar)

### Vilken väg?
Ska man testa GetPerimeter[] och skicka in ett objekt av var sort
eller ska man testa GetPerimeter[] och sedan testa var objekt för sig?

## Testförslag
1. Skicka in null objekt
2. Skicka in objekt med noll på alla värden
3. Skicka in objekt med minusvärden
4. Skicka in vettig data

## Förberedelse
Då vi arbetar med decimaler är det svårt att jämföra exakt, 
lösningen är att antingen kräva exakt värde (ex vid forskning, pengar mm) eller
avrunda.

## Dokmentation
Testscenarios för varje objekt eller för Calculatorklassen
Testcases beroende på vad som testas
