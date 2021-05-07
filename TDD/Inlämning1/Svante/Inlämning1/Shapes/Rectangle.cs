using System;

namespace Inlämning1.Shapes
{
    public class Rectangle : GeometricThing
    {
       
        public float Height { get; set; }
        public float Width { get; set; }

        public Rectangle(float height, float widht)
        {
            Height = height;
            Width = widht;
        }

        public override float Area()
        {
            return MathF.Round(Width * Height, 4);
            
        }
       public override float Perimeter()
        {
            return Height + Height + Width + Width;
        }
    }
}