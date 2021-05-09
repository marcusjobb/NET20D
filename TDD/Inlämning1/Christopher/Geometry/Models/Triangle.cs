using Geometry.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
namespace Geometry.Models
{
    public class Triangle : IShape
    {
        public float Height { get; set; }
        public float ShapeBase { get; set; }
        public float Pi { get; set; }

        public Triangle(float height, float shapeBase)
        {
            Height = height;
            ShapeBase = shapeBase;
        }

    }
}
