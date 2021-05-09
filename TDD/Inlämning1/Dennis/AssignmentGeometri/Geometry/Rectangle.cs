namespace AssignmentGeometri.Geometry
{
    /// <summary>
    /// Class for Rectangle shape.
    /// </summary>
    public class Rectangle : GeometricThing
    {
        public float Height { get; set; }
        public float Width { get; set; }

        public Rectangle(float height, float width)
        {
            Height = height;
            Width = width;
        }

        public override float GetArea()
        {
            if (Height <= 0 || Width <= 0) { return 0; }
            else { return Height * Width; }
        }

        public override float GetPerimeter()
        {
            if (Height <= 0 || Width <= 0) { return 0; }
            else { return (Height * 2) + (Width * 2); }
        }
    }
}