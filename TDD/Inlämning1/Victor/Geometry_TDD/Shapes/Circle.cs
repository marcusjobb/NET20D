using System;

namespace Geometry_TDD.Shapes
{
    /// <summary>
    /// Object class. Implements IShape interface.
    /// </summary>
    public class Circle : IShape
    {
        public float Radius { get; set; }

        public Circle(float radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculates area of a Circle object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Area()
        {
            float area = MathF.PI * Radius * Radius;
            return MathF.Round(area);
        }

        /// <summary>
        /// Calculates perimeter of a Circle object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Perimeter()
        {
            float perimeter = 2 * MathF.PI * Radius;
            return MathF.Round(perimeter);
        }
    }
}