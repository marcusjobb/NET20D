namespace Shapes___inlämning_TDD
{
    //Comments for interface implemented methods are in the interface class
    public class Rectangle : IGeometricThing
    {
        /// <summary>
        /// A constructor for Rectangle.
        /// </summary>
        /// <param name="height">Takes a height (float)</param>
        /// <param name="width">Takes the width (float)</param>
        public Rectangle(float height, float width)
        {
            Height = height;
            Width = width;
        }

        /// <summary>
        /// Height of the Rectangle
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Width of the Rectangle
        /// </summary>
        public float Width { get; set; }

        public float CalculateArea()
        {
            if (Height <= 0 || Width <= 0)
            {
                return 0;
            }

            return Height * Width;
        }

        public float GetPerimeter()
        {
            if (Height <= 0 || Width <= 0)
            {
                return 0;
            }

            return (Height * 2) + (Width * 2);
        }
    }
}