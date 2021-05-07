using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Inlamning_Lee.GeoItems
{
    /// <summary>
    /// Abstract class that containes properties that the geometric objects inherits.
    /// </summary>
    public abstract class GeometricThings
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Side { get; set; }
        public bool Equilateral { get; set; }
        public float Radius { get; set; }
    }
}
