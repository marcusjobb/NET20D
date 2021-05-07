namespace GeometricThings.Geometry
{
    using GeometricThings.Interface;
    using System;

    /// <summary>
    /// Defines the <see cref="Square" />.
    /// </summary>
    public class Square : IGeometricThing
    {
        /// <summary>
        /// Gets or sets the Side.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        public Square(float side)
        {
            this.Side = side;
        }

        /// <summary>
        /// Calculates and returns the perimeter if side is greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetPerimeter()
        {
            return (Side > 0) ? 4 * Side : 0;
        }

        /// <summary>
        /// Calculates and returns the area if side is greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetArea()
        {
            return (Side > 0) ? (float)Math.Pow(Side, 2) : 0;
        }
    }
}
