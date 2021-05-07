# Inlämningsuppgift 1
## *Testplanering*

Uppgiften i sin enkelhet går ut på skapa geometriska (2D) klasser där 
det går att räkna ut area och omkrets. 

Exempel på geometriska former: 
- Cirklar
  - Ellipser
- Trianglar 
  - rätvinkliga
  - likbenta
  - liksidiga
- Kvadrater
- rektanglar

## Krav

- Klass för geometriska kalkyler
  - ```GeometricCalculator```
  - Samtliga beräkningar ska använda ```float```
- Klass för varje geometriskt object
  - T.ex. ```Triangle```eller ```Square```
  - Gärna interface såsom ```iShape``` (frivilligt)
- Tester som testar att programmet håller för Positiva och negativa tester
- Koden (inkl. testkod) skall dokumenteras i XML-format

### Planering för utförande

- Börja med geometri-formerna. Först iShape för att säkerställa att ingen
kod missas. 
- Sedan basklassen ```GeometricThing```, sedan klasser såsom
	- ```Ellipse```
	- ```Rectangle```
    - ```Triangle``` 
      - ```Circle``` är en ellips med r1 = r2
      - ```Square``` är en rektangel med s1 = s2
      - ```Triangle``` får jag fundera lite över, hur man gör en 
      klass som kan lösa alla sorters trianglar. Jag funderade över att 
      låta användaren ange tre sidor, fast med största sannolikhet 
      kommer det in gå eftersom det är alldeles för lätt att ange 
      ogilitiga sidor. Kanske lättast som enligt uppgiften att nöja 
      sig med bas + höjd. Kanske att användaren får ange två sidor + v
      vinkel a, och att programmet räknar ut den tredje, sedan använder 
      sinus-satsen för att få ut vinklar, area.
      - Sinussatsen: sin(A) / a = sin (B) / b = sin (C) / c

### Planering för tester
- Alla klasser ska testas
- Både giltiga och ogiltiga inputs för testerna samt extremvärden.
- Exempel att inputs till klasserna är följande värden
  - ```float.MaxValue```
  - ```float.Minvalue```
  - ```1``` 
  - ```-1``` 
  - ```float.NaN``` 
  - ```0```