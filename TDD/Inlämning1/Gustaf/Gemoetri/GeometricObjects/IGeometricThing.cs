namespace Geometri.GeometricObjects
{
    interface IGeometricThing
    {
        /// <summary>
        /// Calculates the objects circumference
        /// </summary>
        /// <returns>The circumference</returns>
        float Circumference();
        /// <summary>
        /// Calculates the objects area
        /// </summary>
        /// <returns>The area</returns>
        float Area();
    }
}
