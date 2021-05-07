using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Shapes
{
    public class Triangle : GeometricThing
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Side { get; set; }
        /// <summary>
        /// To get the Area of a triangle we multiply the width with the height and then
        /// divide it by 2
        /// If the Width or height is zero,negative number or null
        /// the calculation will return 0
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            if (Height <= 0 || Width <= 0 || Height == null || Width == null)
                return 0;

            return Width * Height / 2;

        }
        /// <summary>
        /// To get the perimeter of a triangle we add all the three sides together
        /// In this case all 3 sides are of equal length(equilateral triangle)
        /// If the side is zero,negative number or null
        /// the calculation will return 0
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            if (Side <= 0 || Side == null)
                return 0;

            return Side + Side + Side;
        }
    }
}
