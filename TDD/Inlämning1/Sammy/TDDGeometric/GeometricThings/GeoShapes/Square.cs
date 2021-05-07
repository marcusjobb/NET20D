
namespace TDDGeometric.GeometricThings.GeoShapes
{
    using System;
    public class Square : GeometricShapes
    {
        public Square(float side) { this.Side = side; }

        private float Side { get; set; }
        /// <summary>
        /// Räkna ut arean på en kvadrat
        /// </summary>
        /// <returns>Area som avrundas till 2 decimaler</returns>
        public override float GetArea()
        {
            if (Side <= 0) { return 0; }
            return (float)Math.Round(Side * Side, 2); 
        }

        /// <summary>
        /// Räkna ut omkretsen på en kvadrat
        /// </summary>
        /// <returns>Omkretsen som avrundas till 2 decimaler</returns>
        public override float GetPerimiter()
        {
            if (Side <= 0) { return 0; }
            return (float)Math.Round(Side * 4, 2);
        }
    }
}
