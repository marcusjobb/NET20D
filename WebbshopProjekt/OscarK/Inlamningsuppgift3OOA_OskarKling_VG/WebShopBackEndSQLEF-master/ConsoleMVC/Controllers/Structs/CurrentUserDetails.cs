namespace Structs
{
    internal struct CurrentUserDetails
    {
        internal string UserName { get; set; }
        internal string Password { get; set; }
        internal int UserId { get; set; }
        internal bool IsUserAdmin { get; set; }
        internal bool IsUserActive { get; set; }

        internal CurrentUserDetails(string userName, string password, int userId, bool isUserAdmin, bool isUserActive)
        {
            UserName = userName;
            Password = password;
            UserId = userId;
            IsUserAdmin = isUserAdmin;
            IsUserActive = isUserActive;
        }
    }
}