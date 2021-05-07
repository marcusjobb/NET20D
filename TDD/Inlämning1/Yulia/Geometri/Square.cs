using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Geometri
{
    public class Square : GeometricShapes
    {
        public Square()
        {
        }

        public Square(float height)
        {
            Height = height;
        }
        public float Height { get; set; }
        /// <summary>
        /// Returns area of square
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            if (Height <= 0) return 0;
            return (float)Math.Round(Height * Height, 3);        
        }
        /// <summary>
        /// Returns perimeter of square
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            if (Height <= 0) return 0;
            return (float)Math.Round(4 * Height, 3);
        }
    }
}       
