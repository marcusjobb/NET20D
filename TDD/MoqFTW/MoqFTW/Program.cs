namespace MoqFTW
{
    using MoqFTW.Interfaces;
    using MoqFTW.Webblogics;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main method.
        /// </summary>
        internal static void Main()
        {
            Webbshop shop = new()
            {
                ItemsAvailable = new System.Collections.Generic.List<IItem>()
            };
        }
    }
}