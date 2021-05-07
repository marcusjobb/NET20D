namespace GeometricThings.Geometry
{
    using GeometricThings.Interface;

    /// <summary>
    /// Defines the <see cref="Triangle" />.
    /// </summary>
    public class Triangle : IGeometricThing
    {
        /// <summary>
        /// Gets or sets the Side.
        /// </summary>
        public float Side { get; set; }

        /// <summary>
        /// Gets or sets the Height.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="side">The side<see cref="float"/>.</param>
        /// <param name="height">The height<see cref="float"/>.</param>
        public Triangle(float side, float height)
        {
            this.Side = side;
            this.Height = height;
        }

        /// <summary>
        /// Calculates and returns the area if side and height are greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetArea()
        {
            return (Side > 0 && Height > 0) ? (Side * Height) / 2 : 0;
        }

        /// <summary>
        /// Calculates and returns the perimeter if side and height are greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetPerimeter()
        {
            return (Side > 0 && Height > 0) ? (Side * 2) + Height : 0;
        }
    }
}
