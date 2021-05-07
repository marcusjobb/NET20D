using Inlämning1.Utility;

namespace Inlämning1
{
    public class Triangle : IGeometricThing
    {
        public float Height { get; set; }
        public float Tbase { get; set; }
        public float Side { get; set; }

        /// <summary>
        /// Calculates the Area of a Triangle object
        /// </summary>
        /// <returns>float</returns>
        public float GetArea()
        {
            if (Verify.VerifyNull(Height, Tbase) && Verify.IsNumber(Height, Tbase))
            {
                return Tbase * Height / 2;
            }
            return default;
        }
        /// <summary>
        /// Calculates the Perimeter of a Triangle object
        /// </summary>
        /// <returns>float</returns>
        public float GetPerimeter()
        {
            if (Verify.VerifyNull(Tbase, Side) && Verify.IsNumber(Tbase, Side))
            {
                return Tbase + Side + Side;
            }
            return default;
        }
    }
}
