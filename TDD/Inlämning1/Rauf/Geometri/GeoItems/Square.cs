using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.GeoItems
{
    class Square
    {

        public float S1 { get; set; }
        public float GetPerimeterData { get => S1 * 4; }
        public float GetAreaData { get => S1 * S1; }

        public Square(float s1)
        {
            S1 = s1;
        }
    }
}
