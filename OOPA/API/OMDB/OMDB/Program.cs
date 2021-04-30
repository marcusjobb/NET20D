namespace OMDB
{
    using System;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        internal static void Main()
        {
            PrintMovie(OMDBHelper.GetByIMDBCode("tt1205489"));
            PrintMovie(OMDBHelper.GetByTitle("Dracula"));
            var movies = 0;
            var page = 0;
            var showHits = true;
            do
            {
                page++;
                var search = OMDBHelper.Search("Catwoman", "", "", page.ToString());
                movies = int.Parse(search.totalResults);
                PrintMovies(search, showHits);
                showHits = false;
            }
            while (movies > page * 10);
        }

        /// <summary>
        /// The PrintMovie.
        /// </summary>
        /// <param name="movie">The movie<see cref="OMDBHelper.Movie"/>.</param>
        private static void PrintMovie(OMDBHelper.Movie movie)
        {
            Console.WriteLine($"{movie.Title},{movie.Year}");
            Console.WriteLine(movie.Actors);
        }

        /// <summary>
        /// The PrintMovies.
        /// </summary>
        /// <param name="result">The result<see cref="SearchResult"/>.</param>
        /// <param name="showHits">The showHits<see cref="bool"/>.</param>
        private static void PrintMovies(SearchResult result, bool showHits = false)
        {
            if (showHits) Console.WriteLine($"{result.totalResults} movies found");
            foreach (var item in result.Search)
            {
                Console.WriteLine($"  {item.Title} {item.Year}");
            }
        }
    }
}