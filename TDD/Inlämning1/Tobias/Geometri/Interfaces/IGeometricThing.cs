namespace Geometri.Interfaces
{
    /// <summary>
    /// Defines IGeometricThing
    /// </summary>
    public interface IGeometricThing
    {
        /// <summary>
        /// A method for calculating the Area of diffrent shapes
        /// </summary>
        /// <returns>float Area</returns>
        public float Area();

        /// <summary>
        /// A method for calculating the Perimeter of diffrent shapes
        /// </summary>
        /// <returns>float Perimeter</returns>
        public float Perimeter();
    }
}