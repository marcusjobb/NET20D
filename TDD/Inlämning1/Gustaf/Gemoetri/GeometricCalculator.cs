using System.Collections.Generic;

namespace Geometri
{
    public static class GeometricCalculator
    {
        /// <summary>
        /// Returns the circumference of an GeometricThing object
        /// </summary>
        /// <param name="thing">The object to get the circumference from</param>
        /// <returns>The circumference</returns>
        public static float GetCircumference(GeometricThing thing)
        {
            return thing.Circumference();
        }
        /// <summary>
        /// Returns the circumference of an GeometricThing array
        /// </summary>
        /// <param name="things">The object to get the circumferences from</param>
        /// <returns>Sum of the circumferences</returns>
        public static float GetCircumference(GeometricThing[] things)
        {
            float sum = 0.0f;
            for (int i = 0; i < things.Length; i++)
            {
                sum += things[i].Circumference();
            }
            return sum;
        }
        /// <summary>
        /// Returns the circumference of a Collection of geometric things
        /// </summary>
        /// <param name="things">The collection to get the circumferences from</param>
        /// <returns>Sum of the circumferences</returns>
        public static float GetCircumference(List<GeometricThing> things)
        {
            float sum = 0.0f;
            foreach (GeometricThing item in things)
            {
                sum += item.Circumference();
            }
            return sum;
        }
        /// <summary>
        /// Returns the area of an GeometricThing object
        /// </summary>
        /// <param name="thing">The area to get the circumference from</param>
        /// <returns>The area</returns>
        public static float GetArea(GeometricThing thing)
        {
            return thing.Area();
        }
        /// <summary>
        /// Returns the circumference of an GeometricThing array
        /// </summary>
        /// <param name="things">The object to get the circumferences from</param>
        /// <returns>Sum of the circumferences</returns>
        public static float GetArea(GeometricThing[] things)
        {
            float sum = 0.0f;
            for (int i = 0; i < things.Length; i++)
            {
                sum += things[i].Area();
            }
            return sum;
        }
        /// <summary>
        /// Returns the area of a Collection of geometric things
        /// </summary>
        /// <param name="things">The collection to get the areas from</param>
        /// <returns>Sum of the areas</returns>
        public static float GetArea(List<GeometricThing> things)
        {
            float sum = 0.0f;
            foreach (GeometricThing item in things)
            {
                sum += item.Circumference();
            }
            return sum;
        }
    }
}
