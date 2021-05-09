namespace Geometric.Figures
{
    public class Square : Shape
    {
        public Square(float side)
        {
            Side = side;
        }

        public float Side { get; set; }

        /// <summary>
        /// Calculates the area of the square.
        /// </summary>
        /// <returns>The square's area.</returns>
        public override float GetArea()
        {
            return Side * Side;
        }

        /// <summary>
        /// Calculates the perimeter of the square.
        /// </summary>
        /// <returns>The square's perimeter.</returns>
        public override float GetPerimeter()
        {
            return Side * 4;
        }
    }
}