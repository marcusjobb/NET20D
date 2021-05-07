using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjin_inlamning_g.Shape
{
   public class Triangle : GeometricThing
    {
        public float Base { get; set;  }
        public float Height { get; set; }
        /// <summary>
        /// The base and the height of the object
        /// </summary>
        /// <param name="tbase"></param>
        /// <param name="hight"></param>
        public Triangle(float tbase, float hight)
        {
            Base = tbase;
            Height = hight;
        }
        public Triangle(float tbase)
        {
            Base = tbase;
        }

        /// <summary>
        /// Get's the area of the triangle
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            if (Base < 0)
            {
                return Base = 0;
            }
            return Base * Height / 2;
        }

        /// <summary>
        /// Get's the perimeters of the square
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            if (Base < 0)
            {
                return Base = 0;
            }
            return Base * 3;
        }
    }
}
