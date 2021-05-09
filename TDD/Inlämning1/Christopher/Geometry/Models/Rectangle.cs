using Geometry.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Geometry.Controllers;

namespace Geometry.Models
{
    public class Rectangle : IShape
    {
        public float Height { get; set; }
        public float ShapeBase { get; set; }
        public float Pi { get; set; }

        public Rectangle(float height, float shapeBase)
        {
            Height = height;
            ShapeBase = shapeBase;
        }
    }
}
