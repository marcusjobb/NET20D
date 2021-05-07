using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Inlamning_Lee.Interfaces
{
    /// <summary>
    /// This interface allowes you to use the GeometricCalculator methodes and
    /// since there are only 3 of them - you will need this.
    /// </summary>
    public interface IGeometricThings
    {
        /// <summary>
        /// Returns the circumference of an object as long as the input numbers are positive otherwise -1
        /// </summary>
        /// <returns></returns>
        public float GetPerimiter();

        /// <summary>
        /// Returns the area of an object as long as the input numbers are positive otherwise -1
        /// </summary>
        /// <returns></returns>
        public float GetArea();
    }
}
