using ConsoleApp3.Interfaces;
using System;

namespace ConsoleApp3.Shapes
{
    public class Circle : IGeometricThing
    {
        public float Radius { get; set; }

        public Circle(float radius)
        {
            Radius = radius;
        }

        public float Area()
        {
            if (Radius <= 0)
            {
                return 0f;
            }
            return MathF.PI * Radius * Radius;
        }

        public float Perimeter()
        {
            if (Radius <= 0)
            {
                return 0f;
            }
            return MathF.PI * 2 * Radius;
        }
    }
}