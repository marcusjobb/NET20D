namespace Geometri
{
    using System;

    public class Circle : Shape
    {
        /// <summary>
        /// Calculation for shape of Circle with Width & Height.
        /// Circle class heritage from the abstract class Shape -> Area().
        /// </summary>
        public double Radius { get; set; }
        public double Diameter { get; set; }

        public override double Area()
        {
            return Radius * Radius * Math.PI;
        }

        public override double Omkrets()
        {
            Diameter *= 2;
            return Diameter * Math.PI * Radius;
        }
    }
}