
namespace TDDGeometric.GeometricThings.GeoShapes
{
    using System;
    public class Triangle : GeometricShapes
    {
        public Triangle(float side, float height)
        {
            this.Side = side;
            this.Height = height;
        }

        private float Height { get; set; }
        private float Side { get; set; }
        /// <summary>
        /// Räkna ut arean på en triangel
        /// </summary>
        /// <returns>Area som avrundas till 2 decimaler</returns>
        public override float GetArea()
        {
            if (Side <= 0 || Height <= 0) { return 0; }
            return (float)Math.Round(Side*Height/2, 2);
        }

        /// <summary>
        /// Räkna ut omkretsen till en triangel
        /// </summary>
        /// <returns>Omkrets som avrundas till 2 deicmaler</returns>
        public override float GetPerimiter()
        {
            if (Side <= 0 || Height <= 0) { return 0; }
            return (float)Math.Round(Side * 3, 2);
        }
    }
}
