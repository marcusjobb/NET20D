using ConsoleApp3.Interfaces;

namespace ConsoleApp3.Shapes
{
    public class Triangle : IGeometricThing
    {
        public float Height { get; set; }
        public float Width { get; set; }

        public Triangle(float height, float width)
        {
            Height = height;
            Width = width;
        }

        public float Area()
        {
            if (Height <= 0 || Width <= 0)
            {
                return 0f;
            }

            return Height * Width / 2;
        }

        public float Perimeter()
        {
            if (Height <= 0 || Width <= 0)
            {
                return 0f;
            }

            return Width * 3;
        }
    }
}