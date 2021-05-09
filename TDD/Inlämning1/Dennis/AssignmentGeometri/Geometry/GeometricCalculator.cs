namespace AssignmentGeometri.Geometry
{
    /// <summary>
    /// Class for the Geometric Calculator.
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Method to calculate Area for the shapes.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public float GetArea(GeometricThing[] thing)
        {
            if (thing == null) { return 0; }
            else
            {
                if (thing.Length == 1)
                {
                    foreach (var shape in thing)
                    {
                        return shape.GetArea();
                    }
                }
                else if (thing.Length > 1)
                {
                    var sum = 0F;
                    foreach (var shape in thing)
                    {
                        sum += shape.GetArea();
                    }
                    return sum;
                }
            }
            return 0;
        }

        /// <summary>
        /// Method to calculate the Perimeter of the shapes.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns></returns>
        public float GetPerimeter(GeometricThing[] thing)
        {
            if (thing == null) { return 0; }
            else
            {
                if (thing.Length == 1)
                {
                    foreach (var shape in thing)
                    {
                        return shape.GetPerimeter();
                    }
                }
                else if (thing.Length > 1)
                {
                    var sum = 0F;
                    foreach (var shape in thing)
                    {
                        sum += shape.GetPerimeter();
                    }
                    return sum;
                }
            }
            return 0;
        }
    }
}