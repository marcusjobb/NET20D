using System;
using System.Collections.Generic;
using System.Text;

namespace TDDInlämning1
{
    public class Triangle : GeometricThing
    {
        /// <summary>
        /// triangelns bas
        /// </summary>
        public double Base { get; set; }
        /// <summary>
        /// triangelns höjd
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// konstruktor som tar emot bas och höjd. Ifall värdet som skickas in är negativt, ändras det till 0 i konstruktorn
        /// </summary>
        /// <param name="tbase"></param>
        /// <param name="height"></param>
        public Triangle(double tbase, double height)
        {
            if(tbase < 0)
            {
                tbase = 0;
            }
            if (height < 0)
            {
                height = 0;
            }
            Base = tbase;
            Height = height;
        }
        /// <summary>
        /// konstruktor som tar emot endast basen.
        /// Ifall värdet som skickas in är negativt, ändras det till 0 i konstruktorn
        /// </summary>
        /// </summary>
        /// <param name="tbase"></param>
        public Triangle(double tbase)
        {
            if (tbase < 0)
            {
                tbase = 0;
            }
            Base = tbase;
        }
        /// <summary>
        /// räknar ut triangelns area genom att ta basen * höjden / 2
        /// </summary>
        /// <returns></returns>
        public override double Area()
        {
            return Base * Height / 2;

        }
        /// <summary>
        /// räknar ut triangelns omkrets genom att ta basen * 3
        /// </summary>
        /// <returns></returns>
        public override double Perimeter()
        {
            return Base * 3;
        }
    }
}
