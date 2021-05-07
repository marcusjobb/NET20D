using Inlämning1.Utility;
using System;

namespace Inlämning1
{
    public class Circle : IGeometricThing
    {
        public float Radius { get; set; }
        /// <summary>
        /// Calculates the Area of a Circle object.
        /// </summary>
        /// <returns>float</returns>
        public float GetArea()
        {
            if (Verify.VerifyNull(Radius) && Verify.IsNumber(Radius))
            {
                return MathF.PI * Radius * Radius;
            }
                return default;
        }
        /// <summary>
        /// Calculates the Perimeter of a Circle object.
        /// </summary>
        /// <returns>float</returns>
        public float GetPerimeter()
        {
            if (Verify.VerifyNull(Radius) && Verify.IsNumber(Radius))
            {
                return 2 * MathF.PI * Radius;
            }
                return default;
        }
    }
}
