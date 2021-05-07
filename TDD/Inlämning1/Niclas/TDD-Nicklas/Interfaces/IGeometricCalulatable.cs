namespace TDD_Nicklas.Interfaces
{
    /// <summary>
    /// Interface used in calculating total area and perimeter.
    /// Interface is also used during unit testing.
    /// </summary>
    public interface IGeometricCalulatable
    {
        public float GetTotalArea(IGeoObjectable[] forms);

        public float GetTotalPerimeter(IGeoObjectable[] forms);
    }
}
