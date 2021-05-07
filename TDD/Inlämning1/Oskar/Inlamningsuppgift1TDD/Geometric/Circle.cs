namespace Inlamningsuppgift1TDD.Geometric
{
    using System;
    public class Circle : IGeometric
    {
        public float Radius { get; set; }

        public Circle(float radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Calculates the Area of the Circle.
        /// </summary>
        /// <returns>Area as float value</returns>
        public float GetArea()
        {
            return Radius * Radius * MathF.PI;
        }

        /// <summary>
        /// Calculates the Perimeter of the Cricle
        /// </summary>
        /// <returns>Perimeter as float value</returns.>
        public float GetPerimeter()
        {
            return 2 * MathF.PI * Radius;
        }
    }
}
