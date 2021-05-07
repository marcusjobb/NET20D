using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inlämning1_G_Jangerud;
using Inlämning1_G_Jangerud.Shapes;

namespace Inlämning1_G_Jangerud.Helpers
{
    /// <summary>
    /// The calculator class that handles all the calculations.
    /// </summary>
    public class GeometricCalculator
    {


        /// <summary>
        /// Method that handles the calculation of the area of a specific shape.
        /// </summary>
        /// <param name="shapes">Decides which shapes methods to use.</param>
        /// <returns>The result of the area calculation.</returns>
        public double GetArea(GeometricThing shapes)
        {
            return shapes.Area();
        }

        /// <summary>
        /// Method that handles the calculation of the perimeter of a specific shape.
        /// </summary>
        /// <param name="shapes">Decides which shapes methods to use.</param>
        /// <returns>The result of the perimeter calculation.</returns>
        public double GetPerimeter(GeometricThing shapes)
        {
            return shapes.Perimeter();
        }

        /// <summary>
        /// Method that handles the calculation of the perimeter of several shapes.
        /// </summary>
        /// <param name="differentShapes">Array of shapes</param>
        /// <returns>The result of the perimeter calculations.</returns>
        public double GetPerimeter(GeometricThing[] differentShapes)
        {
                double perimeter = 0;
                foreach (var shape in differentShapes)
                {
                    perimeter += shape.Perimeter();
                }
                return perimeter;
        }
        
    }
}
