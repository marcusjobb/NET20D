using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry.Library
{
    public interface IGeometricThing 
    {
        double Area { get; set; }
        double Perimeter { get; set; }
        double GetArea();
        double GetPerimeter();
    }
}
