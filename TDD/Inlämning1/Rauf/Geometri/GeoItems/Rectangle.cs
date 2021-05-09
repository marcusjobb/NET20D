using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.GeoItems
{
    public class Rectangle : IGeometricThing
    {
        public float S1 { get; set; }
        public float S2 { get; set; }
        public float GetPerimeterData { get => (S1+S2) * 2; }
        public float GetAreaData { get => S1*S2; }

        public Rectangle(float s1, float s2)
        {
            if (!(s1 >0 && s2>0))
            {
                s1 = 0;
                s2 = 0;
            }
            S1 = s1;
            S2 = s2;
        }
    }
}
