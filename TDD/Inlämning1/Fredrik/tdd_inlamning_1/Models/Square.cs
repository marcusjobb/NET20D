namespace tdd_inlamning_1.Models
{
    /// <summary>
    /// Geometric shape: Square, all sides are exactly the same length
    /// </summary>
    public class Square : GeometricThing
    {
        public override float A { get; set; }
        public override float B { get; set; }

        /// <summary>
        /// New square
        /// </summary>
        /// <param name="width">Width of square. Squares are always as wide as they are high, you only enter the width.</param>
        public Square(float width)
        {
            A = width;
            B = A;
        }

        public override float GetArea()
        {
            return A * B;
        }

        public override float GetPerimeter()
        {
            return A + B + A + B;
        }
    }
}
