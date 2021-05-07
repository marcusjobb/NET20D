namespace GeometricJesperPersson.Calculator
{
    using GeometricJesperPersson.Shapes;
    using System;

    public class GeometricCalculator
    {
        /// <summary>
        /// Get the area of the geometric figure.
        /// </summary>
        /// <param name="thing">Any geometric figure.</param>
        /// <returns>The area in float. 0 if fails.</returns>
        public float GetArea(GeometricThing thing) => thing != null ? MathF.Round(thing.GetArea(), 5) : default;

        /// <summary>
        /// Get the perimeter of the geometric figure.
        /// </summary>
        /// <param name="thing">Any geometric figure.</param>
        /// <returns>The perimeter in float. 0 if fails.</returns>
        public float GetPerimeter(GeometricThing thing) => thing != null ? MathF.Round(thing.GetPerimeter(), 5) : default;

        /// <summary>
        /// Get the sum of more then one geometrics perimeter.
        /// </summary>
        /// <param name="thing2">Any geometrics figures.</param>
        /// <returns>The sum of all perimeters in float. 0 if any of the figures fails.</returns>
        public float GetPerimeter(GeometricThing[] thing2)
        {
            float sum = default;
            if (thing2 != null)
            {
                foreach (var obj in thing2)
                {
                    if (obj.GetPerimeter() != 0) sum += obj.GetPerimeter();
                    else return default;
                }
            }
            return (sum < float.MaxValue) ? sum : default;
        }
    }
}