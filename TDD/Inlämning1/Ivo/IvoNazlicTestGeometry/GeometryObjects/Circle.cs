using IvoNazlicTestGeometry.Interfaces;
using IvoNazlicTestGeometry.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvoNazlicTestGeometry.GeometryObjects
{
    public class Circle : IGeometricThing
    {

        public float Diameter { get; set; }

        public Circle(float diameter)
        {
            Diameter = diameter;
        }

        /// <summary>
        /// Calculates area of the circle
        /// </summary>
        /// <returns>Area as float</returns>
        public float GetArea()
        {
            return MathExtensions.NiceRound(MathF.PI * (Diameter*0.5f) * (Diameter*0.5f));
        }

        /// <summary>
        /// Calculates circumference of the circle
        /// </summary>
        /// <returns>Circumference as float</returns>
        public float GetCircumference()
        {
            return MathExtensions.NiceRound(MathF.PI * Diameter);
        }
    }
}
