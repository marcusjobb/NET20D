namespace Geometry.Abstracts
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// Calculates the area.
        /// </summary>
        /// <returns>The area as a <see cref="float"/>.</returns>
        public abstract float Area();

        /// <summary>
        /// Calculates the perimiter.
        /// </summary>
        /// <returns>The perimiter as a <see cref="float"/>.</returns>
        public abstract float Perimiter();
    }
}
