namespace OMDB
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Defines the <see cref="Movies" />.
    /// </summary>
    public class Movies
    {
        /// <summary>
        /// Gets or sets the imdbID.
        /// </summary>
        public string imdbID { get; set; }

        /// <summary>
        /// Gets or sets the Poster.
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Year.
        /// </summary>
        public string Year { get; set; }
    }
#pragma warning restore IDE1006 // Naming Styles
}