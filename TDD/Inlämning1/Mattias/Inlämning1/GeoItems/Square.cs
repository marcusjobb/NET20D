using Inlämning1.Utility;

namespace Inlämning1
{
    public class Square : IGeometricThing
    {
        public float Side { get; set; }
        /// <summary>
        /// Calculates the area of Square object
        /// </summary>
        /// <returns>float</returns>
        public float GetArea()
        {
            if (Verify.VerifyNull(Side) && Verify.IsNumber(Side))
            {
                return Side * Side;
            }
                return default;
        }
        /// <summary>
        /// Calculates the perimeter of a Square object
        /// </summary>
        /// <returns>float</returns>
        public float GetPerimeter()
        {
            if (Verify.VerifyNull(Side) && Verify.IsNumber(Side))
            {
                return Side * 4;
            }
                return default;
        }
    }
}
