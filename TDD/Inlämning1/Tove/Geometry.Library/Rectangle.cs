using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Library
{
    public class Rectangle : IGeometricThing
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double Base { get ; set ; }
        public double Height { get ; set ; }

        public Rectangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
        /// <summary>
        /// Calculates area for a rectangle. If negative value for base or height is provided, value is set to 0.
        /// </summary>
        /// <returns>Area in double</returns>
        public double GetArea()
        {
            if (Height < 0)
            {
                Height = 0;
            }
            if (Base < 0)
            {
                Base = 0;
            }
            return Base * Height;
        }
        /// <summary>
        /// Calculates perimeter for a rectangle. If negative value for base or height is provided, value is set to 0.
        /// </summary>
        /// <returns>Perimeter in double</returns>
        public double GetPerimeter()
        {
            if (Height < 0)
            {
                return 0;
            }
            if (Base < 0)
            {
                return 0;
            }
            return (Base * 2) + (Height * 2);
        }

    }
}
