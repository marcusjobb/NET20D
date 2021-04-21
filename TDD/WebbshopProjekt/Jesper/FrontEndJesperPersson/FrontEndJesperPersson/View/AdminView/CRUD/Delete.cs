namespace FrontEndJesperPersson.View.AdminMenu
{
    using FrontEndJesperPersson.Controller;

    internal class Delete
    {
        private int Choice;
        private AdminController Controller = new AdminController();
        private CustomerController HomeController = new CustomerController();
        private bool KeepGoing;

        /// <summary>
        /// Startpage and menu of Delete.
        /// </summary>
        /// <param name="adminId"></param>
        internal void Menu(int adminId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu("---Radera---", "Ta bort bok", "Ta bort kategori", "Tillbaka");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        DeleteBook(adminId);
                        break;

                    case 2:
                        DeleteCategory(adminId);
                        break;

                    case 3:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// Print out if book is deleted or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteBook(int adminId)
        {
            var book = ViewHelper.GetBook();
            if (Controller.DeleteBook(adminId, book.Id))
                ViewHelper.SuccessMessage("Lyckat");
            else
                ViewHelper.ErrorMessage("Ingen bok har tagits bort.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// Print out if category either is deleted or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void DeleteCategory(int adminId)
        {
            var category = ViewHelper.GetCategory("radera");
            if (category != null)
            {
                if (Controller.DeleteCategory(adminId, category.Id))
                    ViewHelper.SuccessMessage($"{category.Name} är raderad som kategori.");
                else
                    ViewHelper.ErrorMessage("Ingen kategori har tagit borts. Kan finnas en koppling till kategorin.");
            }
            else
            {
                ViewHelper.ErrorMessage("Ingen kategori har tagit borts,");
            }

            Controller.Ping(adminId);
        }
    }
}