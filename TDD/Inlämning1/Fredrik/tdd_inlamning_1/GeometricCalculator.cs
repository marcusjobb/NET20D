using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tdd_inlamning_1
{
    public class GeometricCalculator
    {
        public double GetArea(GeometricThing thing)
        {
            return thing.GetArea();
        }

        public double GetPerimeter(GeometricThing thing)
        {
            return thing.GetPerimeter();
        }

        public double GetPerimeter(GeometricThing[] things)
        {
            return things.Sum(a => a.GetPerimeter());
        }
    }
}
