namespace TDD_inl_1.Interfaces
{
    public interface IGeometric
    {
        /// <summary>
        /// Gets the perimeter for the object
        /// </summary>
        /// <returns>The perimeter: <see cref="float"/></returns>
        public abstract float GetPerimeter();

        /// <summary>
        /// Gets the area for the object
        /// </summary>
        /// <returns>The area: <see cref="float"/></returns>
        public abstract float GetArea();
    }
}
