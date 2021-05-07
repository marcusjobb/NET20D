namespace Inlämning1.Shapes
{
    public class Triangle : GeometricThing
    {
        public float Height { get; set; }
        public float Tbase { get; set; }

        public Triangle(float height, float tbase)
        {
            this.Height = height;
            this.Tbase = tbase;
        }
        /// <summary>
        /// Returnerar Area
        /// </summary>
        /// <returns> (Height * Tbase) / 2 </returns>
        public override float Area()
        {
            return (Height * Tbase) / 2;
        }
        /// <summary>
        /// Returnerar Perimeter/Omkrets
        /// </summary>
        /// <returns> Tbase + (Height * 2) </returns>
        public override float Perimeter()
        {
            return Tbase + (Height * 2);
        }
    }
}