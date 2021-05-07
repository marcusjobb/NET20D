using System;

namespace Geometry_TDD.Shapes
{
    /// <summary>
    /// Object class. Implements IShape interface.
    /// </summary>
    public class Rectangle : IShape
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Calculates area of a Rectangle object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Area()
        {
            float area = Width * Height;
            return MathF.Round(area);
        }

        /// <summary>
        /// Calculates perimeter of a Rectangle object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Perimeter()
        {
            float perimeter = (Width + Height) * 2;
            return MathF.Round(perimeter);
        }
    }
}