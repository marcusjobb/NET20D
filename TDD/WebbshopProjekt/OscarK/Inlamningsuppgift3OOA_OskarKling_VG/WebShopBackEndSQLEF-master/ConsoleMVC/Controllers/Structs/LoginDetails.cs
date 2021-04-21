namespace Structs
{
    internal struct LoginDetails
    {
        internal string UserName { get; set; }
        internal string Password { get; set; }
        internal string VerifiedPassword { get; set; }

        internal LoginDetails(string userName, string password, string verifiedPassword)
        {
            UserName = userName;
            Password = password;
            VerifiedPassword = verifiedPassword;
        }
    }
}