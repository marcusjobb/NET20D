namespace Geometric.Figures
{
    using System;

    public class Circle : Shape
    {
        public Circle(float radius)
        {
            Radius = radius;
        }

        public float Radius { get; set; }

        /// <summary>
        /// Calculates the area of the circle.
        /// </summary>
        /// <returns>The circle's area.</returns>
        public override float GetArea()
        {
            return (float)Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Calculates the perimeter of the circle.
        /// </summary>
        /// <returns>The circle's perimeter.</returns>
        public override float GetPerimeter()
        {
            return 2 * (float)Math.PI * Radius;
        }
    }
}