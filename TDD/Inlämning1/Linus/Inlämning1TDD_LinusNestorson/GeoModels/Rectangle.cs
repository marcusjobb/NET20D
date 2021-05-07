namespace GeometryProject
{
    using GeometryProject.GeoModels;
    using System;

    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// High property of Rectangle.
        /// </summary>
        public float Hight { get; set; }

        /// <summary>
        /// Width property of Rectangle.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Rectangle constructor.
        /// </summary>
        /// <param name="hight">Sets the hight of the rectangle.</param>
        /// <param name="width">Sets the width of the rectangle.</param>
        public Rectangle(float hight, float width)
        {
            Hight = hight; Width = width;
        }

        /// <summary>
        /// Gets the area of Rectangle and preventing crashes.
        /// </summary>
        /// <returns>Area of Rectangle</returns>
        public override float GetArea()
        {
            Area = MathF.Round(Hight * Width, 2);
            return Area > 0 && Hight > 0 && Width > 0 && Hight <= float.MaxValue && Width <= float.MaxValue && Area <= float.MaxValue ? Area : default;
        }

        /// <summary>
        /// Gets the area of Rectangle and preventing crashes.
        /// </summary>
        /// <returns>Area of Rectangle</returns>
        public override float GetPerimeter()
        {
            Perimeter = MathF.Round((Hight * 2) + (Width * 2), 2);
            return Perimeter > 0 && Hight > 0 && Width > 0 && Hight <= float.MaxValue && Width <= float.MaxValue && Perimeter <= float.MaxValue ? Perimeter : default;
        }
    }
}