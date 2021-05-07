using System;
using System.Collections.Generic;
using System.Text;

namespace TDDInlämning1
{
    public class Square : GeometricThing
    {
        /// <summary>
        /// längden på kvadraten
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// konstruktor som tar emot längden på kvadraten. Ifall värdet som skickas in är negativt, ändras det till 0 i konstruktorn
        /// </summary>
        /// <param name="length"></param>
        public Square(double length)
        {
            if(length < 0)
            {
                length = 0;
            }
            Length = length;
        }
        /// <summary>
        /// räknar ut fyrkantens area genom att ta längden * längden
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            return Length * Length;
        }
        /// <summary>
        /// räknar ut fyrkantens omkrets genom att ta längden * 4
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            return Length * 4;
        }
    }
}
