using Inlamningsuppgift1TDD.GeometricThings;
using System;

namespace Inlamningsuppgift1TDD
{
    public class Square : GeometricThing
    {
        /// <summary>
        /// Kvadratens sida.
        /// </summary>
        public float Side { get; set; }

        public override float GetArea()
        {
            if (Side <= 0) return 0;
            return MathF.Round(Side * Side, 2, MidpointRounding.ToEven);
        }

        public override float GetPerimeter()
        {
            if (Side <= 0) return 0;
            return MathF.Round(Side * 4, 2, MidpointRounding.ToEven);
        }
    }
}