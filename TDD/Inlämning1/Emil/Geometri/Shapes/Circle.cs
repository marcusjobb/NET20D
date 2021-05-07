using Geometri.Interface;
using System;

namespace Geometri.Shapes
{
    /// <summary>
    /// Defines a Circle
    /// </summary>
    public class Circle : IGeometricThing
    {
        /// <summary>
        /// Gets and sets radius.
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Constructor for a circle.
        /// </summary>
        /// <param name="radius"> sets the radius of a circle</param>
        public Circle(float radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Calculates the Area of a Circle.
        /// </summary>
        /// <returns>float Area</returns>
        public float Area()
        {
            if (Radius < 0) return 0;
            var calc = MathF.PI * Radius * Radius;
            return MathF.Round(calc, 2);
        }

        /// <summary>
        /// Calculates the Perimeter of a Circle.
        /// </summary>
        /// <returns>float Perimeter</returns>
        public float Perimeter()
        {
            if (Radius < 0) return 0;
            var calc = (2 * MathF.PI) * Radius;
            return MathF.Round(calc, 2);
        }
    }
}
