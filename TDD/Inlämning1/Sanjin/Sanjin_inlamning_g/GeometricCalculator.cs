using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sanjin_inlamning_g.Shape;

namespace Sanjin_inlamning_g
{
    /// <summary>
    /// Calculates the total circumference and area of all objects
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Gets the perimeter of the object
        /// </summary>
        /// <returns>The perimeter</returns>
        public float GetPerimeter(GeometricThing shape)
        {
            return shape.GetPerimeter();
        }
        
        /// <summary>
        /// Gets the area of the object
        /// </summary>
        /// <returns>The area</returns>
        public  float GetArea(GeometricThing shape)
        {
            return shape.GetPerimeter();
        }

        /// <summary>
        /// Calculates the total circumference of several figures
        /// </summary>
        /// <param name="listOfShapes"></param>
        /// <returns>circumference of several figures</returns>
        public float GetPerimeter(GeometricThing[] listOfShapes)
        {
            float perimeter = 0;
            foreach (var shape in listOfShapes)
            {
                perimeter += shape.GetPerimeter();
            }
            return perimeter;
        }
    }
}
