namespace Inlamningsuppgift1TDD.GeometricThings
{
    public abstract class GeometricThing
    {
        /// <summary>
        /// Räknar ut arean för den geometriska formen.
        /// </summary>
        /// <returns>Arean på den geometriska formen</returns>
        public abstract float GetArea();

        /// <summary>
        /// Räknar ut omkretsen på den geometriska formen.
        /// </summary>
        /// <returns>Omkretsen på den geometriska formen</returns>
        public abstract float GetPerimeter();
    }
}