using System;
using System.Collections.Generic;
using System.Text;

namespace GeometriTDD
{
    /// <summary>
    /// Denna klassen innehåller metoder som beräknar omkrets och area om en eller flera former.
    /// Alla metoder är baserade på klassen GeometricThing
    /// </summary>
    public class GeometricCalculator
    {

        public float GetPerimeter(GeometricThing thing)
        {
            float perimeter = 0;
            float shape = thing.GetPerimeter();
            if (shape > 0)
            {
                perimeter = shape;
            }
            return perimeter;
        }

        public float GetPerimeter(GeometricThing[] things)
        {
            float perimeter = 0;
            for (int i = 0; i < things.Length; i++)
            {
                float shape = things[i].GetPerimeter();
                if (shape > 0)
                {
                    perimeter += things[i].GetPerimeter();
                }
            }
            return perimeter;
        }

        public float GetArea(GeometricThing thing)
        {
            float area = 0;
            float shape = thing.GetArea();
            if (shape > 0)
            {
                area = shape;
            }
            return area;
        }

        public float GetArea(GeometricThing[] things)
        {
            float area = 0;
            for (int i = 0; i < things.Length; i++)
            {
                float shape = things[i].GetArea();
                if (shape > 0)
                {
                    area += things[i].GetArea();
                }
            }
            return area;
        }
    }
}
