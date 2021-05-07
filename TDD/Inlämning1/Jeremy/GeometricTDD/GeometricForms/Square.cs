using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricTDD.GeometricForms
{
    public class Square : GeometricThing
    {
        public Square(float side)
        {
            Side = side;
        }
        public float Side { get; set; }
        public override float GetArea()
        {
            return Side * Side;
        }

        public override float GetPerimeter()
        {
            if (Side < 0) Side = Side * -1;
            return Side * 4;
        }
    }
}
