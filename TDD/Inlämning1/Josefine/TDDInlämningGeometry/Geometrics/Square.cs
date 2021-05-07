using System;
using TDDInlämningGeometry.Geometrics;

namespace Geometrics
{
    public class Square : IGeometricThing
    {
        /// <summary>
        /// Constructor for a square with a side
        /// </summary>
        /// <param name="side"></param>
        public Square(float side)
        {
            this.Side = side;
        }

        public float Side { get; set; }
        public float GetArea()
        {
            if (Side <= 0) { return 0; }
            return MathF.Pow(Side, 2);
        }

        public float GetPerimeter()
        {
            if (Side <= 0) { return 0; }
            return Side * 4;
        }
    }
}