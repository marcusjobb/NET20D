namespace WebshopApiFrontend.Utility
{
    internal static class Errorhandeling
    {
        /// <summary>
        /// Something went wrong, double check the id you entered
        /// </summary>
        public static readonly string ErrorWithId = "Something went wrong, double check the id you entered";
        /// <summary>
        /// Invalid selection, not found in database
        /// </summary>
        public static readonly string Invalid = "Invalid selection, not found in database";
        /// <summary>
        /// Something went wrong, double check the book Id or if the book is sold out
        /// </summary>
        public static readonly string BadIdOrSoldout = "Something went wrong, double check the book Id or if the book is sold out";
        /// <summary>
        /// Something went wrong, try adding user again
        /// </summary>
        public static readonly string ErrorWithAddUser = "Something went wrong, try adding user again";
        /// <summary>
        /// Registration successful! You can now login
        /// </summary>
        public static readonly string Registrationfailed = "Registration failed! make sure you entered the same password";
        /// <summary>
        /// Not valid, value set to 0 for now
        /// </summary>
        public static readonly string NotValidDefaultValueSet = "Not valid, value set to 0 for now";
        /// <summary>
        /// Notes that the return was indeed empty and not fault
        /// </summary>
        public static readonly string EmptyReturn = "No matches found";
    }
}
