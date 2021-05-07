using AssignmentOne.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentOne.GeoShapes
{
    public class Rectangle : IGeometricalThings
    {
        public float Base { get; set; }
        public float Height { get; set; }

        public Rectangle(float baseSide, float height)
        {
            Base = baseSide;
            Height = height;
        }

        /// <summary>
        /// Räknar ut arean på en rektangel
        /// </summary>
        /// <returns>Arean avrundat till två decimaler</returns>
        public float GetArea()
        {
            if (Base <= 0 || Height <= 0)
            {
                return 0;

            }

            var result =  Base * Height;
            return (float)Math.Round(result, 2);
        }
        /// <summary>
        /// Räknar ut omkretsen på en rektangel
        /// </summary>
        /// <returns>Omkretsen avrundat till två decimaler</returns>
        public float GetPerimeter()
        {
            if (Base <= 0 || Height <= 0)
            {
                return 0;

            }

            var result = Base * 2 + Height * 2;
            return (float)Math.Round(result, 2);
        }
    }
}
