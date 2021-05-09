namespace TDD_inl_1.Geometry
{
    using TDD_inl_1.Interfaces;
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculates the perimeter for many geometric things
        /// </summary>
        /// <param name="things"></param>
        /// <returns>Perimeter: <see cref="float"/></returns>
        public float GetPerimeter(IGeometric[] things)
        {
            float perimeter = 0;
            foreach (var ob in things)
            {
                perimeter += ob.GetPerimeter();
            }
            return perimeter;
        }
    }
}
