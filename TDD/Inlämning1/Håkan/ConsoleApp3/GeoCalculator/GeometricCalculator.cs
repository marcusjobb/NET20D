using ConsoleApp3.Interfaces;

namespace ConsoleApp3.GeoCalculator
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Takes an array of objects and calculates the combined perimiter
        /// for all the objects.
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns>Total perimiter as a float if success. 0 if the array is empty.</returns>
        public float GetPerimeter(IGeometricThing[] shapes)
        {
            var total = 0f;
            if (shapes == null)
            {
                return 0f;
            }

            if (shapes.Length > 0)
            {
                foreach (var shape in shapes)
                {
                    total += shape.Perimeter();
                }

                return total;
            }

            return 0f;
        }
    }
}