namespace Geometri
{
    public class Square : Shape
    {
        /// <summary>
        /// Calculation for shape of Square with Width & Height.
        /// Square class heritage from the abstract class Shape -> Area().
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