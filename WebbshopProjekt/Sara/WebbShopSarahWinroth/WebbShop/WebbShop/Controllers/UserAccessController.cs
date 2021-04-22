using System;
using WebbShop.Views.Home;
using WebbShop.Views.Shared;

namespace WebbShop.Controllers
{
    public class UserAccessController
    {
        public static WebbShopApi.API api = new WebbShopApi.API();
        /// <summary>
        /// Tar emot registreringsdetaljer från användaren, kollar så inga uppgifter är tomma och lägger sedan till användaren.
        /// </summary>
        public void UserRegistration()
        {
            var registrationDetails = UserAccessView.UserRegistration();
            if (string.IsNullOrEmpty(registrationDetails.Name))
            {
                UserAccessView.AccountRegistrationFailed();
                UserVerification();
            }
            else if (string.IsNullOrEmpty(registrationDetails.Password))
            {
                UserAccessView.AccountRegistrationFailed();
                UserVerification();
            }
            else if (string.IsNullOrEmpty(registrationDetails.PasswordVerify))
            {
                UserAccessView.AccountRegistrationFailed();
                UserVerification();
            }
            else
            {
                bool userCreated = api.Register(registrationDetails.Name, registrationDetails.Password, registrationDetails.PasswordVerify);
                if (userCreated == true)
                {
                    UserAccessView.AccountCreated();
                    VerifyUser();
                }
                else
                {
                    UserAccessView.AccountRegistrationFailed();
                    UserVerification();
                }
            }
        }
        /// <summary>
        /// Ger användaren alternativen Registrera eller Logga in. Metoden tar emot användarens val via switch-sats.
        /// </summary>
        public void UserVerification()
        {
            HomeView.Menu();
            try
            {
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        UserRegistration();
                        break;

                    case 2:
                        VerifyUser();
                        break;
                }
            }
            catch
            {
                MessageView.WrongInput();
            }
        }
        /// <summary>
        /// Metoden tar emot användarens inloggningsuppgifter och jämför med användare i databasen. 
        /// Om användaren finns och uppgifter stämmer skickas användaren vidare till Adminmenyn eller Usermenyn beroende på om användaren är admin eller inte.
        /// Finns inte användaren så ges möjlighet till användaren att registrera sig.
        /// </summary>
        public void VerifyUser()
        {
            var loginDetails = UserAccessView.VerifyUser();
            int userId = api.Login(loginDetails.Name, loginDetails.Password);
            if (userId == 0)
            {
                UserAccessView.VerifyUserFailed();
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "r")
                {
                    UserRegistration();
                }
                else
                {
                    VerifyUser();
                }
            }
            if (api.CheckIfUserIsAdmin(userId))
            {
                AdminController admin = new AdminController();
                admin.Menu(userId);
            }
            else
            {
                UserController user = new UserController();
                user.Menu(userId);
            }
        }
    }
}