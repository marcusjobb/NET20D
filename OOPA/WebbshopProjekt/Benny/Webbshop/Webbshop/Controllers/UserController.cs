using Webbshop.Views;
using webshopAPI;

namespace Webbshop.Controllers
{
    internal class UserController
    {
        /// <summary>
        /// Check if user is null
        /// </summary>
        /// <param name="user">takes a user to check</param>
        /// <returns>Returns true if null, false if not.</returns>
        public static bool UserIsNull(User user)
        {
            if (user == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// First menu that the user see when standard user logs in.
        /// </summary>
        /// <param name="user">Takes a user to be connected with eventual purchase.</param>
        internal static void UserSelectionMenu(User user)
        {
            var continueLoop = true;
            do
            {
                UserView.PrintBuyMenuOptions();
                var input = SharedController.GetAndValidateInput();
                switch (input.validatedInput)
                {
                    case 1:
                        SharedController.BuyBookMenu(user);
                        break;

                    case 0:
                        if (SharedController.LogoutIf_X_IsPressed(
                            user,
                            input.menuInput,
                            input.validatedInput))
                        {
                            continueLoop = false;
                        }
                        else
                        {
                            SharedError.PrintWrongMenuInput();
                        }

                        break;
                }
            } while (continueLoop);
        }
    }
}