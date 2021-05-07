using IvoNazlicTestGeometry.Interfaces;
using IvoNazlicTestGeometry.Tools;

namespace IvoNazlicTestGeometry.GeometryObjects
{
    public class Rectangle : IGeometricThing
    {
        public float Height { get; set; }

        public float Width { get; set; }

        public Rectangle(float height, float width)
        {
            Height = height;
            Width = width;
        }

        /// <summary>
        /// Calculates area of the rectangle
        /// </summary>
        /// <returns>Area as float</returns>
        public float GetArea()
        {
            return MathExtensions.NiceRound(Height * Width);         
        }

        /// <summary>
        /// Calculates circumference of the rectangle
        /// </summary>
        /// <returns>Circumference as float</returns>
        public float GetCircumference()
        {
            return MathExtensions.NiceRound(Height * 2 + Width * 2);
        }
    }
}
