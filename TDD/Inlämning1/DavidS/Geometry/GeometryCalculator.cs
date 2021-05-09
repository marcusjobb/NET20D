namespace Geometry
{
    using Geometry.Abstracts;

    public class GeometryCalculator
    {
        /// <summary>
        /// Calculates the total area of all <paramref name="things"/>.
        /// </summary>
        /// <param name="things"></param>
        /// <returns>The sum of all areas.</returns>
        public float GetAreas(GeometricThing[] things)
        {
            if (things == null) return 0;
            var sum = 0.0f;
            foreach (var thing in things)
            {
                sum += thing.Area();
            }
            return sum;
        }

        /// <summary>
        /// Calculates the total perimiter for all <paramref name="things"/>.
        /// </summary>
        /// <param name="things"></param>
        /// <returns>The sum of all perimiters.</returns>
        public float GetPerimiters(GeometricThing[] things)
        {
            if (things == null) return 0;
            var sum = 0.0f;
            foreach (var thing in things)
            {
                sum += thing.Perimiter();
            }
            return sum;
        }
    }
}
