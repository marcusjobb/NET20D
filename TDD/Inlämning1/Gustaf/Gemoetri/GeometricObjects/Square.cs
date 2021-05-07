namespace Geometri.GeometricObjects
{
    public class Square : Rectangle
    {
        /// <summary>
        /// Constructor taking 1 argument, the length of a side
        /// </summary>
        /// <param name="length">The length of a side</param>
        public Square(float length) : base(length, length)
        {
        }
    }
}
