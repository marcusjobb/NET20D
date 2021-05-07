namespace GeometricThings.Interface
{
    /// <summary>
    /// Defines the <see cref="IGeometricThing" />.
    /// </summary>
    public interface IGeometricThing
    {
        /// <summary>
        /// Calculates the perimeter of a geometric shape
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public abstract float GetPerimeter();

        /// <summary>
        /// Calculates the area of a geometric shape
        /// </summary>
        /// <returns>The <see cref="float"/>.</returns>
        public abstract float GetArea();
    }
}
