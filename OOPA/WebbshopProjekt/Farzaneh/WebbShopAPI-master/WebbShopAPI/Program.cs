using WebbShopAPI.APIHelper;

namespace WebbShopAPI
{
    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
        {
            API myAPI = new API();
             myAPI.Run();
        }
    }
}
