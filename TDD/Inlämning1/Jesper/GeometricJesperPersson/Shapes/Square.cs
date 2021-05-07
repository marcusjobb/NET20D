namespace GeometricJesperPersson.Shapes
{
    using System;

    public class Square : GeometricThing
    {
        /// <summary>
        /// Set the square's side to the same as the input when instancing the object.
        /// </summary>
        /// <param name="side">size of the square´s sides in meter</param>
        public Square(float side)
        {
            SidesOfSquare = side;
        }

        public float SidesOfSquare { set; get; }
        /// <summary>
        /// Calculate the area of the square. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The area in float. 0 if fails.</returns>
        public override float GetArea() => IsSquareSizeOkForArea() ? MathF.Pow(SidesOfSquare, 2) : default;

        /// <summary>
        /// Calculate the perimeter of the square. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The perimeter in float. 0 if fails.</returns>
        public override float GetPerimeter() => IsSquareSizeOkForPerimeter() ? SidesOfSquare * 4 : default;

        private bool IsSquareSizeOkForArea() => MathF.Pow(SidesOfSquare, 2) < float.MaxValue && SidesOfSquare >= 0;
        private bool IsSquareSizeOkForPerimeter() => SidesOfSquare * 4 < float.MaxValue && SidesOfSquare >= 0;
    }
}