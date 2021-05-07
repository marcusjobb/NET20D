using Inlamningsuppgift1TDD.GeometricThings;
using System;

namespace Inlamningsuppgift1TDD
{
    public class Circle : GeometricThing
    {
        /// <summary>
        /// Talet Pi som har avrundats till två decimaler (3.14).
        /// </summary>
        public float mathPi = MathF.Round((float)Math.PI, 2);

        /// <summary>
        /// Radien på cirkeln.
        /// </summary>
        public float Radius { get; set; }
        public override float GetArea()
        {
            if (Radius <= 0) return 0;
            return MathF.Round((Radius * Radius) * mathPi, 2, MidpointRounding.ToEven);
        }

        public override float GetPerimeter()
        {
            if (Radius <= 0) return 0;
            return MathF.Round((Radius + Radius) * mathPi, 2, MidpointRounding.ToEven);
        }
    }
}