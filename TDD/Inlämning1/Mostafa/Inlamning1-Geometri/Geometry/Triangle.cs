using Inlamning1_Geometri.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamning1_Geometri.Geometry
{
    public class Triangle:IGeometryThing
    {
        public float TBase { get; set; }
        public float Height { get; set; }

        /// <summary>
        /// Method with parameter
        /// </summary>
        /// <param name="_base"></param>
        /// <param name="_height"></param>
        public Triangle(float _base, float _height)
        {
            TBase = _base; 
            Height = _height;
        }

        /// <summary>
        /// Are in Triangle
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            return (TBase * Height) / 2;
        }

        /// <summary>
        /// Perimeter in Triangle
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter()
        {
            return TBase * 3;
        }
    }
}
