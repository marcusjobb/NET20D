
namespace TDDGeometric.GeometricThings.GeoShapes
{
    using System;
    public class Circle : GeometricShapes
    {
        public Circle(float radius) { Radius = radius; }

        private float Radius { get; set; }
        /// <summary>
        /// Räkna ut arean på en cirkel
        /// </summary>
        /// <returns>Arean som avrundas till 2 decimaler</returns>
        public override float GetArea()
        {
            if (Radius <= 0) { return 0; }
            return (float)Math.Round(Math.PI * Radius * Radius, 2);
        }

        /// <summary>
        /// Räkna ut omkretsen på en cirkel
        /// </summary>
        /// <returns>Omkretsen som avrundas till 2 decimaler</returns>
        public override float GetPerimiter()
        {
            if (Radius <= 0) { return 0; }
            return (float)Math.Round(2 * Math.PI * Radius, 2);
        }
    }
}
