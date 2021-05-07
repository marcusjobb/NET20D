using System;
using System.Collections.Generic;
using System.Text;

namespace GeometricThings.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Extension that rounds up nice and easy to 4 digits
        /// </summary>
        /// <param name="f1">the float to round up</param>
        /// <returns>The rounded up float</returns>
        public static float NiceRound(this float f1)
        {
            return MathF.Round(f1, 4);
        }
    }
}
