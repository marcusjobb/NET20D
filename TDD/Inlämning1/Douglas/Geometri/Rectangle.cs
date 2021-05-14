namespace Geometri
{
    public class Rectangle : Shape
    {
        /// <summary>
        /// Calculation for a shape of Rectangle with Width & Height.
        /// Rectangle class heritage from the abstract class Shape -> Area().
        /// </summary>
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Omkrets()
        {
            return Width + Height + Width + Height;
        }
    }
}