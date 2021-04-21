namespace FrontEndJesperPersson.View
{
    using FrontEndJesperPersson.Controller;
    using FrontEndJesperPersson.View.AdminMenu;
    using FrontEndJesperPersson.View.AdminView;

    internal class Index
    {
        private static int Choice;
        private static CustomerController Controller = new CustomerController();
        private static int Id;
        private static bool KeepGoing = true;

        /// <summary>
        /// Prints out main menu for Admin.
        /// </summary>
        /// <param name="adminId"></param>
        public static void AdminMenu(int adminId)
        {
            Id = adminId;
            while (KeepGoing)
            {
                ViewHelper.BlankStep();
                ViewHelper.CreateMenu("*****Huvudmeny******", "Kategorier", "Böcker", "CRUD", "Verksamheten", "Logga ut");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        var category = new Categories();
                        category.Menu(Id);
                        break;

                    case 2:
                        var books = new Books();
                        books.Menu(Id);
                        break;

                    case 3:
                        var adminIndex = new AdminIndex();
                        adminIndex.Menu(Id);
                        break;

                    case 4:
                        var business = new Business();
                        business.Menu(Id);
                        break;

                    case 5:
                        LogOut.Exit(Id);
                        KeepGoing = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Prints out main menu for user/custmomer.
        /// </summary>
        /// <param name="userId"></param>
        public static void UserMenu(int userId)
        {
            Id = userId;
            while (KeepGoing)
            {
                ViewHelper.BlankStep();
                ViewHelper.CreateMenu("*****Huvudmeny******", "Kategorier", "Böcker", "Logga ut");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        var category = new Categories();
                        category.Menu(Id);
                        break;

                    case 2:
                        var books = new Books();
                        books.Menu(Id);
                        break;

                    case 3:
                        LogOut.Exit(Id);
                        KeepGoing = false;
                        break;
                }
            }
        }
    }
}