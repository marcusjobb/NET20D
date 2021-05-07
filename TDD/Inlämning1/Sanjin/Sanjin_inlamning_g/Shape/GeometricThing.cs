using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjin_inlamning_g.Shape
{
  public abstract class GeometricThing
    {
        /// <summary>
        /// Gets the perimeter of the object
        /// </summary>
        /// <returns>The perimeter</returns>
        public abstract float GetPerimeter();

        /// <summary>
        /// Gets the area of the object
        /// </summary>
        /// <returns>The area</returns>
        public abstract float GetArea();

    }
}
