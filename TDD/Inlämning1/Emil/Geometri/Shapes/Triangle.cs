using Geometri.Interface;
using System;

namespace Geometri.Shapes
{
    /// <summary>
    /// Defines a triangle.
    /// </summary>
    public class Triangle : IGeometricThing
    {
        /// <summary>
        /// Gets and sets the Side.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Constructor for a Triangle.
        /// </summary>
        /// <param name="side">Sets the side</param>
        public Triangle(float side)
        {
            this.Side = side;
        }

        /// <summary>
        /// Calculates the Area of a Triangle.
        /// </summary>
        /// <returns>float Area</returns>
        public float Area()
        {
            if (Side <= 0) return 0;
            var calc = ((Side * Side) * (MathF.Sqrt(3)) / 4);
            return MathF.Round(calc, 2);
        }

        /// <summary>
        /// Calculates the Perimeter of a Triangle.
        /// </summary>
        /// <returns>float Perimeter</returns>
        public float Perimeter()
        {
            if (Side <= 0) return 0;
            var calc = Side * 3;
            return MathF.Round(calc, 2);
        }
    }
}