using Geometri.GeoItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class GeometricCalculator
    {

        public float GetArea(IGeometricThing thing)
        {

            if (!(thing is null)) return thing.GetAreaData;
            else { return 0; }
        }

        public float GetPerimeter(IGeometricThing thing)
        {

            return thing.GetPerimeterData;
        }

        public float GetPerimeter(IGeometricThing[] thing)
        {
            float sum = 0;
            for (int i = 0; i < 3; i++)
            {
                if (thing[i] is null) { sum += 0; }
                else sum = sum + thing[i].GetPerimeterData;
            }
            return sum;
        }
    }
}
