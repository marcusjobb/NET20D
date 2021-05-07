namespace GeometryProject
{
    using GeometryProject.GeoModels;
    using System;

    public class GeometricCalculator
    {
        /// <summary>
        /// Method to calculate the combined perimeter of all shapes in the array.
        /// </summary>
        /// <param name="thing">Array of shapes</param>
        /// <returns>Total length of combined perimeters.</returns>
        public float GetPerimeters(GeometricThing[] thing)
        {
            if (thing == null) return default;
            else
            {
                var totPerimeter = 0f;
                foreach (var figure in thing)
                {
                    var figurePerimeter = MathF.Round(figure.GetPerimeter(), 2);
                    if (figurePerimeter == 0) return default; // Check that none of the shapes returns as zero, which would mean that something was wrong inside of methods belonging to the shapes.
                    else totPerimeter += figurePerimeter;
                }
                return totPerimeter > 0 && thing != null && totPerimeter <= float.MaxValue ? totPerimeter : default;
            }
        }
    }
}