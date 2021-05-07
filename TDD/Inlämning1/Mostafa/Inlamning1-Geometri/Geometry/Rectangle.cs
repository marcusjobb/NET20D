using System;
using System.Collections.Generic;
using System.Text;
using Inlamning1_Geometri.Interface;

namespace Inlamning1_Geometri.Geometry
{
    public class Rectangle : IGeometryThing
    {
        public float TBase { get; set; }
        public float Height { get; set; }

        /// <summary>
        /// Method with parameter
        /// </summary>
        /// <param name="tbase"></param>
        /// <param name="height"></param>
        public Rectangle(float tbase, float height)
        {
            TBase = tbase;
            Height = height;
        }

        /// <summary>
        /// Area in Rectangle
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            return TBase * Height;
        }

        /// <summary>
        /// Permiter in Rectangle
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter()
        {
            return TBase + Height + TBase + Height;
        }
    }
}
