namespace tdd_inlamning_1.Models
{
    /// <summary>
    /// Geometric shape: Circle, round shape
    /// </summary>
    public class Circle : GeometricThing
    {
        public override float A { get; set; }
        public override float B { get; set; }

        /// <summary>
        /// A new circle
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        public Circle(float radius)
        {
            A = radius;
            B = radius * 2;
        }

        public override float GetArea()
        {
            return (float)(A * A * 3.14);
        }

        public override float GetPerimeter()
        {
            return (float)(B * 3.14);
        }
    }
}
