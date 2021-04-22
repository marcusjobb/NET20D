namespace FrontEndJesperPersson.View.AdminMenu
{
    internal class AdminIndex
    {
        private bool KeepGoing = true;

        /// <summary>
        /// Prints out CRUD menu.
        /// </summary>
        /// <param name="adminId"></param>
        public void Menu(int adminId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu("---Admin---", "Skapa", "Läs", "Uppdatera", "Radera", "Tillbaka");
                var choice = ViewHelper.InputInt();
                switch (choice)
                {
                    case 1:
                        var create = new Create();
                        create.Menu(adminId);
                        break;

                    case 2:
                        var read = new Read();
                        read.Menu(adminId);
                        break;

                    case 3:
                        var update = new Update();
                        update.Menu(adminId);
                        break;

                    case 4:
                        var delete = new Delete();
                        delete.Menu(adminId);
                        break;

                    case 5:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }
    }
}