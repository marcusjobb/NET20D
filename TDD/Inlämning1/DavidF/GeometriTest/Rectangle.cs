namespace GeometriTest
{
    /// <summary>
    /// Klass som ärver av GeometricThing, representerar en kvadrat/rektrangel (båda går att implementera).
    /// </summary>
    public class Rectangle : GeometricThing
    {
        public float Base { get; set; }

        public float Height { get; set; }

        public override float Area()
        {
            return Base * Height;
        }

        public override float Perimeter()
        {
            return (Base * 2) + (Height * 2);
        }
    }
}