namespace TDDInlamning1_MLarsson.GeometricThings
{
    /// <summary>
    /// Class to handle the rectangle object.
    /// </summary>
    public class Rectangle : GeometricThing
    {
        public Rectangle(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        public float Height { get; set; }
        public float Width { get; set; }

        public override float GetArea()
        {
            return Width <= 0 || Height <= 0 ? 0 : Area = Width * Height;
        }

        public override float GetPerimeter()
        {
            return Width < 0 || Height < 0 ? 0 : Perimeter = (Width * 2) + (Height * 2);
        }
    }
}
