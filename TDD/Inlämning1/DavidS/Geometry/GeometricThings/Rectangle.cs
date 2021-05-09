namespace Geometry.GeometricThings
{
    using Geometry.Abstracts;

    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// The height of the rectangle.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// The width of the rectangle.
        /// </summary>
        public float Width { get; set; }

        public override float Area()
        {
            if (Height < 0 || Width < 0) return 0;
            return Height * Width;
        }

        public override float Perimiter()
        {
            if (Height < 0 || Width < 0) return 0;
            return (Height + Width) * 2;
        }
    }
}
