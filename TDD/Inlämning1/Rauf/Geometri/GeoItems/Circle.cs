using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri.GeoItems
{
    public class Circle : IGeometricThing
    {
        
        public float R { get; set; }
        public Circle(float radius)
        {;
            if (radius <0) radius = 0;
            R = radius;
        }
        public float GetPerimeterData
        {
            get => MathF.PI * 2 * R;
        }
        public float GetAreaData 
        {
            get => MathF.PI * R * R; 
        
        }
    }
}
