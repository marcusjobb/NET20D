using System;

namespace GeometricJesperPersson.Shapes.Triangles
{
    public class EquilateralTriangle : GeometricThing
    {
        /// <summary>
        /// Set the triangle's sides to the same as the input when instancing the object.
        /// </summary>
        /// <param name="side">sieze in meter of the triangles sides.</param>
        public EquilateralTriangle(float side)
        {
            SidesOfTriangle = side;
        }

        public float SidesOfTriangle { set; get; }
        /// <summary>
        /// Calculate the area of the triangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The area of the triangle. 0 if fails.</returns>
        public override float GetArea() => IsSizeOkForArea() ? GetHeight() * SidesOfTriangle / 2 : default;

        /// <summary>
        /// Calculate the perimeter of the triangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The perimeter of the triangle. 0 if fails.</returns>
        public override float GetPerimeter() => IsSizeOkForPerimeter() ? SidesOfTriangle * 3 : default;

        // using pythagyras to calculate the height.
        private float GetHeight() => MathF.Sqrt(MathF.Pow(SidesOfTriangle, 2) - MathF.Pow(SidesOfTriangle / 2, 2));

        private bool IsSizeOkForArea() => GetHeight() * SidesOfTriangle / 2 < float.MaxValue && SidesOfTriangle >= 0;

        private bool IsSizeOkForPerimeter() => SidesOfTriangle * 3 < float.MaxValue && SidesOfTriangle >= 0;
    }
}