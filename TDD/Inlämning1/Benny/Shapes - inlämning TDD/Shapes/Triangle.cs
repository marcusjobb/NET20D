namespace Shapes___inlämning_TDD
{
    //Comments for interface implemented methods are in the interface class
    internal class Triangle : IGeometricThing
    {
        /// <summary>
        /// Constructor for the triangle
        /// </summary>
        /// <param name="baseMeasure">Takes the base measurement</param>
        /// <param name="heightMeasure">Takes the height measurement</param>
        public Triangle(float baseMeasure, float heightMeasure)
        {
            Base = baseMeasure;
            Height = heightMeasure;
        }

        /// <summary>
        /// Property for base measurement
        /// </summary>
        public float Base { get; set; }

        /// <summary>
        /// Property for height measurement
        /// </summary>
        public float Height { get; set; }
        public float CalculateArea()
        {
            if (Base <= 0 || Height <= 0)
            {
                return 0;
            }

            return 0.5f * Base * Height;
        }

        public float GetPerimeter()
        {
            if (Base <= 0 || Height <= 0)
            {
                return 0;
            }

            return Base * 3;
        }
    }
}