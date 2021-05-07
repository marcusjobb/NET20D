namespace Inlamningsuppgift1TDD.Geometric
{
    /// <summary>
    /// Interface for all geometric objects
    /// </summary>
    public interface IGeometric
    {
        /// <summary>
        /// Method to calculate area of object
        /// </summary>
        /// <returns>Area as type float</returns>
        public float GetArea();

        /// <summary>
        /// Method for calcualting perimeter of object
        /// </summary>
        /// <returns>Perimeter as type float</returns>
        public float GetPerimeter();
    }
}
