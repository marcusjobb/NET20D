using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1_G_Jangerud.Shapes
{
    /// <summary>
    /// Abstract class that is the mold of all shapes.
    /// </summary>
    public abstract class GeometricThing
    {
        /// <summary>
        /// Area method that the other shapes inherit from this class.
        /// </summary>
        /// <returns></returns>
        public abstract double Area();

        /// <summary>
        /// Perimeter method that the other shapes inherit from this class.
        /// </summary>
        /// <returns></returns>
        public abstract double Perimeter();


    }
}
