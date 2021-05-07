namespace TDDInlamning1_MLarsson.Tests
{
    /// <summary>
    /// Class to handle the square object.
    /// </summary>
    public class Square : GeometricThing
    {
        public Square(float side)
        {
            this.Side = side;
        }

        private float Side { get; }
        public override float GetArea()
        {
           return Side <= 0 ? 0 : Area = Side * Side;
        }

        public override float GetPerimeter()
        {
            return Side < 0 ? 0 : Perimeter = Side * 4;
        }
    }
}