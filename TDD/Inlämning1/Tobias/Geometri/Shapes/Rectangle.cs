using Geometri.Interfaces;
using System;

namespace Geometri.Shapes
{
    /// <summary>
    /// Defines a rectangle
    /// </summary>
    public class Rectangle : IGeometricThing
    {
        /// <summary>
        /// Gets and sets Heigth
        /// </summary>
        public float Heigth { get; set; }

        /// <summary>
        /// Gets and sets Width
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Constructor for a rectangel
        /// </summary>
        /// <param name="heigth">sets the heigth</param>
        /// <param name="width">sets the width</param>
        public Rectangle(float heigth, float width)
        {
            Heigth = heigth;
            Width = width;
        }

        /// <summary>
        /// Calculates the Area of a rectangel
        /// </summary>
        /// <returns>float area</returns>
        public float Area()
        {
            if (Heigth <= 0 || Width <= 0) return 0;
            var calc = Heigth * Width;
            return MathF.Round(calc, 2);
        }

        /// <summary>
        /// Calculates the Perimeter of a rectangel
        /// </summary>
        /// <returns>float Perimeter</returns>
        public float Perimeter()
        {
            if (Heigth <= 0 || Width <= 0) return 0;
            var calc = (Width * 2) + (Heigth * 2);
            return MathF.Round(calc, 2);
        }
    }
}