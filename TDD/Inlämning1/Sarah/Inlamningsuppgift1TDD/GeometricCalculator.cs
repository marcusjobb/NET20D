using Inlamningsuppgift1TDD.GeometricThings;
using System;

namespace Inlamningsuppgift1TDD
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Hämtar arean av varje figur i arrayen och summerar ihop dom.
        /// </summary>
        /// <param name="things">En array med geometriska former</param>
        /// <returns>Den sammanslagda summan av flera figurers area</returns>
        public float GetArea(GeometricThing[] things)
        {
            float sumOfArea = 0;
            if (things == null) return 0;
            foreach (var thing in things)
            {
                sumOfArea += thing.GetArea();
            }
            return MathF.Round(sumOfArea, 2, MidpointRounding.ToEven);
        }

        /// <summary>
        /// Hämtar omkretsen av varje figur i arrayen och summerar ihop dom.
        /// </summary>
        /// <param name="things">En array med geometriska former</param>
        /// <returns>Den sammanslagda summan av flera figurers omkretsar</returns>
        public float GetPerimeter(GeometricThing[] things)
        {
            float sumOfPerimeter = 0;
            if (things == null) return 0;
            foreach (var thing in things)
            {
                sumOfPerimeter += thing.GetPerimeter();
            }
            return MathF.Round(sumOfPerimeter, 2, MidpointRounding.ToEven);
        }
    }
}