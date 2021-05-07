using Inlämning1.Shapes;

namespace Inlämning1.Calculator
{
    public static class GeometricCalculator
    {
        /// <summary>
        /// Tar emot en Array av shapes och adderar arean
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns>area</returns>
        public static float GetArea(GeometricThing[] shapes)
        {
            float area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }

            return area;
        }
        /// <summary>
        /// Tar emot en shape och returnerar arean
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public static float GetArea(GeometricThing shapes)
        {
            float area = shapes.Area();

            return area;
        }
        /// <summary>
        /// Tar emot en shape och returnerar omkretsen
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public static float GetPerimeter(GeometricThing shapes)
        {
            float perimeter = shapes.Perimeter();
            return perimeter;
        }
        /// <summary>
        /// Tar emot en Array av shapes och adderar omkretsen
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns>area</returns>

        public static float GetPerimeter(GeometricThing[] shapes)
        {
            float perimeter = 0;
            foreach (var shape in shapes)
            {
                perimeter += shape.Perimeter();
            }
            return perimeter;
        }
    }
}