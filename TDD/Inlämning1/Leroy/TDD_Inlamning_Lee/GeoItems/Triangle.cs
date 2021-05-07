using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Inlamning_Lee.Interfaces;

namespace TDD_Inlamning_Lee.GeoItems
{
    /// <summary>
    /// Creates a new Triangle object that initializes either the width and height or a side
    /// depending on witch constructor is used.
    /// </summary>
    public class Triangle : GeometricThings, IGeometricThings
    {
        public Triangle (float width, float height)
        {
            Width = width;
            Height = height;
            Equilateral = false;
        }

        public Triangle(float side, bool equilateral)
        {
            Side = side;
            Equilateral = equilateral;
        }

        public float GetPerimiter()
        {
            if (Equilateral)
            {
                if (Side == 0) return 0;                
                if (Side > 0) return (float)Math.Round(Side * 3, 2);
                return -1;
            }
            else
            {
                if (Width == 0 || Height == 0) return 0;
                float leftSide = MathF.Sqrt((float)Math.Pow(Width / 2, 2) + (float)Math.Pow(Height, 2));
                if (Width >= 0 && Height >= 0) return (float)Math.Round(leftSide * 2 + Width, 2);
                return -1;
            }
        }

        public float GetArea()
        {
            if (Width == 0 || Height == 0) return 0;
            if (Width >= 0 && Height >= 0) return (float)Math.Round(Width * Height * 0.5f, 2);
            return -1;
        }
    }
}
