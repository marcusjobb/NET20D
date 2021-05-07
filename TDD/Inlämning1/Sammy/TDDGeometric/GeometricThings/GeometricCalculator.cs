using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDGeometric.GeometricThings.GeoShapes;

namespace TDDGeometric.GeometricThings
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Summan av arean av alla objekt som skickas in 
        /// </summary>
        /// <param name="shape"></param>
        /// <returns>Den totala arean av alla objekt i en array</returns>
        public float GetArea(GeometricShapes[] shapes)
        {
            if(shapes != null)
            {
                var areaOfShapes = 0.0f;
                foreach (var shape in shapes)
                {
                    areaOfShapes += shape.GetArea();
                }
                return areaOfShapes;
            }
            return default;
        }
        
        /// <summary>
        /// Summa av omkretser av alla objekt som skickas in
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns>Den totala omkretsen av alla objekt i arrayen</returns>
        public float GetPerimeter(GeometricShapes[] shapes)
        {
            if (shapes != null)
            {
                var perimeterOfShapes = 0.0f;
                foreach (var shape in shapes) 
                { 
                    perimeterOfShapes += shape.GetPerimiter(); 
                }
                return perimeterOfShapes;
            }
            return default;
        }
    }
}
