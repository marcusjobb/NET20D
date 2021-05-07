namespace TDD_TinaEriksson
{
    /// <summary>
    /// A class for square that inherits from 
    /// IGeomatricThing.
    /// </summary>
    public class Square : IGeomatricThing
    {
        /// <summary>
        /// A field for the side of the square.
        /// </summary>
        public float side;

        /// <summary>
        /// The constructor with a parameter to 
        /// initialize the value of the side.
        /// </summary>
        /// <param name="side">The side of the square</param>
        public Square(float side)
        {
            this.side = side;
        }

        public float GetArea()
        {
            if(side <= 0) { return 0; }
            return side * side;
        }

        public float GetPerimeter()
        {
            if(side <= 0) { return 0; }
            return side * 4;
        }
    }
}