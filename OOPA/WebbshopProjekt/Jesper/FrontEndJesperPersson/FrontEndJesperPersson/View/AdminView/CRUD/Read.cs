namespace FrontEndJesperPersson.View.AdminMenu
{
    using FrontEndJesperPersson.Controller;

    internal class Read
    {
        private AdminController Controller = new AdminController();
        private bool KeepGoing;

        /// <summary>
        /// Startpage and menu of Read.
        /// </summary>
        /// <param name="adminId"></param>
        internal void Menu(int adminId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu("---Läs---", "Lista användare", "Hitta användare", "Tillbaka");
                var choice = ViewHelper.InputInt();
                switch (choice)
                {
                    case 1:
                        ListUsers(adminId);
                        break;

                    case 2:
                        FindUser(adminId);
                        break;

                    case 3:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// Print out users connected to keyword.
        /// </summary>
        /// <param name="adminId"></param>
        private void FindUser(int adminId)
        {
            var keyword = ViewHelper.InputString("Skriv in ditt sökord: ");
            ViewHelper.WriteOutList(Controller.FindUser(adminId, keyword));
            Controller.Ping(adminId);
        }

        /// <summary>
        /// Print out all users.
        /// </summary>
        /// <param name="adminId"></param>
        private void ListUsers(int adminId)
        {
            ViewHelper.WriteOutList(Controller.ListUsers(adminId));
            Controller.Ping(adminId);
        }
    }
}