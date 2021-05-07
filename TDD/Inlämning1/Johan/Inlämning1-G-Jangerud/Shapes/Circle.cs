using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1_G_Jangerud.Shapes
{
    /// <summary>
    /// The circle class which inherits methods from GeometricThing.
    /// </summary>
    public class Circle : GeometricThing
    {
        /// <summary>
        /// Property that handles the radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Constructor of the Circle.
        /// </summary>
        /// <param name="radius">Parameter value that is included in the creation of a circle.</param>
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Method that calculates the area of the Circle.
        /// </summary>
        /// <returns>Returns the calculation of the area. Or if the value is 0 or less, the method will return 0.</returns>
        public override double Area()
        {
            if (Radius < 0)
            {
                return Radius = 0;
            }
            return (float)Radius * Radius * Math.PI;
        }

        /// <summary>
        /// Method that calculates the perimeter of the Circle.
        /// </summary>
        /// <returns>The calculation of the perimeter. Or if the value is 0 or less, the method will return 0.</returns>
        public override double Perimeter()
        {
            if (Radius < 0)
            {
                return Radius = 0;
            }
            return (2 * Radius) * (float)Math.PI;
        }
    }
}
