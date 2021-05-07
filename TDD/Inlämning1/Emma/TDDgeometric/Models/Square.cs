using System;

namespace TDDgeometric.Models
{
    public class Square : GeometricShapes
    {
        private float Side { get; set; }

        /// <summary>
        /// Sets the property of object
        /// </summary>
        /// <param name="side">input data for the side of the object</param>
        public Square(float side)
        {
            Side = side;
        }

        public override float GetArea()
        {
            if (Side > 0)
            {
                var result = MathF.Round(MathF.Pow(Side, 2), 2);
                if (result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }

        public override float GetPerimiter()
        {
            if (Side > 0)
            {
                var result = Side * 4;
                if (result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }
    }
}
