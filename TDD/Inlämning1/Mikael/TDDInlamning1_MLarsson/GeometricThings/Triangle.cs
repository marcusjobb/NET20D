namespace TDDInlamning1_MLarsson.GeometricThings
{
    /// <summary>
    /// Class to handle the triangle object.
    /// </summary>
    public class Triangle : GeometricThing
    {
        public Triangle(float tbase, float height)
        {
            this.Base = tbase;
            this.Height = height;
        }

        public float Base { get; set; }
        public float Height { get; set; }
        public override float GetArea()
        {
            return Base <= 0 || Height <= 0 ? 0 : Area = Base * Height / 2;
        }

        public override float GetPerimeter()
        {
            return Base < 0 || Height < 0 ? 0 : Perimeter = Base + (Height * 2);
        }
    }
}
