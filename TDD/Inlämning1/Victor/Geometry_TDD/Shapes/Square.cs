using System;

namespace Geometry_TDD.Shapes
{
    /// <summary>
    /// Object class. Implements IShape interface.
    /// </summary>
    public class Square : IShape
    {
        public float Side { get; set; }

        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Calculates area of a Square object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Area()
        {
            float area = Side * Side;
            return MathF.Round(area);
        }

        /// <summary>
        /// Calculates perimeter of a Square object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Perimeter()
        {
            float perimeter = Side * 4;
            return MathF.Round(perimeter);
        }
    }
}