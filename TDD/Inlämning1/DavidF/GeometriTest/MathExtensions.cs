using System;

namespace GeometriTest
{
    public static class MathExtensions
    {
        /// <summary>
        /// Extension som avrundar float till två decimaler
        /// <param name="nmbr">den geometriska figuren </param>
        /// </summary>
        public static float GoodRound(this float nmbr)
        {
            return MathF.Round(nmbr, 2);
        }
    }
}