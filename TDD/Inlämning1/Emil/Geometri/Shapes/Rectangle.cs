using Geometri.Interface;
using System;

namespace Geometri.Shapes
{
    /// <summary>
    /// Defines a Rectangle.
    /// </summary>
    public class Rectangle : IGeometricThing
    {
        /// <summary>
        /// Gets and sets Height.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Gets and sets Width.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Constructor for a rectangle.
        /// </summary>
        /// <param name="height">sets the height</param>
        /// <param name="width">sets the width</param>
        public Rectangle(float height, float width)
        {
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Calculates the Area of a Rectangle.
        /// </summary>
        /// <returns>float Area</returns>
        public float Area()
        {
            if (Height <= 0 || Width <= 0) return 0;

            var calc = Height * Width;
            return MathF.Round(calc, 2);
        }

        /// <summary>
        /// Calculates the Perimeter of a Rectangle.
        /// </summary>
        /// <returns>float Perimeter</returns>
        public float Perimeter()
        {
            if (Height <= 0 || Width <= 0) return 0;

            var calc = (Height * 2) + (Width * 2);
            return MathF.Round(calc, 2);
        }
    }
}