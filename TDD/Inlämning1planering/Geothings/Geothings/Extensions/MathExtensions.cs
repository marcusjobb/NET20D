namespace Geothings.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class MathExtensions
    {
        public static bool NearlyEqual(this float f1, float f2)
        {
            // Equal if they are within 0.00001 of each other
            return Math.Abs(f1 - f2) < 0.00001;
            // Källa: https://csharp.2000things.com/2011/09/21/416-use-an-epsilon-to-compare-two-floating-point-numbers/
        }

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
