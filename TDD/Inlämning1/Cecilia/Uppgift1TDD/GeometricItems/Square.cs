using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems
{
    public class Square : Interfaces.Shape
    {
        /// <summary>
        /// Creates a Square Shape-object, set side-amount. 
        /// </summary>
        public Square(float side)
        {
            Side = side;
        }

        public float Side { get; set; }

        /// <summary>
        /// Method to calculate the area of the Square-object 
        /// </summary>
        /// /// <returns>
        /// Float area of Square-object
        /// </returns>
        public override float Area()
        {
            if (Side < 0)
            {
                return 0;
            }

            return Side * Side;
        }

        /// <summary>
        /// Method to calculate the petimeter of the Square-object 
        /// </summary>
        /// /// <returns>
        /// Float perimeter of Square-object
        /// </returns>
        public override float Perimeter()
        {
            return Side * 4;
        }
    }
}
