using WebbshopFrontEnd.Controllers;

namespace WebbshopFrontEnd.Models
{
    public static class Start
    {
        public static void RunStart()
        {
            LoginController.SignIn();
        }
    }
}
