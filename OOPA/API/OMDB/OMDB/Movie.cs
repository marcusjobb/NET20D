namespace OMDB
{
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Defines the <see cref="OMDBHelper" />.
    /// </summary>
    public partial class OMDBHelper
    {
        /// <summary>
        /// Defines the <see cref="Movie" />.
        /// </summary>
        public class Movie
        {
            /// <summary>
            /// Gets or sets the Actors.
            /// </summary>
            public string Actors { get; set; }

            /// <summary>
            /// Gets or sets the Awards.
            /// </summary>
            public string Awards { get; set; }

            /// <summary>
            /// Gets or sets the Country.
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// Gets or sets the Director.
            /// </summary>
            public string Director { get; set; }

            /// <summary>
            /// Gets or sets the Genre.
            /// </summary>
            public string Genre { get; set; }

            /// <summary>
            /// Gets or sets the imdbID.
            /// </summary>
            public string imdbID { get; set; }

            /// <summary>
            /// Gets or sets the imdbRating.
            /// </summary>
            public string imdbRating { get; set; }

            /// <summary>
            /// Gets or sets the imdbVotes.
            /// </summary>
            public string imdbVotes { get; set; }

            /// <summary>
            /// Gets or sets the Language.
            /// </summary>
            public string Language { get; set; }

            /// <summary>
            /// Gets or sets the Metascore.
            /// </summary>
            public string Metascore { get; set; }

            /// <summary>
            /// Gets or sets the Plot.
            /// </summary>
            public string Plot { get; set; }

            /// <summary>
            /// Gets or sets the Poster.
            /// </summary>
            public string Poster { get; set; }

            /// <summary>
            /// Gets or sets the Rated.
            /// </summary>
            public string Rated { get; set; }

            /// <summary>
            /// Gets or sets the Ratings.
            /// </summary>
            public Rating[] Ratings { get; set; }

            /// <summary>
            /// Gets or sets the Released.
            /// </summary>
            public string Released { get; set; }

            /// <summary>
            /// Gets or sets the Response.
            /// </summary>
            public string Response { get; set; }

            /// <summary>
            /// Gets or sets the Runtime.
            /// </summary>
            public string Runtime { get; set; }

            /// <summary>
            /// Gets or sets the Title.
            /// </summary>
            public string Title { get; set; }

            /// <summary>
            /// Gets or sets the totalSeasons.
            /// </summary>
            public string totalSeasons { get; set; }

            /// <summary>
            /// Gets or sets the Type.
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// Gets or sets the Writer.
            /// </summary>
            public string Writer { get; set; }

            /// <summary>
            /// Gets or sets the Year.
            /// </summary>
            public string Year { get; set; }
        }
    }
#pragma warning restore IDE1006 // Naming Styles
}