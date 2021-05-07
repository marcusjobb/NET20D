using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Library
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculates perimeter for all objects in array.
        /// </summary>
        /// <param name="things"></param>
        /// <returns>Total perimeter in double</returns>
        public static double GetPerimeter(IGeometricThing[]things)
        {
            var perimeter = 0.0;
            var shapePerimeter = 0.0;           
            foreach (var thing in things)
            {                                 
                shapePerimeter = thing.GetPerimeter();
                perimeter += shapePerimeter;              
            }
            return perimeter;
        }
    }
}