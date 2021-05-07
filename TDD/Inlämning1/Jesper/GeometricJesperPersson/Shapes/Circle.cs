namespace GeometricJesperPersson.Shapes
{
    using System;

    public class Circle : GeometricThing
    {
        /// <summary>
        /// Set the circle's radius to the same as the input when instancing the object.
        /// </summary>
        /// <param name="radius">the circle radius in meter.</param>
        public Circle(float radius)
        {
            Radius = radius;
        }

        public float Radius { set; get; }
        /// <summary>
        /// Calculate the area of the circles. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The area in float. 0 if fails.</returns>
        public override float GetArea() => IsSizeOkForArea() ? Radius * Radius * MathF.PI : default;

        /// <summary>
        /// Calculate the perimeter of the rectangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The perimeter in float. 0 if fails.</returns>
        public override float GetPerimeter() => IsSizeOkForPerimeter() ? (Radius * 2 * MathF.PI) : default;

        private bool IsSizeOkForArea() => Radius * Radius * MathF.PI < float.MaxValue && Radius >= 0;
        private bool IsSizeOkForPerimeter() => (Radius * 2 * MathF.PI) < float.MaxValue && Radius >= 0;
    }
}