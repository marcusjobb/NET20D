using Geometri.Interfaces;
using System;

namespace Geometri.Shapes
{
    /// <summary>
    /// Defines a circle
    /// </summary>
    public class Circle : IGeometricThing
    {
        /// <summary>
        /// Gets and sets radius
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Constructor for a circel
        /// </summary>
        /// <param name="radius">sets the radius of a circle</param>
        public Circle(float radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculates the Area of a circle
        /// </summary>
        /// <returns>float area</returns>
        public float Area()
        {
            if (Radius < 0) return 0;
            var calc = MathF.PI * Radius * Radius;
            return MathF.Round(calc, 2);
        }

        /// <summary>
        /// Calculates the Perimeter of a circle
        /// </summary>
        /// <returns>float Perimeter</returns>
        public float Perimeter()
        {
            if (Radius < 0) return 0;
            var calc = 2 * MathF.PI * Radius;
            return MathF.Round(calc, 2);
        }
    }
}