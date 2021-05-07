namespace GeometryProject
{
    using GeometryProject.GeoModels;
    using System;

    public class Circle : GeometricThing
    {
        /// <summary>
        /// Length property for radius of circle.
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Circle contructor.
        /// </summary>
        /// <param name="radius">Sets the radius of the circle object.</param>
        public Circle(float radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Gets the area of Circle and preventing crashes.
        /// </summary>
        /// <returns>Area of circle</returns>
        public override float GetArea()
        {
            Area = MathF.Round((MathF.Pow(Radius, 2) * MathF.PI), 2);
            return Area > 0 && Radius > 0 && Radius <= float.MaxValue && Area <= float.MaxValue ? Area : default;
        }

        /// <summary>
        /// Gets the area of Circle and preventing crashes.
        /// </summary>
        /// <returns>Area of Circle</returns>
        public override float GetPerimeter()
        {
            Perimeter = MathF.Round((Radius * 2 * MathF.PI), 2);
            return Perimeter > 0 && Radius > 0 && Radius <= float.MaxValue && Perimeter <= float.MaxValue ? Perimeter : default;
        }
    }
}