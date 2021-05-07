using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    /// <summary>
    /// Abstract class with Area() and Perimeter() That the other geometric shapes
    /// Derivatives from this class
    /// </summary>
    public abstract class GeometricThing
    {
        public abstract double Area();
        public abstract double Perimeter();
    }
}
