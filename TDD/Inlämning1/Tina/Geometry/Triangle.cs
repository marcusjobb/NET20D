namespace TDD_TinaEriksson
{
    /// <summary>
    /// The class for triangle that inherits
    /// from IGeomatricThing.
    /// </summary>
    public class Triangle : IGeomatricThing
    {
        /// <summary>
        /// Field for base of a triangle.
        /// </summary>
        public float triangleBase;
        /// <summary>
        /// Field for height of a triangle.
        /// </summary>
        public float height;

        /// <summary>
        /// The constructor with a parameters to 
        /// initialize the value of the base 
        /// and the height.
        /// </summary>
        /// <param name="triangleBase">The base of the triangle.</param>
        /// <param name="height">The height of a triangle.</param>
        public Triangle(float triangleBase, float height)
        {
            this.triangleBase = triangleBase;
            this.height = height;
        }

        public float GetArea()
        {
            if(triangleBase <= 0 || height <= 0) { return 0; }
            return triangleBase * height / 2;
        }

        public float GetPerimeter()
        {
            if(triangleBase <= 0) { return 0; }
            return triangleBase + (height * 2);
        }
    }
}