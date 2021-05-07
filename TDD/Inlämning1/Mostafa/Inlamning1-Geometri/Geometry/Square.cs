using System;
using System.Collections.Generic;
using System.Text;
using Inlamning1_Geometri.Interface;

namespace Inlamning1_Geometri.Geometry
{
    public class Square : IGeometryThing
    {
        public float Width { get; set; }
       
        /// <summary>
        /// Method with parameter
        /// </summary>
        /// <param name="width"></param>
        public Square(float width)
        {
            Width = width;
           
        }

        /// <summary>
        /// Area in Square
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            return Width * Width;
        }

        /// <summary>
        /// Perimeter in Square
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter()
        {
            return Width * 4;
        }
    }
}
