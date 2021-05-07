using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD_Inlamning_Lee.Interfaces;

namespace TDD_Inlamning_Lee.GeoItems
{
    /// <summary>
    /// Creates a new Circle object that initializes the radius.
    /// </summary>
    public class Circle : GeometricThings, IGeometricThings
    {
        public Circle(float radius)
        {
            Radius = radius;
        }

        public float GetPerimiter()
        {
            if (Radius == 0) return 0;
            if (Radius >= 0) return MathF.Round((float)(Radius * 2 * Math.PI), 2);
            return -1;
        }

        public float GetArea()
        {
            if (Radius == 0) return 0;
            if (Radius >= 0) return MathF.Round((float)(Radius * Radius * Math.PI), 2);
            return -1;
        }
    }
}
