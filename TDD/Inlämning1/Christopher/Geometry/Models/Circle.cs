using Geometry.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Models
{
    public class Circle : IShape
    {
        public float Pi { get; set; }
        public float Height { get; set; }
        public float ShapeBase { get; set; }

        public Circle(float diameter)
        {
            Pi = (float) Math.PI;
            Height = diameter;
        }
    }
}
