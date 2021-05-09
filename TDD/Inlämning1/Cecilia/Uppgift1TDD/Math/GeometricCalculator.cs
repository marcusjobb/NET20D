using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uppgift1TDD.Interfaces;

namespace Uppgift1TDD.Math
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Method to get the area of a Shape-item 
        /// </summary>
        /// /// <returns>
        /// Float sum of area
        /// </returns>
        public float GetArea(Shape shape)
        {
            return shape.Area();
        }

        /// <summary>
        /// Method to get the perimeter of one Shape-item 
        /// </summary>
        /// /// <returns>
        /// Float sum of perimeter
        /// </returns>
        public float GetPerimeter(Shape shape)
        {
            return shape.Perimeter();
        }

        /// <summary>
        /// Method to get the perimeter of an Array of Shape-items 
        /// </summary>
        /// /// <returns>
        /// Float perimeter of all Shapes in Array
        /// </returns>
        public float GetPerimeter(Shape[] shape)
        {
            float addedPerimeter = 0;

            foreach (var num in shape)
            {
                addedPerimeter += num.Perimeter();
            }

            return addedPerimeter;
        }
    }
}
