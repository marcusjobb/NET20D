using TDD_Nicklas.Interfaces;
using TDD_Nicklas.Utility;

namespace TDD_Nicklas.Calculator
{
    /// <summary>
    /// Calculates the total area and perimeter from given objects.
    /// </summary>
    public class GeometricCalculator : IGeometricCalulatable
    {
        /// <summary>
        /// Calculates objects total area.
        /// </summary>
        /// <param name="forms">Object that is to be calculated.</param>
        /// <returns>Float, total area if success, if not 0 is returned.</returns>
        public float GetTotalArea(IGeoObjectable[] forms)
        {
            var validInput = CheckInput.IsValidNumber(forms);

            if (validInput)
            {
                float totalArea = 0;
                foreach (var form in forms)
                {
                    float area = form.GetArea();
                    if (area != 0)
                    {
                        totalArea += area;
                    }
                    else { return 0; }
                }
                return totalArea;
            }
            else { return 0; }
        }

        /// <summary>
        /// Calculates objects total perimeter if the input is valid.
        /// If input is not valid 0 is returned.
        /// <param name="forms"></param>
        /// <returns>Float, total perimeter if success, if not 0 is returned.</returns>
        public float GetTotalPerimeter(IGeoObjectable[] forms)
        {
            var validInput = CheckInput.IsValidNumber(forms);

            if (validInput)
            {
                float totalPerimeter = 0;
                foreach (var form in forms)
                {
                    float perimeter = form.GetPerimeter();
                    if (perimeter != 0)
                    {
                        totalPerimeter += perimeter;
                    }
                    else { return 0; }
                }
                return totalPerimeter;
            }
            else { return 0; }
        }
    }
}