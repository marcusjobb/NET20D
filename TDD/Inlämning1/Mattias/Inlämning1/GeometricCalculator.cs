using System.Collections.Generic;
using System.Linq;

namespace Inlämning1
{
    public class GeometricCalculator : IGeometricThing
    {
        /// <summary>
        /// Calculates the area of the object
        /// </summary>
        /// <returns></returns>
        public float GetArea()
        {
            return -1;
        }
        /// <summary>
        /// Calculates the total Area of an array of objects
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static float GetArea(IGeometricThing[] shape)
        {
            List<float> result = new();
            for (int i = 0; i < shape.Length; i++)
            {
                if (shape[i] != null && shape[i] != default)
                {
                    result.Add(shape[i].GetArea());
                }
            }
            return result.Sum();
        }
        /// <summary>
        /// Calculates the perimeter of the object
        /// </summary>
        /// <returns></returns>
        public float GetPerimeter()
        {
            return -1;
        }
        /// <summary>
        /// Calculates the total perimeter of an array of objects
        /// </summary>
        /// <param name="shape"></param>
        /// <returns></returns>
        public static float GetPerimeter(IGeometricThing[] shape)
        {
            List<float> result = new();
            for (int i = 0; i < shape.Length; i++)
            {
                if (shape[i] != null && shape[i] != default)
                {
                    result.Add(shape[i].GetPerimeter());
                }
            }
            return result.Sum();
        }
    }
}
