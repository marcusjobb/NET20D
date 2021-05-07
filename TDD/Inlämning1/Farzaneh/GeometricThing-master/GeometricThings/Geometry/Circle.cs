namespace GeometricThings.Geometry
{
    using GeometricThings.Interface;
    using System;

    /// <summary>
    /// Defines the <see cref="Circle" />.
    /// </summary>
    public class Circle : IGeometricThing
    {
        /// <summary>
        /// Gets or sets the Radius.
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">The radius<see cref="float"/>.</param>
        public Circle(float radius)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// calculates and returns the area if radius is greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetArea()
        {
            return (Radius > 0) ? (float)Math.Pow(Radius, 2) * (float)Math.PI : 0;
        }

        /// <summary>
        /// calculates and returns the perimeter if radius is greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetPerimeter()
        {
            return (Radius > 0) ? 2 * (Radius * (float)Math.PI) : 0;
        }
    }
}
