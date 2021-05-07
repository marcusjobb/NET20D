using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Shapes
{
    public class Square : GeometricThing
    {
        /// <summary>
        /// To calculate the area or the perimeter of a square we need the measurement of a side
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// To Calculate the area of the square we multiply the Side with Side again
        /// If either Side is zero, negative number or null
        /// the calculation returns 0
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            if (Side <= 0 || Side == null)
                return 0;

            return Side * Side;
        }

        /// <summary>
        /// To Calculate the Perimeter of the square we add the Side times four
        /// If either side is Zero, negative or null
        /// calculation returns 0
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            if (Side <= 0 || Side == null)
                return 0;

            return Side + Side + Side + Side;
        }
    }
}
