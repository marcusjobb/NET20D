namespace GeometricJesperPersson.Shapes
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// Gets the area of each form that inheritate this class.
        /// </summary>
        /// <returns>the area in a float.</returns>
        public virtual float GetArea() => default;

        /// <summary>
        /// Gets the perimeter of each form that inheritate this class.
        /// </summary>
        /// <returns>the perimeter in a float.</returns>
        public virtual float GetPerimeter() => default;
    }
}