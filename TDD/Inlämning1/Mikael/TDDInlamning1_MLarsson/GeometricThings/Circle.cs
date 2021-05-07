namespace TDDInlamning1_MLarsson.GeometricThings
{
    using System;
    /// <summary>
    /// Class to handle the circle object.
    /// </summary>
    public class Circle : GeometricThing
    {
        public Circle(float radius)
        {
            this.Radius = radius;
        }

        public float Radius { get; set; }

        public override float GetArea()
        {
            return Radius <= 0 ? 0 : Area = MathF.Pow(Radius, 2) * MathF.PI;
        }

        public override float GetPerimeter()
        {
            return Radius < 0 ? 0 : Perimeter = Radius * 2 * MathF.PI;
        }
    }
}
