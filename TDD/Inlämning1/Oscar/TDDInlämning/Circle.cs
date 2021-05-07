using System;
using System.Collections.Generic;
using System.Text;

namespace TDDInlämning1
{
    public class Circle : GeometricThing
    {
        /// <summary>
        /// cirkelns radie
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Konstruktor som tar emot radie, ifall radiens värde som skickas in är negativt ändras det till 0
        /// </summary>
        /// <param name="radius"></param>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                radius = 0;
            }
            Radius = radius;
        }
        /// <summary>
        /// räknar ut cirkelns area genom att ta pi * radien * radien
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
        /// <summary>
        /// räknar ut cirkelns omkrets gneom att ta pi * 2 * radien
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            return (2 * Math.PI) * Radius;
        }
    }
}
