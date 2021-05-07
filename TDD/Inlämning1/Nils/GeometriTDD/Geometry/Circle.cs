using System;
using System.Collections.Generic;
using System.Text;

namespace GeometriTDD.Geometry
{
    /// <summary>
    /// Klass som räknar ut arean och omkretsen av en cirkel, ärver ifrån GeometricThing
    /// </summary>
    public class Circle : GeometricThing
    {
        public float Radie { get; set; }
        public Circle(float radie)
        {
            Radie = radie;
        }

        public override float GetArea()
        {
            if (Radie > 0)
            {
                return Radie * Radie * 3.1415926535f;
            }
            return 0;
        }

        public override float GetPerimeter()
        {
            if (Radie > 0)
            {
                return (Radie * 2) * 3.1415926535f;
            }
            return 0;
        }
    }
}
