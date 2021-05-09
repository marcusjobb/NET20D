using System;

namespace GeometriTest
{
    /// <summary>
    /// Klass som ärver av GeometricThing, representerar en rätvinklig triangel använder sig av phytagoras sats för att
    /// räkna ut omkretsen.
    /// </summary>
    public class Triangle : GeometricThing
    {
        public float Base { get; set; }
        public float Height { get; set; }

        public override float Area()
        {
            return Base * Height / 2;
        }

        public override float Perimeter()
        {
            if (Base < 0) { Base *= -1; }
            if (Height < 0) { Height *= -1; }
            // fick konstiga tal när jag inte konverterade till plus, ingen aning varför...

            float hypotenuse = (float)Math.Sqrt((Base * Base) + (Height * Height));
            
            return hypotenuse + Base + Height;
        }
    }
}