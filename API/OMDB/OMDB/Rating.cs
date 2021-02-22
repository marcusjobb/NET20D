namespace OMDB
{
    /// <summary>
    /// Defines the <see cref="OMDBHelper" />.
    /// </summary>
    public partial class OMDBHelper
    {
        /// <summary>
        /// Defines the <see cref="Rating" />.
        /// </summary>
        public class Rating
        {
            /// <summary>
            /// Gets or sets the Source.
            /// </summary>
            public string Source { get; set; }

            /// <summary>
            /// Gets or sets the Value.
            /// </summary>
            public string Value { get; set; }
        }
    }
}