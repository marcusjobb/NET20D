using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Library
{
    public class Circle : IGeometricThing
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double Radius { get; set;}
        public Circle(double Radius)
        {
            this.Radius = Radius;
        }
        public Circle()
        {
        }
      /// <summary>
      /// Calculates area for a circle. If negative value for radius is provided, radius is set to 0.
      /// </summary>
      /// <returns>Area in double</returns>
        public double GetArea()
        {                    
            if (Radius < 0)
            {
                Radius = 0;
            }
            return Radius * Radius * Math.PI;                 
        }
        /// <summary>
        /// Calculates perimeter for a circle. If negative value for radius is provided, radius is set to 0.
        /// </summary>
        /// <returns>Perimeter in double</returns>
        public double GetPerimeter()
        {
            if (Radius < 0)
            {
                Radius = 0;
            }
            return (Radius + Radius) * Math.PI;
        }
    }
}
