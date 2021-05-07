
namespace TDDGeometric.GeometricThings.GeoShapes
{
    using System;
    public class Rectangle : GeometricShapes
    {
        public Rectangle(float length, float height)
        {
            Length = length;
            Height = height;
        }

        private float Height { get; set; }
        private float Length { get; set; }
        /// <summary>
        /// Räkna ut arean till en rektangel
        /// </summary>
        /// <returns>Area som avrundas till 2 decimaler</returns>
        public override float GetArea()
        {
            if (Length <= 0 || Height <= 0) { return 0; }
            return (float)Math.Round(Length * Height, 2);
        }

        /// <summary>
        /// Räkna ut omkretsen till en rektangel
        /// </summary>
        /// <returns>Omkretsen som avrundas till decimaler</returns>
        public override float GetPerimiter()
        {
            if (Length <= 0 || Height <= 0) { return 0; }
            return (float)Math.Round((Length + Height)*2, 2);
        }

    }
}
