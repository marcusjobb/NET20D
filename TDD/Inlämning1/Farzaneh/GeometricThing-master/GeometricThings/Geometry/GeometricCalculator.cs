namespace GeometricThings.Geometry
{
    using GeometricThings.Interface;

    /// <summary>
    /// Defines the <see cref="GeometricCalculator" />.
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Returns area of an object if the object is not null, else returns 0
        /// </summary>
        /// <param name="thing">The thing<see cref="IGeometricThing"/>.</param>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetArea(IGeometricThing thing)
        {
            return thing != null ? thing.GetArea() : 0;
        }

        /// <summary>
        /// Returns perimeter of an object if the object is not null, else returns 0
        /// </summary>
        /// <param name="thing">The thing<see cref="IGeometricThing"/>.</param>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetPerimeter(IGeometricThing thing)
        {
            return thing != null ? thing.GetPerimeter() : 0;
        }

        /// <summary>
        /// Returns the sum of perimetes of objects in an array
        /// </summary>
        /// <param name="things">The things<see cref="IGeometricThing []"/>.</param>
        /// <returns>The <see cref="float"/>.</returns>
        public float GetPerimeter(IGeometricThing[] things)
        {
            float sam = 0;
            foreach (var item in things)
            {
                sam += GetPerimeter(item);
            }
            return sam;
        }
    }
}
