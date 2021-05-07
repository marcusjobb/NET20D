using System;

namespace TDDgeometric.Models
{
    public class IsocelesTriangle : GeometricShapes
    {
        private float Side { get; set; }

        /// <summary>
        /// Sets the property of an object
        /// </summary>
        /// <param name="side">input data, the side of an isoceles triangle</param>
        public IsocelesTriangle(float side)
        {
            Side = side;
        }

        public override float GetArea()
        {
            if (Side > 0)
            {
                var height = MathF.Sqrt(MathF.Pow(Side, 2) - MathF.Pow(Side/2, 2));
                var result = MathF.Round((Side * height) / 2, 2);
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
                var result = MathF.Round((Side * 3), 2);
                if(result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }
    }
}
