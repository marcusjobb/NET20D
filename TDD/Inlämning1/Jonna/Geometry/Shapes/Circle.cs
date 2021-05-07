using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Shapes
{
    public class Circle : GeometricThing
    {
        /// <summary>
        /// Circle needs a Radius to calculate their Area and radius
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// To calculate the area of a circle we take the Radius times two multiplied by Pi
        /// If the Radius is zero, negative number of null we return 0
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            if (Radius <= 0 || Radius == null)
                return 0;
            return Radius * Radius * Math.PI;
        }

        /// <summary>
        /// To calculate the perimeter of a circle we take 2 * Radius * Pi
        /// If the Radius is zero, negative number or null we return 0
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            if (Radius <= 0 || Radius == null)
                return 0;
            return 2 * Radius * Math.PI;
        }
    }
}
