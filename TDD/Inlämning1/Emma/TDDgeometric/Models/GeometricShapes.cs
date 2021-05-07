namespace TDDgeometric.Models
{
    public abstract class GeometricShapes
    {
        /// <summary>
        /// Get the area of an object
        /// </summary>
        /// <returns>float Area</returns>
        public virtual float GetArea()
        {
            return default;
        }

        /// <summary>
        /// Get the perimiter of an object
        /// </summary>
        /// <returns>float Perimiter</returns>
        public virtual float GetPerimiter()
        {
            return default;
        }
    }
}
