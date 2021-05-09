namespace Shapes___inlämning_TDD
{
    public class GeoMetricCalculator
    {
        /// <summary>
        /// Calculates and returns a value for the shapes total perimiter.
        /// </summary>
        /// <param name="shapes">Takes a list with shapes</param>
        /// <returns>Returns the total perimeter of the shapes</returns>
        public float GetPerimeter(IGeometricThing[] shapes)
        {
            float result = 0f;
            if (shapes == null)
            {
                return result;
            }

            foreach (var shape in shapes)
            {
                if (shape == null)
                {
                    result += 0;
                    continue;
                }

                result += shape.GetPerimeter();
            }
            return result;
        }
    }
}