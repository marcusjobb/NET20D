using Geometri.Interface;
using System;

namespace Geometri.GeometricCalculator
{
    /// <summary>
    /// Defines a geometric calculator.
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculate area of diffrent shapes.
        /// </summary>
        /// <param name="things">a array of shapes</param>
        /// <returns>float area</returns>
        public float GetArea(IGeometricThing[] things)
        {
            if (things == null) return 0;

            float area = 0f;
            foreach (var geoThing in things)
            {
                area += geoThing.Area();
            }
            return MathF.Round(area, 2);
        }

        /// <summary>
        /// calculate perimeter of diffrent shapes.
        /// </summary>
        /// <param name="things">a array of shapes</param>
        /// <returns>float perimeter</returns>
        public float GetPerimeter(IGeometricThing[] things)
        {
            if (things == null) return 0;

            float perimeter = 0f;
            foreach (var geoThing in things)
            {
                perimeter += geoThing.Perimeter();
            }
            return MathF.Round(perimeter, 2);
        }
    }
}