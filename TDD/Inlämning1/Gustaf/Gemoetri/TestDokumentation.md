# Testdokumentation

### Tester som utförts
        [TestCase(1.0f, 1.0f)]
        [TestCase(1.0f, -1.0f)]
        [TestCase(-1.0f, 1.0f)]
        [TestCase(-1.0f, -1.0f)]
        [TestCase(0.0f, 1.0f)]
        [TestCase(1.0f, 0.0f)]
        [TestCase(0.0f, 0.0f)]
        [TestCase(float.NaN, 1.0f)]
        [TestCase(1.0f, float.NaN)]
        [TestCase(float.NaN, float.NaN)]
        [TestCase(float.MaxValue, 1.0f)]
        [TestCase(1.0f, float.MaxValue)]
        [TestCase(float.MaxValue, -1.0f)]
        [TestCase(-1.0f, float.MaxValue)]
        [TestCase(float.MaxValue, float.MaxValue)]
        [TestCase(float.MaxValue, float.MinValue)]
        [TestCase(float.MinValue, float.MaxValue)]
        [TestCase(float.MinValue, float.MinValue)]
Testerna har alltså gått ut på att pröva olika extremvärden, och se
hur programmet hanterar detta.
Testprogrammet har skapat upp objekt (circle, ellipse, rectangle, 
triangle, square) utifrån ovanstående testvärden som alla är giltiga
float-variabler.

Eftersom vi vet att en sida på en geometrisk figur, en radie är mätbara
sträckor.
Då gäller att dessa sträckor måste vara större än 0 och därmed 
kan den inte vara negativa. Detta innebär också att en area eller en 
omkrets inte heller kan vara negativa, och måste därför vara större än 

För att hantera så kallade ogiltiga inputs som programmet inte kan 
hantera valde jag att sätta sidan till ```1.0f``` där en ogiltig input
har angetts.

Begränsningarna i programmet blir alltså som följande:
input måste vara större än 0.0f och mindre än MathF.Sqrt(float.MaxValue).
Anledningen till att det bör vara mindre än MathF.Sqrt(float.Maxvalue) är
att programmet måste lyckas med sådana uträkningar som rör sig nära 
maxvärdet.



