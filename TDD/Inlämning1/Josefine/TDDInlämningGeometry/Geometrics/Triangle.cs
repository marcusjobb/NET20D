using TDDInlämningGeometry.Geometrics;

namespace Geometrics
{
    public class Triangle : IGeometricThing
    {
        /// <summary>
        /// Constructor for a triangle with a side and a heigth
        /// </summary>
        /// <param name="side"></param>
        /// <param name="heigth"></param>
        public Triangle(float side, float heigth)
        {
            this.Side = side;
            this.Height = heigth;
        }

        /// <summary>
        /// Constructor for a triangle with a side
        /// </summary>
        /// <param name="side"></param>
        public Triangle(float side)
        {
            this.Side = side;
        }

        public float Height { get; set; }
        public float Side { get; set; }
        public float GetArea()
        {
            if (Side <= 0 || Height <= 0) { return 0; }
            return Side * Height / 2;
        }

        public float GetPerimeter()
        {
            if (Side <= 0) { return 0; }
            return Side * 3;
        }
    }
}