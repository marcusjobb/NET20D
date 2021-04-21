namespace FrontEnd.Controllers
{
    public class Home
    {
        
        internal void Start()
        {
            var view = new Views.HomeView();
            var adminView = new Views.AdminView();
            var userView = new Views.UserView();
            Models.User.UserId = 0;
            
            Helper.Validator.SetMainMenuValuation(true);
            

            
            while (Helper.Validator.GetMainMenuValuation())
            {
                view.Display();
                view.DisplaySwitch();
            }

            while (Helper.Validator.GetAdminMenuValuation())
            {
                adminView.AdminDisplay();
                adminView.DisplaySwitch();
            }
            while (Helper.Validator.GetUserMenuValuation())
            {
                userView.UserDisplay();
                userView.DisplaySwitch();
            }
        }
    }
}