using System;
using System.Collections.Generic;
using System.Text;

namespace GeometriTDD.Geometry
{
    /// <summary>
    /// Klass som räknar ut arean och omkretsen av en kvadrat, ärver ifrån GeometricThing
    /// </summary>
    public class Square : GeometricThing
    {
        public float Side { get; set; }

        public Square(float side)
        {
            Side = side;
        }

        public override float GetArea()
        {
            if (Side > 0)
            {
                return Side * Side;
            }
            else return 0;
        }

        public override float GetPerimeter()
        {
            if (Side > 0)
            {
                return Side * 4;
            }
            else return 0;
        }
    }
}
