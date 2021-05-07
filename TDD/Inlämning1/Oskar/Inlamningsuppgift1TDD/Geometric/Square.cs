namespace Inlamningsuppgift1TDD.Geometric
{
    public class Square : IGeometric
    {
        public float SideLength { get; set; }

        public Square(float sideLength)
        {
            SideLength = sideLength;
        }

        /// <summary>
        /// Calculates the Area of the Square
        /// </summary>
        /// <returns>Area as type float</returns>
        public float GetArea()
        {
            return SideLength * SideLength;
        }

        /// <summary>
        /// Calculates the Perimeter of the Square
        /// </summary>
        /// <returns>Perimeter as type float</returns>
        public float GetPerimeter()
        {
            return 4 * SideLength;
        }
    }
}
