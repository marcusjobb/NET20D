namespace Geometry.GeometricThings
{
    using System;
    using Geometry.Abstracts;

    public class Square : GeometricThing
    {
        /// <summary>
        /// The sides of the square.
        /// </summary>
        public float Side { get; set; }

        public override float Area()
        {
            if (Side < 0) return 0;
            return MathF.Pow(Side, 2);
        }

        public override float Perimiter()
        {
            if (Side < 0) return 0;
            return Side * 4;
        }
    }
}
