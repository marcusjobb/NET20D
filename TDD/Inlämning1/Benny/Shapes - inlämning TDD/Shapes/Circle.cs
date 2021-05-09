using System;

namespace Shapes___inlämning_TDD
{
    //Comments for interface implemented methods are in the interface class
    public class Circle : IGeometricThing
    {
        /// <summary>
        /// Constructor for a circle
        /// </summary>
        /// <param name="radius">Takes a float as the radius.</param>
        public Circle(float radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Property for radius
        /// </summary>
        public float Radius { get; set; }

        public float CalculateArea()
        {
            if (Radius <= 0)
            {
                return 0;
            }

            return MathF.PI * (MathF.Pow(Radius, 2));
        }

        public float GetPerimeter()
        {
            if (Radius <= 0)
            {
                return 0;
            }

            return MathF.PI * 2 * Radius;
        }
    }
}