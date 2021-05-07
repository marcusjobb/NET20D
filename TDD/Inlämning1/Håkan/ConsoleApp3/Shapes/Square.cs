using ConsoleApp3.Interfaces;

namespace ConsoleApp3.Shapes
{
    public class Square : IGeometricThing
    {
        public float Side { get; set; }

        /// <summary>
        /// Konstruktorn
        /// </summary>
        public Square(float side)
        {
            Side = side;
        }

        public float Area()
        {
            if (Side <= 0)
            {
                return 0f;
            }

            return Side * Side;
        }

        public float Perimeter()
        {
            if (Side <= 0)
            {
                return 0f;
            }

            return Side * 4;
        }
    }
}