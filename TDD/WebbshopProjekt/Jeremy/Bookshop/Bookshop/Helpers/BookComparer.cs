namespace Bookshop
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Webbutik.Models;

    /// <summary>
    /// Defines the <see cref="BookComparer" />.
    /// </summary>
    internal class BookComparer : IEqualityComparer<Book>
    {
        /// <summary>
        /// The Equals.
        /// </summary>
        /// <param name="x">The x<see cref="Book"/>.</param>
        /// <param name="y">The y<see cref="Book"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Equals(Book x, Book y)
        {
            return x.Id == y.Id;
        }

        /// <summary>
        /// The GetHashCode.
        /// </summary>
        /// <param name="obj">The obj<see cref="Book"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetHashCode([DisallowNull] Book obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
