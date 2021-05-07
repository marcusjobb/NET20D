using System;

namespace Geometri.GeometricObjects
{
    public class Ellipse : GeometricThing
    {
        /// <summary>
        /// An ellipse, with two different radii from the middle.
        /// </summary>
        /// <param name="r1">One radius</param>
        /// <param name="r2">Second radius</param>
        public Ellipse(float r1, float r2) : base(r1, r2)
        {
            if (ValidateInput(r1))
            {
                R1 = r1;
            }
            else
                R1 = 1.0f;
            if (ValidateInput(r2))
            {
                R2 = r2;
            }
            else
                R2 = 1.0f;
        }

        #region Equations
        /// <summary>
        /// Caluclates the circumference. Formula is Ramanujans approximation.
        /// </summary>
        /// <returns></returns>
        public override float Circumference()
        {
            return (float)((float)Math.PI * (3 * (R1 + R2) - Math.Sqrt((3 * R1 + R2) * (R1 + 3 * R2))));
        }
        /// <summary>
        /// Calculates the area
        /// </summary>
        /// <returns>The area</returns>
        public override float Area()
        {
            return (float)((float)R1 * R2 * Math.PI);
        }
        #endregion

        #region Properties
        public float R1 { get; set; }
        public float R2 { get; set; }
        #endregion
    }
}
