using System;
using System.Collections.Generic;
using System.Text;

namespace tdd_inlamning_1
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// Value a, should be considered to be the base (width) if nothing else is specified.
        /// </summary>
        public abstract float A { get; set; }

        /// <summary>
        /// Value b, should be considered the height if nothing else is specified.
        /// </summary>
        public abstract float B { get; set; }

        /// <summary>
        /// Return the area of the specific geometric shape
        /// </summary>
        /// <returns>calculated area of the shape in metric unit</returns>
        public abstract float GetArea();

        /// <summary>
        /// Return the perimeter of the specific geometric shape
        /// </summary>
        /// <returns>calculated perimeter of the shape in metric unit</returns>
        public abstract float GetPerimeter();
    }
}
