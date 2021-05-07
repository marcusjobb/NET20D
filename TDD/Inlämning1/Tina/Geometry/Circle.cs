using System;

namespace TDD_TinaEriksson 
{
    /// <summary>
    /// A class for circle that inherits from 
    /// IGeomatricThing.
    /// </summary>
    public class Circle : IGeomatricThing
    {
        /// <summary>
        /// A field for radius.
        /// </summary>
        public float radius;

        /// <summary>
        /// The constructor with a parameter to 
        /// initialize the value of the radius.
        /// </summary>
        /// <param name="radius">The radius of the circle 
        /// created.</param>
        public Circle(float radius)
        {
            this.radius = radius;
        }

        public float GetArea()
        {
            if(radius <= 0) { return 0; }
            return MathF.PI * MathF.Pow(radius, 2);
        }

        public float GetPerimeter()
        {
            if(radius <= 0) { return 0; }
            return 2 * MathF.PI * radius;
        }
    }
}