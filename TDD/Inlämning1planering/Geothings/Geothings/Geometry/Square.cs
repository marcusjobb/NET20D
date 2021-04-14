using Geothings.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geothings.Geometry
{
    public class Square : GemetricThing
    {
        public Square()
        {

        }
        public Square(float side)
        {
            Side = side;
        }

        public float Side { get; set; }
        public override float GetArea()
        {
            return 0;
            //return (float)Math.Pow(side, 2);
        }

        public override float GetPerimeter()
        {
            return 0;
            //return 4 * side;
        }
    }
}
