namespace MoqFTW.Webblogics
{
    using MoqFTW.Interfaces;

    /// <summary>
    /// Defines the <see cref="User" />.
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }
    }
}