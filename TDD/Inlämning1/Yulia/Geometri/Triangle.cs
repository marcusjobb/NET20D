using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public class Triangle : GeometricShapes
    {
        public Triangle()
        {
        }
        public Triangle(float tBase, float tHeight, float sideA, float sideC)
        {
            Tbase = tBase;
            Theight = tHeight;
            SideA = sideA;
            SideC = sideC;
        }
        public float Tbase { get; set; }
        public float Theight { get; set; }
        public float SideA { get; set; }
        public float SideC { get; set; }
        /// <summary>
        /// Returns area of triangle
        /// </summary>
        /// <returns></returns>
        public override float GetArea()
        {
            if (Tbase<=0|| Theight <= 0 ) return 0;
            return (float)Math.Round(Tbase / 2 * Theight, 3);
        }
        /// <summary>
        /// Returns perimeter of triangle
        /// </summary>
        /// <returns></returns>
        public override float GetPerimeter()
        {
            if (Tbase <= 0 || SideA <= 0 || SideC <= 0) return 0;
            return (float)Math.Round(Tbase + SideA + SideC, 3);
        }
    }
}
