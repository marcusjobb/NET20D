namespace tdd_inlamning_1.Models
{
    /// <summary>
    /// Geometric shape: Rectangle, height or width is longer than the other.
    /// </summary>
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// Width
        /// </summary>
        public override float A { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public override float B { get; set; }

        public Rectangle(float a, float b)
        {
            A = a;
            B = b;
        }

        public override float GetArea()
        {
            return A * B;
        }

        public override float GetPerimeter()
        {
            return (A * 2) + (B * 2);
        }
    }
}
