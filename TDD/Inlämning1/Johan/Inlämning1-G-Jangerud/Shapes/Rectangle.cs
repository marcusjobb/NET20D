using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1_G_Jangerud.Shapes
{
    /// <summary>
    /// The rectangle class which inherits methods from GeometricThing.
    /// </summary>
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// Property value that handles the side.
        /// </summary>
        public double Side { get; set; }

        /// <summary>
        /// Property value that handles the width.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Constructor of the Rectangle class that accepts two parameters.
        /// </summary>
        /// <param name="width">The value that handles the width.</param>
        /// <param name="side">The value that handles the side.</param>
        public Rectangle(double width, double side)
        {
            this.Width = width;
            this.Side = side;
        }

        /// <summary>
        /// Method that calculates the perimeter of the Rectangle.
        /// </summary>
        /// <returns>The calculation of the perimeter. Or if the value is 0 or less, the method will return 0.</returns>
        public override double Perimeter()
        {
            if (Side < 0)
            {
                return Side = 0;
            }
            if(Width < 0)
            {
                return Width = 0;
            }
            return (Side * 2) + (Width * 2);
            
        }

        /// <summary>
        /// Method that calculates the area of the Rectangle.
        /// </summary>
        /// <returns>The calculation of the area. Or if the value is 0 or less, the method will return 0.</returns>
        public override double Area()
        {
            if (Side < 0)
            {
                return Side = 0;
            }
            if (Width < 0)
            {
                return Width = 0;
            }
            return Side * Width;
        }
    }
}
