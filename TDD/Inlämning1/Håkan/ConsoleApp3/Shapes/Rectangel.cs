using ConsoleApp3.Interfaces;

namespace ConsoleApp3.Shapes
{
    public class Rectangel : IGeometricThing
    {
        public float Width { get; set; }
        public float Length { get; set; }

        public Rectangel(float width, float length)
        {
            Width = width;
            Length = length;
        }

        public float Area()
        {
            if (Width <= 0 || Length <= 0)
            {
                return 0f;
            }

            return Width * Length;
        }

        public float Perimeter()
        {
            if (Width <= 0 || Length <= 0)
            {
                return 0f;
            }

            return Width * 2 + Length * 2;
        }
    }
}