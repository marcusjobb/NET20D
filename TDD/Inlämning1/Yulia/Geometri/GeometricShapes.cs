using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public abstract class GeometricShapes
    {
        /// <summary>
        /// Gets the area of an object
        /// </summary>
        /// <returns></returns>
        public abstract float GetArea();
        /// <summary>
        /// Gets the perimeter of an object
        /// </summary>
        /// <returns></returns>
        public abstract float GetPerimeter();
    }
}
