using System.Collections.Generic;

namespace GeometriTest
{
    /// <summary>
    /// Klass som utför uträkningar av GeometricThing
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Retunerar den geometriska figurens area, gansak överflödig metod då det går att göra direkt genom metoden.
        /// <param name="thing">den geometriska figuren </param>
        /// </summary>
        public float GetArea(GeometricThing thing)
        {
            return thing.Area();
        }

        /// <summary>
        /// Retunerar den geometriska figurens omkrets, ganska överflödig metod då det går att göra direkt genom metoden.
        /// <param name="thing">den geometriska figuren </param>
        /// </summary>
        public float GetPerimeter(GeometricThing thing)
        {
            return thing.Perimeter();
        }

        /// <summary>
        /// Retunerar summan av geometriska figurenas omkrets.
        /// <param name="things">en lista av geometriska figurer  </param>
        /// </summary>
        public float GetPerimeter(List<GeometricThing> things)
        {
            float totalPerimeter = 0;
            foreach (var thing in things)
            {
                totalPerimeter += thing.Area();
            }
            return totalPerimeter;
        }
    }
}