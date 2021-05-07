using System;
using System.Collections.Generic;
using System.Text;

namespace TDDInlämning1
{
    public class GeometricCalculator
    {
        /// <summary>
        /// räknar ut sammanlagda omkretsen av flera figurer. returnerar 0 ifall inskikcade arrayen är tom, null, eller ett element inom den är null.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public double GetPerimeter(GeometricThing[] thing)
        {
            if (thing == null || thing.Length == 0)
            {
                return 0;
            }
            double sum = 0;
            foreach (var item in thing)
            {
                if (item == null)
                {
                    return 0;
                }
                else
                {
                    sum += item.Perimeter();
                }
            }
            return sum;
        }
    }
}
