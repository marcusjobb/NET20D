namespace TDD_TinaEriksson
{
    /// <summary>
    /// A class for rectangle that inherits from
    /// IgeomatricThing. 
    /// </summary>
    public class Rectangle : IGeomatricThing
    {
        /// <summary>
        /// Fields for width and height.
        /// </summary>
        public float width;
        public float height;

        /// <summary>
        /// The constructor with a parameter to 
        /// initialize the value of the width and height.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle</param>
        public Rectangle(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        public float GetArea()
        {
            if(width <= 0 || height <= 0) { return 0; }
            return width * height;
        }

        public float GetPerimeter()
        {
            if(width <= 0 || height <= 0) { return 0; }
            return width * 2 + height * 2;
        }
    }
}