using System;
using System.Collections.Generic;
using System.Text;

namespace GeometriTDD.Geometry
{
    /// <summary>
    /// Klass som räknar ut arean och omkretsen av en triangel, ärver ifrån GeometricThing.
    /// Bestämde mig för att bara ha denna metod för att räkna ut liksidiga trianglar, kan fokusera mer på tester i sådanna fall.
    /// </summary>
    public class Triangle : GeometricThing
    {
        public float Side { get; set; }

        public Triangle(float side)
        {
            Side = side;
        }

        public override float GetArea()
        {
            if (Side > 0)
            {
                return Side * Side / 2;
            }
            return 0;
        }

        public override float GetPerimeter()
        {
            if (Side > 0)
            {
                return Side * 3;
            }
            return 0;
        }
    }
}
