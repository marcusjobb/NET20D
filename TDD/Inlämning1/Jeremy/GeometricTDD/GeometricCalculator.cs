using GeometricTDD.GeometricForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricTDD
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Gets the area from the form.
        /// </summary>
        /// <param name="thing">The form.</param>
        /// <returns>The area.</returns>
        public float GetArea(GeometricThing thing)
        {
            return thing.GetArea();
        }

        /// <summary>
        /// Gets the perimeter from the form.
        /// </summary>
        /// <param name="thing">The form.</param>
        /// <returns>The perimeter.</returns>
        public float GetPerimeter(GeometricThing thing)
        {
            return thing.GetPerimeter();
        }

        /// <summary>
        /// Calculates the total perimeter of all the forms.
        /// </summary>
        /// <param name="things">The forms.</param>
        /// <returns>The perimeter.</returns>
        public float GetPerimeter(GeometricThing[] things)
        {
            float perimeter = 0;
            foreach (var item in things)
            {
                perimeter += item.GetPerimeter();
            }
            return perimeter;
        }
    }
}
