namespace GeometriTest
{
    /// <summary>
    /// Abstrakt klass med två metoder; area och omkrets. Kunde likväl använt ett interface.
    /// </summary>

    public abstract class GeometricThing
    {
        /// <summary>
        /// Den geometriska figurens area
        /// </summary>
        public abstract float Area();

        /// <summary>
        /// Den geometriska figurens omkrets
        /// </summary>
        public abstract float Perimeter();
    }
}