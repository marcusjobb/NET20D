namespace GeometryProject.GeoModels
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// Perimeter property for shape of subclasses.
        /// </summary>
        public float Perimeter { get; set; }

        /// <summary>
        /// Area property of shape of subclasses.
        /// </summary>
        public float Area { get; set; }

        /// <summary>
        /// Opens up the possibility for sub classes to inherit the GetArea method.
        /// </summary>
        /// <returns>Float default value</returns>
        public virtual float GetArea()
        {
            return default;
        }

        /// <summary>
        /// Opens up the possibility for sub classes to inherit the GetPerimeter method.
        /// </summary>
        /// <returns>Float default value</returns>
        public virtual float GetPerimeter()
        {
            return default;
        }
    }
}