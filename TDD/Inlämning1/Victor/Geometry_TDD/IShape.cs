namespace Geometry_TDD
{
#pragma warning disable RCS1118 // Mark local variable as const.

    /// <summary>
    /// Interface for geometric objects
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Calculates area of IShape object
        /// </summary>
        /// <returns>float</returns>
        float Area()
        {
            float area = 0;

            return area;
        }

        /// <summary>
        /// Calculates perimeter of IShape object
        /// </summary>
        /// <returns>float</returns>
        float Perimeter()
        {
            float perimeter = 0;
            return perimeter;
        }
    }

#pragma warning restore RCS1118 // Mark local variable as const.
}