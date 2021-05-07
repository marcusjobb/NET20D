using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricTDD.GeometricForms
{
    public class Rectangle : GeometricThing
    {
        public Rectangle(float height, float width)
        {
            Height = height;
            Width = width;
        }
        public float Height { get; set; }
        public float Width { get; set; }
        public override float GetArea()
        {
            if (Height < 0) Height = Height * -1;
            if (Width < 0) Width = Width * -1;

            return Height * Width;
        }

        public override float GetPerimeter()
        {
            if (Height < 0) Height = Height * -1;
            if (Width < 0) Width = Width * -1;
            return 2 * (Height + Width);
        }
    }
}
