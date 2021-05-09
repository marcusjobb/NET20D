namespace AssignmentGeometri.Geometry
{
    /// <summary>
    /// Class for Triangle shape.
    /// </summary>
    public class Triangle : GeometricThing
    {
        public float Base { get; set; }
        public float Height { get; set; }

        public Triangle(float height, float bas)
        {
            Base = bas;
            Height = height;
        }

        public override float GetArea()
        {
            if (Base <= 0 || Height <= 0) { return 0; }
            else { return (Base * Height) / 2; }
        }

        public override float GetPerimeter()
        {
            if (Base <= 0 || Height <= 0) { return 0; }
            else { return Base + (Height * 2); }
        }
    }
}