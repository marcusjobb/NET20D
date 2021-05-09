namespace Geometric.Figures
{
    public class Triangle : Shape
    {
        public Triangle(float height, float tBase)
        {
            Height = height;
            TBase = tBase;
        }

        public float Height { get; set; }
        public float TBase { get; set; }

        /// <summary>
        /// Calculates the area of the triangle.
        /// </summary>
        /// <returns>The triangle's area.</returns>
        public override float GetArea()
        {
            return (TBase * Height) / 2;
        }

        /// <summary>
        /// Calculates the perimeter of the triangle.
        /// </summary>
        /// <returns>The triangle's perimeter.</returns>
        public override float GetPerimeter()
        {
            return TBase * 3;
        }
    }
}