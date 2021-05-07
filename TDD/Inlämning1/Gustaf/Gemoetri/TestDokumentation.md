# Testdokumentation

### Tester som utf�rts
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
Testerna har allts� g�tt ut p� att pr�va olika extremv�rden, och se
hur programmet hanterar detta.
Testprogrammet har skapat upp objekt (circle, ellipse, rectangle, 
triangle, square) utifr�n ovanst�ende testv�rden som alla �r giltiga
float-variabler.

Eftersom vi vet att en sida p� en geometrisk figur, en radie �r m�tbara
str�ckor.
D� g�ller att dessa str�ckor m�ste vara st�rre �n 0 och d�rmed 
kan den inte vara negativa. Detta inneb�r ocks� att en area eller en 
omkrets inte heller kan vara negativa, och m�ste d�rf�r vara st�rre �n 

F�r att hantera s� kallade ogiltiga inputs som programmet inte kan 
hantera valde jag att s�tta sidan till ```1.0f``` d�r en ogiltig input
har angetts.

Begr�nsningarna i programmet blir allts� som f�ljande:
input m�ste vara st�rre �n 0.0f och mindre �n MathF.Sqrt(float.MaxValue).
Anledningen till att det b�r vara mindre �n MathF.Sqrt(float.Maxvalue) �r
att programmet m�ste lyckas med s�dana utr�kningar som r�r sig n�ra 
maxv�rdet.



