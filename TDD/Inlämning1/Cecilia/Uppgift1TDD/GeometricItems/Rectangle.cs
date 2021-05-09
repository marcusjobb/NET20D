using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems
{
    public class Rectangle : Interfaces.Shape
    {
        /// <summary>
        /// Creates a Rectangle Shape-object, set width and height. 
        /// </summary>
        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }
        public float Width { get; set; }
        public float Height { get; set; }

        /// <summary>
        /// Method to calculate the area of the Rectangle-object 
        /// </summary>
        /// /// <returns>
        /// Float area of Rectangle-object
        /// </returns>
        public override float Area()
        {
            if (Width < 0 || Height < 0)
            {
                return 0;
            }

            return Width * Height;
        }

        /// <summary>
        /// Method to calculate the petimeter of the Rectangle-object 
        /// </summary>
        /// /// <returns>
        /// Float perimeter of Rectangle-object
        /// </returns>
        public override float Perimeter()
        {
            if (Width < 0 || Height < 0)
            {
                return 0;
            }

            return Width + Width + Height + Height;
        }
    }
}
