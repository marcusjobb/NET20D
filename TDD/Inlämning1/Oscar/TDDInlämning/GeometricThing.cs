using System;
using System.Collections.Generic;
using System.Text;

namespace TDDInlämning1
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// en figurs area
        /// </summary>
        /// <returns></returns>
        public abstract double Area();
        /// <summary>
        /// en figurs omkrets
        /// </summary>
        /// <returns></returns>
        public abstract double Perimeter();


    }
}
