using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.GeoItems
{
    public class Triangle : IGeometricThing
    {
        public float GetPerimeterData { get =>Bas*3; }
        public float GetAreaData { get => Bas*Höjd/2; }

        public float Bas { get; set; }
        public float Höjd { get; set; }


        public Triangle(float bas, float höjd)
        {
            if (bas > 0 && höjd > 0)
            {
                Bas = bas;
                Höjd = höjd;
            }
            else
            {
                Bas = 0;
                Höjd = 0;
            }
        }
    }
}
