namespace TDDInlämningGeometry.Geometrics
{
    public interface IGeometricThing
    {
        /// <summary>
        /// Calculate area of this shape
        /// </summary>
        /// <returns></returns>
        public float GetArea();

        /// <summary>
        /// Calculate perimeter of this shape
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter();
    }
}