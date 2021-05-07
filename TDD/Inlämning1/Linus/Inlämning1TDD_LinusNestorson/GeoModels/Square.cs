namespace GeometryProject.GeoModels
{
    using System;

    public class Square : GeometricThing
    {
        /// <summary>
        /// Side property of Square.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Square constructor.
        /// </summary>
        /// <param name="side"></param>
        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Gets the area of Square and preventing crashes.
        /// </summary>
        /// <returns>Area of Square</returns>
        public override float GetArea()
        {
            Area = MathF.Round(Side * Side, 2);
            return Area > 0 && Side > 0 && Side <= float.MaxValue && Area <= float.MaxValue ? Area : default;
        }

        /// <summary>
        /// Gets the area of Square and preventing crashes.
        /// </summary>
        /// <returns>Area of Square</returns>
        public override float GetPerimeter()
        {
            Perimeter = MathF.Round(Side * 4, 2);
            return Perimeter > 0 && Side > 0 && Side <= float.MaxValue && Perimeter <= float.MaxValue ? Perimeter : default;
        }
    }
}