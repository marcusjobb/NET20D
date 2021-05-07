using Inlämning1.Utility;

namespace Inlämning1
{
    public class Rectangle : IGeometricThing
    {
        public float Height { get; set; }
        public float Width { get; set; }
        /// <summary>
        /// Calculates the Area of a Rectangle object
        /// </summary>
        /// <returns>float</returns>
        public float GetArea()
        {
            if (Verify.VerifyNull(Height, Width) && Verify.IsNumber(Height, Width))
            {
                return Height * Width;
            }
                return default;
        }
        /// <summary>
        /// Calculates the Perimeter of a Rectangle object
        /// </summary>
        /// <returns>float</returns>
        public float GetPerimeter()
        {
            if (Verify.VerifyNull(Height, Width) && Verify.IsNumber(Height, Width))
            {
                return (Height * 2) + (Width * 2);
            }
                return default;
        }
    }
}
