using TDD_TinaEriksson;

namespace GeomatryTests
{
    public class GeomatricCalculator
    {
        /// <summary>
        /// Calculates the perimeter of objects sent in,
        /// and returns the value.
        /// </summary>
        /// <param name="geoThings">Array of objects</param>
        /// <returns>The peremiter of the objects combined.</returns>
        public float CalculatePerimeter(IGeomatricThing[] geoThings)
        {
            if (geoThings == null) { return 0; }
            var result = 0f;
            foreach(var thing in geoThings)
            {
                if(thing != null)
                {
                    result += thing.GetPerimeter();
                }
                return 0;
            }
            return result;
        }
    }
}
