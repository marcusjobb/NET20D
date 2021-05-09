using System;
using Geometry.Abstracts;

namespace Geometry.GeometricThings
{
    public class Circle : GeometricThing
    {
        /// <summary>
        /// The Radius of the circle.
        /// </summary>
        public float Radius { get; set; }

        public override float Area()
        {
            if (Radius < 0) return 0;
            return (MathF.PI * MathF.Pow(Radius, 2));
        }

        public override float Perimiter()
        {
            if (Radius < 0) return 0;
            return 2 * MathF.PI * Radius;
        }
    }
}
