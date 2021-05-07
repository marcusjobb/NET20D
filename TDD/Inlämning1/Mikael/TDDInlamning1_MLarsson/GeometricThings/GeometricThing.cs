namespace TDDInlamning1_MLarsson
{
    /// <summary>
    /// Abstract class to be inheritated by different shapes.
    /// Holds properties Perimeter and Area, and abstract functions GetPerimeter() and GetArea().
    /// </summary>
   public abstract class GeometricThing
    {
        public float Perimeter { get; set; }
        public float Area { get; set; }

        /// <summary>
        /// Calculates the perimeter of a shape.
        /// </summary>
        /// <returns>The perimeter as a float.</returns>
        public abstract float GetPerimeter();

        /// <summary>
        /// Calculates the area of a shape.
        /// </summary>
        /// <returns>The area as a float.</returns>
        public abstract float GetArea();
    }
}
