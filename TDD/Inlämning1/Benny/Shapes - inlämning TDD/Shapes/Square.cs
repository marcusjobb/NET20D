using System;

namespace Shapes___inlämning_TDD
{
    //Comments for interface implemented methods are in the interface class
    internal class Square : IGeometricThing
    {
        /// <summary>
        /// Constructor for a square
        /// </summary>
        /// <param name="side"></param>
        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Property for the side measurement
        /// </summary>
        public float Side { get; set; }

        public float CalculateArea()
        {
            const float ToThePowerOf = 2.0f;

            if (Side < 0)
            {
                return 0;
            }
            return MathF.Pow(Side, ToThePowerOf);
        }

        public float GetPerimeter()
        {
            if (Side <= 0)
            {
                return 0;
            }

            return Side * 4;
        }
    }
}