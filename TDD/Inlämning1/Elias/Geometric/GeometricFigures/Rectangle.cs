namespace Geometric.Figures
{
    public class Rectangle : Shape
    {
        public Rectangle(float height, float rBase)
        {
            Height = height;
            RBase = rBase;
        }

        public float Height { get; set; }
        public float RBase { get; set; }

        /// <summary>
        /// Calculates the area of the rectangle.
        /// </summary>
        /// <returns>The rectangle's area.</returns>
        public override float GetArea()
        {
            return RBase * Height;
        }

        /// <summary>
        /// Calculates the perimeter of the rectangle.
        /// </summary>
        /// <returns>The rectangle's perimeter.</returns>
        public override float GetPerimeter()
        {
            return (RBase * 2) + (Height * 2);
        }
    }
}