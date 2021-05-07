using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Shapes
{
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// To calculate the area or perimeter from a rectangle we need the Width and Height
        /// </summary>
        public double Width { get; set; }
        public double Height { get; set; }

        /// <summary>
        /// To calculate the area of the rectangle we mutiply the Width with the Height
        /// if either Width or Height is zero, negative number or null
        /// the calculation will return 0
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            if (Width <= 0 || Height <= 0 || Width == null || Height == null)
                return 0;

            return Width * Height;
        }

        /// <summary>
        /// To calculate the perimeter of the rectangle we add Width times two and the Height times two
        /// If either Width or Height is zero, negative number or null
        /// the calculation will return 0
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            if (Width == 0 || Height == 0 || Width == null || Height == null)
                return 0;

            return Width + Width + Height + Height;
        }
    }
}
