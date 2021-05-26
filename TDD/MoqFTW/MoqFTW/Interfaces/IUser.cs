namespace MoqFTW.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IUser" />.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the Id of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name of the user.
        /// </summary>
        public string Name { get; set; }
    }
}