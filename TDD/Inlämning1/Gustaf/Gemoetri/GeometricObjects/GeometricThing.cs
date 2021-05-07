using Geometri.GeometricObjects;
using System;

namespace Geometri
{
    public abstract class GeometricThing : IGeometricThing
    {
        /// <summary>
        /// Constructor that takes two arguments
        /// </summary>
        /// <param name="length">The length of one side, one radii</param>
        /// <param name="height">The height of one side, other radii</param>
        public GeometricThing(float length, float height)
        {
            if (ValidateInput(length))
            {
                Length = length;
            }
            else
            {
                Length = 1.0f;
            }
            if (ValidateInput(height))
            {
                Height = height;
            }
            else
            {
                Height = 1.0f;
            }
        }

        public bool ValidateInput(float a)
        {
            if (a.CompareTo(0.0f) == -1 || a.CompareTo(0.0f) == 0 || float.IsNaN(a) ||
                (MathF.Sqrt(float.MaxValue) / Math.PI).CompareTo(a) == -1 || (MathF.Sqrt(float.MaxValue) / Math.PI).CompareTo(a) == 0)
                return false;
            else
                return true;
        }

        #region Equaions
        public virtual float Circumference()
        {
            return Length * 2 + Height * 2;
        }
        public virtual float Area()
        {
            return Length * Height;
        }
        #endregion

        #region Properties
        public float Length { get; set; }
        public float Height { get; set; }
        #endregion
    }
}
