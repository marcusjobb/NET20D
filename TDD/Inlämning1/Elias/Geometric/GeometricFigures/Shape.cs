namespace Geometric.Figures
{
    public abstract class Shape
    {
        /// <summary>
        /// Calculates the area of a shape.
        /// </summary>
        /// <returns>The area of the shape.</returns>
        public abstract float GetArea();

        /// <summary>
        /// Calculates the perimeter of a shape.
        /// </summary>
        /// <returns>The perimeter of the shape.</returns>
        public abstract float GetPerimeter();
    }
}