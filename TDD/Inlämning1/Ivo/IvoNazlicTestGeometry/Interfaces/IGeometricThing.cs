using System;
using System.Collections.Generic;
using System.Text;

namespace IvoNazlicTestGeometry.Interfaces
{
    public interface IGeometricThing
    {

        /// <summary>
        /// Calculates objects circumference
        /// </summary>
        /// <returns>Circumference</returns>
        public abstract float GetCircumference();

        /// <summary>
        /// Calculates objects area
        /// </summary>
        /// <returns>Area</returns>
        public abstract float GetArea();

    }
}
