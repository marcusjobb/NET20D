using System;
using System.Collections.Generic;
using System.Text;
using Uppgift1TDD.Math;

namespace Uppgift1TDD.GeometricItems
{
    public class Circle : Interfaces.Shape
    {
        /// <summary>
        /// Creates a Circle Shape-object, set radius. 
        /// </summary>
        public Circle(float radius)
        {
            Radius = radius;
        }
        public float Radius { get; set; }

        /// <summary>
        /// Method to calculate the area of the Circle-object 
        /// </summary>
        /// /// <returns>
        /// Float area of Circle-object
        /// </returns>
        public override float Area()
        {
            if (Radius < 0)
            {
                return 0;
            }

            float area = Radius * Radius * MathF.PI;
            return MathF.Round(area,3);
        }

        /// <summary>
        /// Method to calculate the petimeter of the Circle-object 
        /// </summary>
        /// /// <returns>
        /// Float perimeter of Circle-object
        /// </returns>
        public override float Perimeter()
        {
            if (Radius < 0)
            {
                return 0;
            }

            float perimeter = Radius + Radius * MathF.PI;
            return MathF.Round(perimeter, 3); 
        }
    }

}
