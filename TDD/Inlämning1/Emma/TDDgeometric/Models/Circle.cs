using System;

namespace TDDgeometric.Models
{
    public class Circle : GeometricShapes
    {
        private float Radius { get; set; }

        /// <summary>
        /// Sets the property of an object
        /// </summary>
        /// <param name="radius">input data, radius of an circle object</param>
        public Circle(float radius)
        {
            Radius = radius;
        }

        public override float GetArea()
        {
            if (Radius > 0)
            {
                var result = MathF.Round(MathF.PI * MathF.Pow(Radius, 2), 2);
                if (result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }

        public override float GetPerimiter()
        {
            if (Radius > 0)
            {
                var result = MathF.Round((2 * MathF.PI * Radius), 2);
                if (result < float.MaxValue)
                {
                    return result;
                }
            }

            return default;
        }
    }
}
