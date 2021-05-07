namespace TDD_TinaEriksson
{
    /// <summary>
    /// The interface class that the different
    /// geomatric shapes inherits from.
    /// </summary>
    public interface IGeomatricThing
    {
        /// <summary>
        /// Calculates the area of the current shape
        /// and then returns it.
        /// </summary>
        /// <returns>The area of the current shape.</returns>
        public float GetArea();
        /// <summary>
        /// Calculates the perimeter of the current shape
        /// and then returns it.
        /// </summary>
        /// <returns>The perimeter of the current shape.</returns>
        public float GetPerimeter();
    }
}