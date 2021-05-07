using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricTDD.GeometricForms
{
    public class Circle : GeometricThing
    {
        public Circle(float radius)
        {
            Radius = radius;
        }
        public float Radius { get; set; }
        public override float GetArea()
        {
            return MathF.PI * MathF.Pow(Radius, 2);
        }

        public override float GetPerimeter()
        {
            if (Radius < 0) Radius = Radius * -1;
            return MathF.Round(2 * (MathF.PI * Radius), 4);
        }
    }
}
