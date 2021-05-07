using Inlamningsuppgift1TDD.GeometricThings;
using System;

namespace Inlamningsuppgift1TDD
{
    public class Triangle : GeometricThing
    {
        /// <summary>
        /// Triangelns höjd.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Triangelns sida.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Triangelns bas.
        /// </summary>
        public float Tbase { get; set; }
        public override float GetArea()
        {
            if (Tbase <= 0 || Height <= 0) return 0;
            return MathF.Round((Tbase * Height) / 2, 2, MidpointRounding.ToEven);
        }

        public override float GetPerimeter()
        {
            if (Tbase <= 0 || Side <= 0) return 0;
            return MathF.Round((Side * 2) + Tbase, 2, MidpointRounding.ToEven);
        }
    }
}