using Geometry.Abstracts;

namespace Geometry.GeometricThings
{
    public class Triangle : GeometricThing
    {
        /// <summary>
        /// The Base of the triangle.
        /// </summary>
        public float Base { get; set; }

        /// <summary>
        /// The Height of the triangle.
        /// </summary>
        public float Height { get; set; }

        public override float Area()
        {
            if (Base < 0 || Height < 0) return 0;
            return Base * Height / 2;
        }

        public override float Perimiter()
        {
            if (Base < 0) return 0;
            return Base * 3;
        }
    }
}
