using AssignmentOne.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne.GeoShapes
{
    public class Square : IGeometricalThings
    {
        public float Side { get; set; }

        public Square(float side)
        {
            this.Side = side;
        }

        /// <summary>
        /// Räknar ut arean på en kvadrat
        /// </summary>
        /// <returns>Arean</returns>
        public float GetArea()
        {
            if (Side <= 0)
            {
                return 0;
            }
            var result =  Side * Side;
            return (float)Math.Round(result, 2);
        }
        /// <summary>
        /// Räknar ut omkretsen
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter()
        {
            if (Side <= 0)
            {
                return 0;
            }
            var result =  Side * 4;
            return (float)Math.Round(result, 2);
        }
    }
}
