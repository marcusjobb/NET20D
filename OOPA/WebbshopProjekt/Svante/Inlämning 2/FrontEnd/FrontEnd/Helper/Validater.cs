namespace FrontEnd.Helper
{
    public static class Validator
    {
        public static bool MainMenu { get; set; }
        public static bool UserMenu { get; set; }
        public static bool AdminMenu { get; set; }
        

        public static bool GetMainMenuValuation()
        {
            return MainMenu;
        }
        public static bool GetUserMenuValuation()
        {
            return UserMenu;
        }
        public static bool GetAdminMenuValuation()
        {
            return AdminMenu;
        }

        public static void SetMainMenuValuation(bool value)
        {
            MainMenu = value;
        }
        public static void SetUserMenuValuation(bool value)
        {
            UserMenu = value;
        }
        public static void SetAdminMenuValuation(bool value)
        {
            AdminMenu = value;
        }


    }
}