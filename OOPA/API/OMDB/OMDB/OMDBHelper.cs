namespace OMDB
{
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="OMDBHelper" />.
    /// </summary>
    public partial class OMDBHelper
    {
        /// <summary>
        /// The GetByIMDBCode.
        /// </summary>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Movie"/>.</returns>
        public static Movie GetByIMDBCode(string id)
        {
            var url = $"http://www.omdbapi.com/?apikey={Settings.Key}&i={id}";
            return GetMovie(url, id);
        }

        /// <summary>
        /// The GetByTitle.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="year">The year<see cref="string"/>.</param>
        /// <param name="longPlot">The longPlot<see cref="bool"/>.</param>
        /// <returns>The <see cref="Movie"/>.</returns>
        public static Movie GetByTitle(string title, string year = "", bool longPlot = false)
        {
            var url = $"http://www.omdbapi.com/?apikey={Settings.Key}&t={title}&y={year}";
            if (longPlot) url += "&plot=long";
            return GetMovie(url, title + year + longPlot);
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="title">The title<see cref="string"/>.</param>
        /// <param name="year">The year<see cref="string"/>.</param>
        /// <param name="type">The type<see cref="string"/>.</param>
        /// <param name="page">The page<see cref="string"/>.</param>
        /// <returns>The <see cref="SearchResult"/>.</returns>
        public static SearchResult Search(string title, string year = "", string type = "", string page = "1")
        {
            var url = $"http://www.omdbapi.com/?apikey={Settings.Key}&s={title}&y={year}&type={type}&page={page}";
            return SearchMovie(url, title + year + type + page);
        }

        /// <summary>
        /// The GetMovie.
        /// </summary>
        /// <param name="url">The url<see cref="string"/>.</param>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="Movie"/>.</returns>
        private static Movie GetMovie(string url, string id)
        {
            var json = ReadCache(id);
            if (json?.Length == 0)
            {
                using var wc = new System.Net.WebClient();
                json = wc.DownloadString(url);
                WriteCache(id, json);
            }
            var obj = JsonConvert.DeserializeObject<Movie>(json);
            return obj;
        }

        /// <summary>
        /// The ReadCache.
        /// </summary>
        /// <param name="file">The file<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string ReadCache(string file)
        {
            var filename = $"{file}.cache.json";
            return File.Exists(filename) ? File.ReadAllText(filename) : "";
        }

        /// <summary>
        /// The SearchMovie.
        /// </summary>
        /// <param name="url">The url<see cref="string"/>.</param>
        /// <param name="id">The id<see cref="string"/>.</param>
        /// <returns>The <see cref="SearchResult"/>.</returns>
        private static SearchResult SearchMovie(string url, string id)
        {
            var json = ReadCache(id);
            if (json?.Length == 0)
            {
                using var wc = new System.Net.WebClient();
                json = wc.DownloadString(url);
                WriteCache(id, json);
            }
            var obj = JsonConvert.DeserializeObject<SearchResult>(json);
            return obj;
        }

        /// <summary>
        /// The WriteCache.
        /// </summary>
        /// <param name="file">The file<see cref="string"/>.</param>
        /// <param name="json">The json<see cref="string"/>.</param>
        private static void WriteCache(string file, string json)
        {
            var filename = $"{file}.cache.json";
            File.WriteAllText(filename, json);
        }
    }
}