namespace GeometryProject.GeoModels.Triangles
{
    using System;

    public class EquailateralTriangle : GeometricThing
    {
        /// <summary>
        /// Length property for side of triangle.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Triangle constructor.
        /// </summary>
        /// <param name="side">Sets the length of triangle side.</param>
        public EquailateralTriangle(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Gets the area of Triangle and preventing crashes.
        /// </summary>
        /// <returns>Area of Triangle</returns>
        public override float GetArea()
        {
            var hight = MathF.Round(MathF.Sqrt(MathF.Pow(Side, 2) - MathF.Pow(Side / 2, 2)), 2);
            Area = MathF.Round(((Side * hight) / 2), 2);
            return Area > 0 && Side > 0 && Side <= float.MaxValue && Area <= float.MaxValue ? Area : default;
        }

        /// <summary>
        /// Gets the perimeter of Triangle and preventing crashes.
        /// </summary>
        /// <returns>Perimeter of Triangle</returns>
        public override float GetPerimeter()
        {
            Perimeter = MathF.Round(Side * 3);
            return Perimeter > 0 && Side > 0 && Side <= float.MaxValue && Perimeter <= float.MaxValue ? Perimeter : default;
        }
    }
}