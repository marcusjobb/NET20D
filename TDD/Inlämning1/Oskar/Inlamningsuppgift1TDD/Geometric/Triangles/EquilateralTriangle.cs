namespace Inlamningsuppgift1TDD.Geometric.Triangles
{
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(float sideLength)
        {
            Base = sideLength;
        }

        public EquilateralTriangle(float _base, float _height)
        {
            Base = _base;
            Height = _height;
        }

        /// <summary>
        /// Calculates the Perimeter of the Equilateral Triangle
        /// </summary>
        /// <returns>Perimeter as type float</returns>
        public override float GetPerimeter()
        {
            return 3 * Base;
        }
    }
}
