namespace TDDInlämningGeometry.Geometrics
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculate the sum of a number of objects perimeters
        /// </summary>
        /// <param name="geothings"></param>
        /// <returns></returns>
        public float GetPerimeter(IGeometricThing[] geothings)
        {
            var allThingsPerimeter = 0f;
            foreach (var thing in geothings)
            {
                allThingsPerimeter += thing.GetPerimeter();
            }
            return allThingsPerimeter;
        }
    }
}