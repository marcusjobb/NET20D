using IvoNazlicTestGeometry.Interfaces;
using IvoNazlicTestGeometry.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace IvoNazlicTestGeometry.GeometryObjects
{
    public class Square : IGeometricThing
    {
        public float Side { get; set; }

        public Square(float side)
        {
            Side = side;
        }

        /// <summary>
        /// Calculates area of the square
        /// </summary>
        /// <returns>Area as float</returns>
        public float GetArea()
        {
            return MathExtensions.NiceRound(MathF.Pow(Side, 2));
        }

        /// <summary>
        /// Calculates circumference of the square
        /// </summary>
        /// <returns>Circumference as float</returns>
        public float GetCircumference()
        {
            return MathExtensions.NiceRound(4 * Side);  
        }
    }
}
