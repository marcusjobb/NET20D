namespace Inlamningsuppgift1TDD.Geometric
{
    public class Rectangle : IGeometric
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Calculates the Area of the rectangle
        /// </summary>
        /// <returns>Area as type float</returns>
        public float GetArea()
        {
            return Width * Height;
        }

        /// <summary>
        /// Calculates the Perimetr of the rectangle
        /// </summary>
        /// <returns>Perimeter as type float</returns>
        public float GetPerimeter()
        {
            return 2 * (Width + Height);
        }
    }
}
