namespace Shapes___inlämning_TDD
{
    public interface IGeometricThing
    {
        /// <summary>
        /// Calculates the area of the shape and if any of the sides or radius
        /// is 0 returns 0.
        /// </summary>
        /// <returns>returns a float with the result. or 0 if negative or zero value</returns>
        public float CalculateArea();

        /// <summary>
        /// Calculates the perimeter around the shape
        /// </summary>
        /// <returns>A float with the actual perimeter or 0 if negative value or zero</returns>
        public float GetPerimeter();
    }
}