namespace GeometricJesperPersson.Shapes
{
    public class Rectangle : GeometricThing
    {
        /// <summary>
        /// Set the rectangle's sides to the same as the input when instancing the object.
        /// </summary>
        /// <param name="sideA">height in meter.</param>
        /// <param name="sideB">base in meter.</param>
        public Rectangle(float sideA, float sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public float SideA { set; get; }
        public float SideB { set; get; }
        /// <summary>
        /// Calculate the area of the rectangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The area in a float. 0 if fails.</returns>
        public override float GetArea() => IsSizeOkForArea() ? SideA * SideB : default;

        /// <summary>
        /// Calculate the perimeter of the rectangle. Takes only numbers same or bigger then 0.
        /// </summary>
        /// <returns>The perimeter in float. 0 if fails.</returns>
        public override float GetPerimeter() => IsSizeOkForPermimeter() ? (SideA * 2) + (SideB * 2) : default;

        private bool IsSizeOkForArea() => SideA * SideB < float.MaxValue && SideA >= 0 && SideB >= 0;
        private bool IsSizeOkForPermimeter() => SideB >= 0 && SideA >= 0 && (SideA * 2) + (SideB * 2) < float.MaxValue;
    }
}