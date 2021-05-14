namespace Geometri
{
    public class Triangle : Shape
    {
        /// <summary>
        /// Calculation for shape of Triangle with Width & Height.
        /// Triangle class heritage from the abstract class Shape -> Area().
        /// </summary>
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Omkrets()
        {
            return Height + Width + Height;
        }
    }
}