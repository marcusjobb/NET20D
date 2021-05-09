using System;

namespace AssignmentGeometri
{
    /// <summary>
    /// Class for Square shape.
    /// </summary>
    public class Square : GeometricThing
    {
        public float Side { get; set; }

        public Square(float side)
        {
            Side = side;
        }

        public override float GetArea()
        {
            if (Side <= 0) { return 0; }
            else { return (float)Math.Pow(Side, 2); }
        }

        public override float GetPerimeter()
        {
            if (Side <= 0) { return 0; }
            else { return Side * 4; }
        }
    }
}