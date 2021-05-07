using AssignmentOne.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne.GeoShapes
{
    public class Circle : IGeometricalThings

    {
        public float Radius { get; set; }

        public Circle(float radius)
        {
            Radius = radius;
        }
        /// <summary>
        /// Räknar ut arean på en cirkel
        /// </summary>
        /// <returns>areas avrundar till två decimaler</returns>
        public float GetArea()
        {
            if(Radius <= 0)
            {
                return 0;
            }
            var area = Math.PI * Radius * Radius;
            return (float)Math.Round(area, 2);
        }
        /// <summary>
        /// Räknar ut omkretsen på en cirkel
        /// </summary>
        /// <returns>Omkretsen avrundat till två decimaler</returns>
        public float GetPerimeter()
        {
            if (Radius <= 0)
            {
                return 0;
            }
            var per = 2 * Math.PI * Radius;
            return (float)Math.Round(per, 2);
        }
    }
}
