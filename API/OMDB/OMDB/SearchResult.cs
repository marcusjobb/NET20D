namespace OMDB
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Defines the <see cref="SearchResult" />.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Gets or sets the Response.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets the Search.
        /// </summary>
        public Movies[] Search { get; set; }

        /// <summary>
        /// Gets or sets the totalResults.
        /// </summary>
        public string totalResults { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}