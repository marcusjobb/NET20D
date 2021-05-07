using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculates area for a number of shapes
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public float GetArea(GeometricShapes[] shapes)
        {
            float area = 0f;
            foreach (var shape in shapes)
            {
                if (shape != null)
                {
                    area += shape.GetArea();
                }
                else
                {
                    area += 0f;
                }
            }
            return (float)Math.Round(area,3);
        }
        /// <summary>
        /// Calculates perimeter for a number of shapes
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public float GetPerimeter(GeometricShapes[] shapes)
        {
            float perimeter = 0;
            foreach (var shape in shapes)
            {
                if (shape != null)
                {
                    perimeter += shape.GetPerimeter();
                }
                else
                {
                    perimeter += 0;
                }
            }
            return (float)Math.Round(perimeter,3);
        }
    }
}
