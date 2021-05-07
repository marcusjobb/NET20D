using System;
using System.Collections.Generic;
using System.Text;

namespace GeometriTDD.Geometry
{
    /// <summary>
    /// Klass som räknar ut arean och omkretsen av en rektangel, ärver ifrån GeometricThing
    /// </summary>
    public class Rectangle : GeometricThing
    {
        public float Bas { get; set; }
        public float Height { get; set; }

        public Rectangle(float bas, float height)
        {
            Bas = bas;
            Height = height;
        }

        public override float GetArea()
        {
            if (Bas > 0 && Height > 0)
            {
                return Bas * Height;
            }
            return 0;
        }

        public override float GetPerimeter()
        {
            if (Bas > 0 && Height > 0)
            {
                return Bas + Bas + Height + Height;
            }
            return 0;
        }
    }
}
