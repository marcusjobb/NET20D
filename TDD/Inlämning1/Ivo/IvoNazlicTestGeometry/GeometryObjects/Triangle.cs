using IvoNazlicTestGeometry.Interfaces;
using IvoNazlicTestGeometry.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvoNazlicTestGeometry.GeometryObjects
{
    public class Triangle : IGeometricThing
    {

        public float Side { get; set; }

        public Triangle(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Calculates area of the triangle
        /// </summary>
        /// <returns>Area as float</returns>
        public float GetArea()
        {
            return MathExtensions.NiceRound(MathF.Pow(Side, 2) * 0.433f);
        }

        /// <summary>
        /// Calculates circumference of the triangle
        /// </summary>
        /// <returns>Circumference as float</returns>
        public float GetCircumference()
        {
            return MathExtensions.NiceRound(3 * Side);
        }
    }
}
