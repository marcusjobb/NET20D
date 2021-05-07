namespace TDD_Nicklas.Interfaces
{
    /// <summary>
    /// Interface used amongst all geometric items.
    /// Interface is also used during unit testing.
    /// </summary>
    public interface IGeoObjectable
    {
        public float GetArea();

        public float GetPerimeter();
    }
}