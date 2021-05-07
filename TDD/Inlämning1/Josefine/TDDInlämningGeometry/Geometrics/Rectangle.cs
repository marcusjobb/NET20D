using TDDInlämningGeometry.Geometrics;

namespace Geometrics
{
    public class Rectangle : IGeometricThing
    {
        public float Height;
        public float Length;
        /// <summary>
        /// Constructor for a rectangle with length and heigth
        /// </summary>
        /// <param name="length"></param>
        /// <param name="heigth"></param>
        public Rectangle(float length, float heigth)
        {
            this.Length = length;
            this.Height = heigth;
        }

        public float GetArea()
        {
            if (Length <= 0 || Height <= 0) { return 0; }
            return Length * Height;
        }

        public float GetPerimeter()
        {
            if (Length <= 0 || Height <= 0) { return 0; }
            return Length * 2 + Height * 2;
        }
    }
}