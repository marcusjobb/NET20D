using System;
using TDDgeometric.Models;

namespace TDDgeometric.Controllers
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Sums the total area of several objects
        /// </summary>
        /// <param name="shapes">An array of different GeometricShapes</param>
        /// <returns>the area</returns>
        public float GetTotalArea(GeometricShapes[] shapes)
        {
            if(shapes != null)
            {
                var result = 0.0f;
                foreach(var shape in shapes)
                {
                    result += shape.GetArea();
                }

                if(result < float.MaxValue)
                {
                    return MathF.Round(result, 2);
                }
            }
            return default;
        }

        /// <summary>
        /// Sums the total perimiter of several objects
        /// </summary>
        /// <param name="shapes">An array of different GeometricShapes</param>
        /// <returns>The perimiter</returns>
        public float GetTotalPerimiter(GeometricShapes[] shapes)
        {
            if(shapes != null)
            {
                var result = 0.0f;
                foreach(var shape in shapes)
                {
                    result += shape.GetPerimiter();
                }
                if(result < float.MaxValue)
                {
                    return MathF.Round(result, 2);
                }
            }
            return default;
        }
    }
}
