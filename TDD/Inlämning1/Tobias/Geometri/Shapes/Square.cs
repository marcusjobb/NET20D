using Geometri.Interfaces;
using System;

namespace Geometri.Shapes
{
    /// <summary>
    /// Defines a Square
    /// </summary>
    public class Square : IGeometricThing
    {
        /// <summary>
        /// Gets and sets Side
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Constructor for a Square
        /// </summary>
        /// <param name="side">Sets the side</param>
        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Calculates the Area of a Square
        /// </summary>
        /// <returns>float area</returns>
        public float Area()
        {
            if (Side <= 0) return 0;

            var calc = Side * Side;
            return MathF.Round(calc, 2);
        }

        /// <summary>
        /// Calculates the Perimeter of a Square
        /// </summary>
        /// <returns>float area</returns>
        public float Perimeter()
        {
            if (Side <= 0) return 0;

            var calc = Side * 4;
            return MathF.Round(calc, 2);
        }
    }
}