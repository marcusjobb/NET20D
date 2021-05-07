using Geometri.GeoItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geometri
{
    public interface IGeometricThing
    {
        public float GetPerimeterData { get;}
        public float GetAreaData { get; }

    }
}
