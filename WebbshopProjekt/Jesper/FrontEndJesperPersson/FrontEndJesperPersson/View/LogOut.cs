namespace FrontEndJesperPersson.View
{
    using FrontEndJesperPersson.Controller;

    internal class LogOut
    {
        private static CustomerController Controller = new CustomerController();

        /// <summary>
        /// Log out the user.
        /// </summary>
        /// <param name="userId"></param>
        internal static void Exit(int userId) => Controller.LogOut(userId);
    }
}