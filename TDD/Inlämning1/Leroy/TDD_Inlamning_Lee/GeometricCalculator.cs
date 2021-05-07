using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Inlamning_Lee.Interfaces;
using TDD_Inlamning_Lee.GeoItems;

namespace TDD_Inlamning_Lee
{
    /// <summary>
    /// The GeometricCalculator provides 3 methodes that supports calculations of different geometric shapes
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Returns the area of a geometric shape implementing the IGeometricTHings interface
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public float GetArea(IGeometricThings area)
        {
            return area.GetArea();
        }
        /// <summary>
        /// Returns the perimiter of a geometric shape implementing the IGeometricTHings interface
        /// </summary>
        /// <param name="perimiter"></param>
        /// <returns></returns>
        public float GetPerimiter(IGeometricThings perimiter)
        {
            return perimiter.GetPerimiter();
        }
        /// <summary>
        /// Returns the total perimiter of geometric shapes from an array implementing the IGeometricTHings interface
        /// as long as the input numbers are positive otherwise -1
        /// </summary>
        /// <param name="perimiter"></param>
        /// <returns></returns>
        public float GetPerimiter(GeometricThings[] perimiter)
        {
            float result = 0, a = 0;
            foreach (IGeometricThings geo in perimiter)
            {
                a = geo.GetPerimiter();
                result += a;
                Console.WriteLine(a.ToString());
            }
            Console.WriteLine(result.ToString());
            if (result < 0) return -1;
            return result;
        }

    }
}
