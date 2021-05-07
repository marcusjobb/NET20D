using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Library
{
    public class Triangle : IGeometricThing
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double Base { get; set; }

        public Triangle(double @base)
        {
            Base = @base;
        }
        /// <summary>
        /// Calculates area for a triangle. If negative value for base is provided, value is set to 0.
        /// </summary>
        /// <returns>Area in double</returns>
        public double GetArea()
        {          
            if (Base < 0)
            {
                Base = 0;
            }
            return (Base * Base) / 2;
        }
        /// <summary>
        /// Calculates perimeter for a triangle. If negative value for base is provided, value is set to 0.
        /// </summary>
        /// <returns>Perimeter in double</returns>
        public double GetPerimeter()
        {
            if (Base < 0)
            {
                Base = 0;
            }
            return Base * 3;
        }
    }
}
