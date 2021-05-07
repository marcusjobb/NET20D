using System;

namespace tdd_inlamning_1.Models
{
    /// <summary>
    /// Geometric shape: Triangle, the shape may be one of three types of triangle.
    /// </summary>
    public class Triangle : GeometricThing
    {
        public override float A { get; set; }
        public override float B { get; set; }
        public float C { get; set; }

        /// <summary>
        /// New triangle
        /// </summary>
        /// <param name="katetA">The width (base) of the triangle</param>
        /// <param name="katetB">The height from the width to the top of the geometric shape</param>
        /// <param name="hypotenusa">The length between width (end of) and height (start of)</param>
        public Triangle(float katetA, float katetB, float hypotenuse)
        {
            A = katetA;
            B = katetB;

            if (A > 0 && B > 0 && hypotenuse == 0)
            {
                C = GetHypotenuse();
            }
            else
            {
                C = hypotenuse;
            }
        }

        private float GetHypotenuse()
        {
            if (C > 0)
                return C;
            return (float)Math.Sqrt(Math.Pow(A, 2) + Math.Pow(B, 2));
        }

        public override float GetArea()
        {
            return A * B / 2;
        }

        public override float GetPerimeter()
        {
            return A + B + C;
        }
    }
}
