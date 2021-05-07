using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculates the area of a GeometricThing
        /// Returns the area of passed object
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public static double GetArea(GeometricThing thing)
        {
            double area = 0;
            area += thing.Area();
            return area;
        }

        /// <summary>
        /// Calculates the perimeter of a GeometricThing
        /// Returns the perimeter of passed object
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public static double GetPerimeter(GeometricThing thing)
        {
            double perimeter = 0;
            perimeter += thing.Perimeter();
            return perimeter;
        }

        /// <summary>
        /// Calculates the perimeter of an array with GeometricThings(Whatever shapes they may be!)
        /// Returns the perimeter of all the objects passed in the array
        /// </summary>
        /// <param name="things"></param>
        /// <returns></returns>
        public static double GetPerimeter(GeometricThing[] things)
        {
            double perimeter = 0;
            foreach (var thing in things)
            {
                perimeter += thing.Perimeter();
            }
            return perimeter;
        }
    }
}
