namespace GeometricThings.Geometry
{
    using GeometricThings.Interface;

    /// <summary>
    /// Defines the <see cref="Rectangle" />.
    /// </summary>
    public class Rectangle : IGeometricThing
    {
        /// <summary>
        /// Gets or sets the Width.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the Height.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">The width<see cref="float"/>.</param>
        /// <param name="height">The height<see cref="float"/>.</param>
        public Rectangle(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Calculates and returns the perimeter if width and height are greater than 0, else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetPerimeter()
        {
            return (Width > 0 && Height > 0) ? ((Width + Height) * 2) : 0;
        }

        /// <summary>
        /// Calculates and returns the area if width and height are greater than 0 else returns 0
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetArea()
        {
            return (Width > 0 && Height > 0) ? Width * Height : 0;
        }
    }
}
