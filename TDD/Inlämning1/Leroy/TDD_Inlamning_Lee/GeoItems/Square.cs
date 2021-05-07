using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Inlamning_Lee.Interfaces;

namespace TDD_Inlamning_Lee.GeoItems
{
    /// <summary>
    /// Creates a new Square object that initializes the side of it.
    /// </summary>
    public class Square : GeometricThings, IGeometricThings
    {
        public Square(float side)
        {
            Side = side;
        }

        public float GetPerimiter()
        {
            if (Side == 0) return 0;
            if (Side >= 0) return (float)Math.Round(Side * 4, 2);
            return -1;
        }

        public float GetArea()
        {
            if (Side == 0) return 0;
            if (Side >= 0) return (float)Math.Round(Side * Side, 2);
            return -1;
        }

    }
}
