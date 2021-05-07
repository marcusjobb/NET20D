using System;

namespace Inlämning1.Shapes
{
    public class Circle : GeometricThing
    {
        public float Radius { get; set; }
        public float Diameter { get; set; }
        public Circle(int radius)
        {
            Radius = radius;
        }

        public override float Area()
        {
            
            return MathF.PI * (Radius * 2);
        }

        public override float Perimeter()
        {
            return Radius * 2;
        }
    }
}
