using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanjin_inlamning_g.Shape
{
  public  class Rectangle : GeometricThing
    {
        public float Width { get; set; }
        public float Lenght { get; set; }
        /// <summary>
        /// The width and the lenght of the object
        /// </summary>
        /// <param name="width"></param>
        /// <param name="lenght"></param>
        public Rectangle(float width, float lenght)
        {
            Width = width;
            Lenght = lenght;
        }

        /// <summary>
        /// Gets the area of the rectangle
        /// </summary>
        /// <returns>area</returns>
        public override float GetArea()
        {
            return Lenght * Width;
        }

        /// <summary>
        /// Gets the perimeters of the rectangle
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            return (Lenght * 2) + (Width * 2);
        }
    }
}
