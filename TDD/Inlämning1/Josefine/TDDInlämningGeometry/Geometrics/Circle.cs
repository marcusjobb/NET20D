using System;
using TDDInlämningGeometry.Geometrics;

namespace Geometrics
{
    public class Circle : IGeometricThing
    {
        /// <summary>
        /// Constructor for a circle with radius
        /// </summary>
        /// <param name="radius"></param>
        public Circle(float radius)
        {
            this.Radius = radius;
        }

        public float Radius { get; set; }

        public float GetArea()
        {
            if (Radius <= 0) { return 0; }
            return MathF.Pow(Radius, 2) * MathF.PI;
        }

        public float GetPerimeter()
        {
            if (Radius <= 0) { return 0; }
            return Radius * 2 * MathF.PI;
        }
    }
}