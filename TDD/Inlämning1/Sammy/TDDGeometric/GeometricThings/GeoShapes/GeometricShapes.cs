namespace TDDGeometric.GeometricThings.GeoShapes
{
    public abstract class GeometricShapes
    {
        /// <summary>
        /// Hämta objektets area
        /// </summary>
        /// <returns>float Area</returns>
        public virtual float GetArea() { return default; }

        /// <summary>
        /// Hämta objektets omkrets
        /// </summary>
        /// <returns>float Perimiter</returns>
        public virtual float GetPerimiter() { return default; }
    }
}
