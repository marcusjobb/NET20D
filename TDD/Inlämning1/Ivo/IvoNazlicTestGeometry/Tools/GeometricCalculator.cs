using IvoNazlicTestGeometry.Interfaces;

namespace IvoNazlicTestGeometry.Tools
{
    public class GeometricCalculator
    {
        /// <summary>
        /// Calculates circumference of all the objects in array
        /// </summary>
        /// <param name="things">objects in array</param>
        /// <returns>Circumference as float</returns>
        public float GetCircumference(IGeometricThing[] things)
        {
            float circumference = 0;
            {
                foreach (var item in things)
                {
                    if (item != null)
                    {
                        circumference = circumference + item.GetCircumference();
                    }
                }
            }

            return circumference;
        }
    }
}
