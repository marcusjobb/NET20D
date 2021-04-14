# Planering

## Vad behövs?
Interface/Abstrakt klass med Radie och Omkrets
Varje objekt ska implementera metoderna
* Kvadrat
  * constructor som sätter parametrar
  * public float GetPerimeter();
  * public float GetArea();
* Rektangel
  * constructor som sätter parametrar
  * public float GetPerimeter();
  * public float GetArea();
* Liksidig triangel
  * constructor som sätter parametrar
  * public float GetPerimeter();
  * public float GetArea();
* Cirkel
  * constructor som sätter parametrar
  * public float GetPerimeter();
  * public float GetArea();

GeometricCalculator()
* GetPerimeter[] -- Måste testas
(alt GetArea[])
---

## Test
* GetPerimeter[]/GetArea[] ska testas med alla typer av objekt
- Skicka in en mängd objekt och det förväntade resultatet är den sammanlagda omkretsen för alla

Alternativt

* Testa var objekt för sig

### Avrundning
Bästa sättet att implementera det?

Ett snyggt alternativ är : Math.Abs(value1 - value2) < 0.00001;

Ett fult alternativ är : ((int)value\*1000)==((int)value2\*1000)

