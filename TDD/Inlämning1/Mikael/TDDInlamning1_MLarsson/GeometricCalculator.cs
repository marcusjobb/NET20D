namespace TDDInlamning1_MLarsson
{
    using TDDInlamning1_MLarsson.GeometricThings;
    using TDDInlamning1_MLarsson.Tests;

    /// <summary>
    /// Class with methods to calculate area and perimeter of different shapes.
    /// </summary>
    public class GeometricCalculator
    {
        /// <summary>
        /// Help method to decide which
        /// shape type a GeometricThing is.
        /// Sends object to the object's GetArea().
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>0 if thing is null or not suitable, or area value. </returns>
        public float GetArea(GeometricThing thing)
        {
            if (thing != null)
            {
                var shape = SetObject(thing);
                return shape.GetArea();
            }
            return 0;
        }

        /// <summary>
        /// Help method to loop through an array of shapes, and send it to GetArea().
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>0 if array is null, or the area sum of all objects.</returns>
        public float GetArea(GeometricThing[] thing)
        {
            if (thing != null)
            {
                float totalAreaOfShapes = 0;
                foreach (var shape in thing)
                {
                    totalAreaOfShapes += GetArea(shape);
                }
                return totalAreaOfShapes;
            }
            return 0;
        }

        /// <summary>
        /// Help method to decide which
        /// shape type a GeometricThing is.
        /// Sends object to the object's GetPerimeter().
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>0 if thing is null or not suitable, or perimeter value.</returns>
        public float GetPerimeter(GeometricThing thing)
        {
            if (thing!=null)
            {
                var shape = SetObject(thing);
               return shape.GetPerimeter();
            }
            return 0;
        }

        /// <summary>
        /// Help method to loop through an array of shapes, and send it to GetPerimeter().
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>0 if array is null, or the perimeter sum of all objects.</returns>
        public float GetPerimeter(GeometricThing[] thing)
        {
            if (thing != null)
            {
                float totalPerimeterOfShapes = 0;
                foreach (var shape in thing)
                {
                    totalPerimeterOfShapes += GetPerimeter(shape);
                }
                return totalPerimeterOfShapes;
            }
            return 0;
        }

        /// <summary>
        /// Sets a GeometricThing to a definite shape object.
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>a definite object of the abstract class GeometricThing</returns>
        private GeometricThing SetObject(GeometricThing thing)
        {
            if (thing is Rectangle rectangle) return rectangle;
            if (thing is Square square) return square;
            if (thing is Triangle triangle) return triangle;
            if (thing is Circle circle) return circle;
            return null;
        }
    }
}
