using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1_G_Jangerud.Shapes
{
    /// <summary>
    /// The square class which inherits methods from GeometricThing.
    /// </summary>
    public class Square : GeometricThing
    {
        /// <summary>
        /// Property of the different sides of the Square.
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Constructor of the Square class.
        /// </summary>
        /// <param name="side">Parameter that handles the value of the sides of the square.</param>
        public Square(double side)
        {
            this.Side = side;
        }

        /// <summary>
        /// Method that calculates the perimeter of the square.
        /// </summary>
        /// <returns>The calculation of the perimeter. Or if the value is 0 or less, the method will return 0.</returns>
        public override double Perimeter()
        {
            if (Side < 0)
            {
                return Side = 0;
            }
            return Side * 4;
        }

        /// <summary>
        /// Method that calculates the area of the square.
        /// </summary>
        /// <returns>The calculation of the area. Or if the value is 0 or less, the method will return 0.</returns>
        public override double Area()
        {
            if (Side < 0)
            {
                return Side = 0;
            }

            return Side * Side;
        }
    }
}
