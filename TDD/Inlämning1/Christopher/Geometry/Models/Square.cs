using Geometry.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry.Models
{
    public class Square : IShape
    {
        public float Height { get; set; }
        public float ShapeBase { get; set; }
        public float Pi { get; set; }

        public Square(float side)
        {
            Height = side;
        }
    }
}
