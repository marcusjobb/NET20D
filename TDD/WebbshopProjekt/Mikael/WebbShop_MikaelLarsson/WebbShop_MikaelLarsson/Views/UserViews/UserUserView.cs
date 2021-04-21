namespace WebbShop_MikaelLarsson.Views.UserView
{
    using System;
    /// <summary>
    /// Klass för att skriva ut user-relaterad text.
    /// </summary>
    internal static class UserUserView
    {
        /// <summary>
        /// Input för att logga in.
        /// </summary>
        /// <returns>string Tuples</returns>
        public static (string, string) LoginView()
        {
            Console.Write("Please enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter password: ");
            ControlHelper.SetPasswordColor();
            string password = Console.ReadLine();
            Console.ResetColor();
            return (username, password);
        }

        /// <summary>
        /// Input för att registrera ny användare
        /// </summary>
        /// <returns>string array</returns>
        internal static string[] Register()
        {
            Console.WriteLine("REGISTER NEW USER");
            Console.WriteLine("Please enter a username");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter a password");
            ControlHelper.SetPasswordColor();
            string password = Console.ReadLine();
            Console.ResetColor();
            Console.WriteLine("Please enter same password again to verify");
            ControlHelper.SetPasswordColor();
            string passwordVerify = Console.ReadLine();
            Console.ResetColor();
            return new string[] { username, password, passwordVerify };
        }
    }
}
