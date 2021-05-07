using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlämning1_G_Jangerud.Shapes
{
    /// <summary>
    /// The triangle class which inherits methods from GeometricThing.
    /// </summary>
    public class Triangle : GeometricThing
    {
        /// <summary>
        /// Property for the base of the triangle.
        /// </summary>
        public double Base { get; set; }

        /// <summary>
        /// Property for the two sides, used the name Height here.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Constructor for the Triangle class.
        /// </summary>
        /// <param name="tbase">The base of the triangle</param>
        /// <param name="height">The side of the triangle</param>
        public Triangle(double tbase, double height)
        {
            this.Base = tbase;
            this.Height = height;
        }

        /// <summary>
        /// Constructor of the Triangle class with only one property.
        /// </summary>
        /// <param name="tbase">Base parameter of the triangle</param>
        public Triangle(double tbase)
        {
            this.Base = tbase;
        }

        /// <summary>
        /// Method that calculates the perimeter of the Triangle.
        /// </summary>
        /// <returns>Returns the actual calculation.</returns>
        public override double Perimeter()
        {
            if (Base < 0)
            {
                return Base = 0;
            }
            return Base * 3;
        }

        /// <summary>
        /// Method that calculates the area of the Triangle.
        /// </summary>
        /// <returns>Returns the actual calculation.</returns>
        public override double Area()
        {
            if (Base < 0)
            {
                return Base = 0;
            }
            if (Height < 0)
            {
                return Height = 0;
            }
            return (Base * Height) / 2;
        }
    }
}
