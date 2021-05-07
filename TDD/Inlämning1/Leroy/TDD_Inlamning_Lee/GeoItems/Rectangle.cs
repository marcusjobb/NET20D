using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Inlamning_Lee.Interfaces;

namespace TDD_Inlamning_Lee.GeoItems
{
    /// <summary>
    /// Creates a new Rectangle object that initializes the width and height.
    /// </summary>
    public class Rectangle : GeometricThings, IGeometricThings
    {
        public Rectangle(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float GetPerimiter()
        {
            if (Width == 0 || Height == 0) return 0;
            if (Width >= 0 && Height >= 0) return (float)Math.Round(Width * 2 + Height * 2, 2);
            return -1;
        }

        public float GetArea()
        {
            if (Width == 0 || Height == 0) return 0;
            if (Width >= 0 && Height >= 0) return (float)Math.Round(Width * Height, 2);
            return -1;
        }
    }
}
