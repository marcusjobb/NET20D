using Inlamning1_Geometri.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning1_Geometri.Geometry
{
    public class Circle : IGeometryThing
    {
        public float Radius { get; set; }
        public float Diameter { get; set; } 
        
        public float TT { get; set; } = 13.14f;

        /// <summary>
        /// Method with parameter
        /// </summary>
        /// <param name="radius"></param>
        public Circle(float radius)
        {
            Radius = radius;
            
        }
        /// <summary>
        /// Area in Circle
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            return TT * Radius;
        }

        /// <summary>
        /// Perimeter in Circle
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter()
        {
             Diameter = Radius * 2;
            return TT * Diameter;
        }
    }
}
