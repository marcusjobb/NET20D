using System;

namespace Geometri.GeometricObjects
{
    public class Triangle : GeometricThing
    {
        /// <summary>
        /// Constructor that takes two arguments, length and height. Assumes right triangle
        /// </summary>
        /// <param name="length">Length parameter</param>
        /// <param name="height">Height parameter</param>
        public Triangle(float length, float height) : base(length, height)
        {
            if (ValidateInput(length))
            {
                Length = length;
            }
            else
                Length = 1.0f;
            if (ValidateInput(height))
            {
                Height = height;
            }
            else
                Height = 1.0f;
        }
        #region Equations
        /// <summary>
        /// Caluclates the circumference.
        /// </summary>
        /// <returns></returns>
        public override float Circumference()
        {
            return (float)Math.Sqrt(Length * Length + Height * Height) + Length + Height;
        }
        /// <summary>
        /// Calculates the area
        /// </summary>
        /// <returns>The area</returns>
        public override float Area()
        {
            return Length * Height / 2;
        }
        #endregion
    }
}
