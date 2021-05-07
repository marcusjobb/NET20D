using Inlamning1_Geometri.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inlamning1_Geometri.Geometry
{
    public class GeometriyCalculator
    {

        /// <summary>
        /// Calculate the permiter for all figures
        /// </summary>
        /// <param name="geometryThings"></param>
        /// <returns>Sum of the figures</returns>
        public float GetPerimeter(List<IGeometryThing> geometryThings)
        {
            float sum = 0;
            geometryThings.Add(new Triangle(5, 5));
            geometryThings.Add(new Circle(10));
            geometryThings.Add(new Square(15));
            geometryThings.Add(new Rectangle(15, 5));
          
            for (int i = 0; i < geometryThings.Count; i++)
            {
                sum += geometryThings[i].GetPerimeter();
            }
           
            return sum;
        }

       
    }
}
