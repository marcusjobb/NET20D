using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricTDD.GeometricForms
{
    public class Triangle : GeometricThing
    {
        public Triangle(float tBase)
        {
            Base = tBase;
        }
        public Triangle(float tBase, float height)
        {
            Base = tBase;
            Height = height;
        }
        public float Base { get; set; }
        public float Height { get; set; }
        public override float GetArea()
        {
            if (Base < 0) Base = Base * -1;
            if (Height < 0) Height = Height * -1;

            return (Base * Height) / 2;
        }

        public override float GetPerimeter()
        {
            if (Base < 0) Base = Base * -1;
            return 3 * Base;
        }
    }
}
