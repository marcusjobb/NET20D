using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjin_inlamning_g.Shape
{
   public class Square : GeometricThing
    {
    
        public float Side { get; set; }
        /// <summary>
        /// The side of the object
        /// </summary>
        /// <param name="side"></param>
        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Gets the area of the square
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            if (Side < 0)
            {
                return Side = 0;
            }
            return Side * Side;
        }
        /// <summary>
        /// gets the perimeters of the square
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            if (Side < 0)
            {
                return Side = 0;
            }
            return Side * 4;
        }
    }
}
