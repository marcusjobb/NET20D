using Inlamningsuppgift1TDD.GeometricThings;
using System;

namespace Inlamningsuppgift1TDD
{
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// Rektangelns höjd.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Rektangelns bredd.
        /// </summary>
        public float Width { get; set; }

        public override float GetArea()
        {
            if (Height < 0 || Width < 0) return 0;
            return MathF.Round(Height * Width, 2, MidpointRounding.ToEven);
        }

        public override float GetPerimeter()
        {
            if (Height < 0 || Width < 0) return 0;
            return MathF.Round((Height + Width) * 2, 2, MidpointRounding.ToEven);
        }
    }
}