namespace Inlamningsuppgift1TDD.Geometric.Triangles
{
    /// <summary>
    /// Abstract class of triangle. Contains properties of all basic mathematical elements a triangle can have.
    /// </summary>
    public abstract class Triangle : IGeometric
    {
        public float Base { get; set; }
        public float Height { get; set; }

        #region Advanced Triangle Properties
        public float SideAB { get; set; }
        public float SideBC { get; set; }
        public float SideAC { get; set; }
        public float AngleA { get; set; }
        public float AngleB { get; set; }
        public float AngleC { get; set; }
        #endregion

        /// <summary>
        /// Calculates the Area of any Triangle
        /// </summary>
        /// <returns>Area as type float</returns>
        public virtual float GetArea()
        {
            return 0.5f * Base * Height;
        }

        /// <summary>
        /// Abstrac method each triangle class implements.
        /// Becouse a perimeter of a triangle differs depending on the angle of the corners.
        /// </summary>
        /// <returns>Perimeter of type float</returns>
        public abstract float GetPerimeter();
    }
}
