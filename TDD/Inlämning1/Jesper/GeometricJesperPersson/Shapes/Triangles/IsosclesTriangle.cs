using System;

namespace GeometricJesperPersson.Shapes.Triangles
{
    public class IsosclesTriangle : GeometricThing // likbent
    {
        /// <summary>
        /// Set the triangle's sides to the same as the input when instancing the object.
        /// </summary>
        /// <param name="theBase">sieze in meter of the triangles base.</param>
        /// <param name="isoscelesSides">sieze in meter of the triangles two other sides.</param>
        public IsosclesTriangle(float theBase, float isoscelesSides)
        {
            Base = theBase;
            IsosclesSides = isoscelesSides;
        }

        public float Base { set; get; }
        public float IsosclesSides { set; get; }
        /// <summary>
        /// Calculate the area of the triangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The area of the triangle. 0 if fails.</returns>
        public override float GetArea() => IsSizeOkForArea() ? GetHeight() * Base / 2 : default;

        /// <summary>
        /// Calculate the perimeter of the triangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The perimeter of the triangle. 0 if fails.</returns>
        public override float GetPerimeter() => IsSizeOkForPerimeter() ? Base + (IsosclesSides * 2) : default;

        // using pythagyras to calculate the height.
        private float GetHeight() => MathF.Sqrt(MathF.Pow(IsosclesSides, 2) - MathF.Pow(Base / 2, 2));

        private bool IsSizeOkForArea() => GetHeight() * Base / 2 < float.MaxValue && Base >= 0 && IsosclesSides >= 0;

        private bool IsSizeOkForPerimeter() => Base + (IsosclesSides * 2) < float.MaxValue && Base >= 0 && IsosclesSides >= 0;
    }
}