using AssignmentOne.GeoShapes;
using AssignmentOne.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentOne
{
    public class GeometricalCalculator
    {
        /// <summary>
        /// Räknar ut sammanlagda omkretsen på en array av olika objekt/former. Om felaktig input, returnera 0
        /// </summary>
        /// <param name="geoThings"></param>
        /// <returns></returns>
        public float GetPerimeter(IGeometricalThings[] geoThings)
        {
            if (geoThings == null || geoThings.Any(p => p == null))
            {
                return 0;
            }

            if (geoThings.Any(p => p.GetPerimeter() <= 0))
            {
                return 0;
            }

            return geoThings.Sum(p => p.GetPerimeter());
        }
    }
}
