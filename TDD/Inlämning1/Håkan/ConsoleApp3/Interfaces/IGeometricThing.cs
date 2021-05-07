namespace ConsoleApp3.Interfaces
{
    public interface IGeometricThing
    {
        /// <summary>
        /// Calculates, the area of the object.
        /// </summary>
        /// <returns>The calculated area as a float.</returns>

        public float Area();

        /// <summary>
        /// Calculates the perimiter of the object.
        /// </summary>
        /// <returns>The object perimiter as a float.</returns>
        public float Perimeter();
    }
}