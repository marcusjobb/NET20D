namespace TDD_inl_1.Geometry
{
    using Geothings.Extensions;
    using TDD_inl_1.Interfaces;

    public class Square : IGeometric
    {
        // set the side
        public float Side { get; set; }

        public Square(float a)
        {
            Side = a;
        }

        /// <summary>
        /// Find the area
        /// </summary>
        /// <returns>Area: <see cref="float"/></returns>
        public float GetArea()
        {
            
            return (Side * Side).Round();
        }

        /// <summary>
        /// Find the perimeter
        /// </summary>
        /// <returns>Perimeter: <see cref="float"/></returns>
        public float GetPerimeter()
        {
            return (Side * 4).Round();
        }
    }
}
