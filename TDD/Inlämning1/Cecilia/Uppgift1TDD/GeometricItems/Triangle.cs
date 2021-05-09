using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1TDD.GeometricItems
{
    public class Triangle : Interfaces.Shape
    {
        /// <summary>
        /// Creates a Triangle Shape-object, set width and height. 
        /// </summary>
        public Triangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; set; }
        public float Height { get; set; }

        /// <summary>
        /// Method to calculate the area of the Triangle-object 
        /// </summary>
        /// /// <returns>
        /// Float area of Triangle-object
        /// </returns>
        public override float Area()
        {
            if (Width < 0 || Height < 0)
            {
                return 0;
            }

            float a = Width * Height;
            return a / 2;
        }

        /// <summary>
        /// Method to calculate the petimeter of the Triangle-object 
        /// </summary>
        /// /// <returns>
        /// Float perimeter of Triangle-object
        /// </returns>
        public override float Perimeter()
        {
            if (Width < 0 || Height < 0)
            {
                return 0;
            }

            return Width + Height + Height;
        }
    }
}
