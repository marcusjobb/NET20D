namespace Geometric
{
    using Geometric.Figures;

    public class GeometricCalculator
    {
        /// <summary>
        /// Calculates the total sum of all the objects perimeters.
        /// </summary>
        /// <param name="shapes"> Array containing different geometric figures, of the type Shape.</param>
        /// <returns>The total sum of all the objects perimeters.</returns>
        public float GetPerimeter(Shape[] shapes)
        {
            if (shapes == null)
            {
                return 0;
            }

            var sum = 0.0F;
            foreach (var shape in shapes)
            {
                sum += shape.GetPerimeter();
            }
            return sum;
        }
    }
}