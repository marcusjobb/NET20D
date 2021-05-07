namespace Geometri.GeometricObjects
{
    public class Circle : Ellipse
    {
        /// <summary>
        /// Circle is an ellipse with the two radii being the same.
        /// </summary>
        /// <param name="r1"></param>
        public Circle(float r1) : base(r1, r1)
        { }
    }
}
