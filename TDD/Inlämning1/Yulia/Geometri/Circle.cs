using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Circle : GeometricShapes
    {
        public Circle()
        {
        }
        public Circle (float radius)
        {
            Radius = radius;
        }

        public float Radius { get; set; }
        /// <summary>
        /// Returns area of circle
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            if (Radius <= 0) return 0;
            return (float)Math.Round(Radius * Radius * Math.PI,3);
        }
        /// <summary>
        /// Returns perimeter of circle
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            if (Radius <= 0) return 0;
            return (float)Math.Round(2 * Radius * Math.PI,3);
        }
    }

}
