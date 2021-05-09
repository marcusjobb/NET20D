using System;

namespace GeometriTest
{
    /// <summary>
    /// Klass som ärver av GeometricThing, representerar en cirkel.
    /// </summary>
    public class Circle : GeometricThing
    {
        public float Radius { get; set; }

        public override float Area()
        {
            return (float)(Radius * Math.PI);
        }

        public override float Perimeter()
        {
            return (float)(Radius * Math.PI * 2);
        }
    }
}