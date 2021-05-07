using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricTDD
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// Calculates the area of the form.
        /// </summary>
        /// <returns>The area.</returns>
        public abstract float GetArea();
        /// <summary>
        /// Calculates the perimeter of the form.
        /// </summary>
        /// <returns>The perimeter.</returns>
        public abstract float GetPerimeter();
    }
}
