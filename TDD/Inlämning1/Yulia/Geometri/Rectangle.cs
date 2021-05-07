using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Geometri
{
    public class Rectangle : GeometricShapes
    {
        public Rectangle()
        {  
        }
        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }
        public float Width { get; set; }
        public float Height { get; set; }
        /// <summary>
        /// Returns area of rectangular
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            if (Width <= 0 || Height <= 0) return 0;
            return (float)Math.Round(Width * Height, 3);
        }
        /// <summary>
        /// Returns perimeter of rectangular
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            if (Width <= 0 || Height <= 0) return 0;
            return (float)Math.Round((2 * Width) + (2 * Height), 3);
        }
    }
    
}
