using System;

namespace Geometry_TDD.Shapes
{
    /// <summary>
    /// Object class. Implements IShape interface.
    /// </summary>
    public class Triangle : IShape
    {
        public float Base { get; set; }
        public float Height { get; set; }

        public Triangle(float tbase, float height)
        {
            Base = tbase;
            Height = height;
        }

        /// <summary>
        /// Calculates area of a Triangle object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Area()
        {
            float area = (Base * Height) / 2;
            return MathF.Round(area);
        }

        /// <summary>
        /// Calculates perimeter of a Triangle object. Result is rounded to nearest whole number.
        /// </summary>
        /// <returns>float</returns>
        public float Perimeter()
        {
            float perimeter = Base * 3;
            return MathF.Round(perimeter);
        }
    }
}