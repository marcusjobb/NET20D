namespace FrontEndJesperPersson.View.AdminMenu
{
    using FrontEndJesperPersson.Controller;

    internal class Update
    {
        private int Choice;
        private AdminController Controller = new AdminController();
        private CustomerController HomeController = new CustomerController();
        private bool KeepGoing;
        private bool Success;

        /// <summary>
        /// Startpage and menu of Update.
        /// </summary>
        /// <param name="adminId"></param>
        internal void Menu(int adminId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu(@"---Uppdatera---", "Reglera saldot", "Uppdatera bok", "Uppdatera kategori",
                    "Avblockera/blockera användare", "Uppgradera/nedgradera användare", "Tillbaka");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        SetAmount(adminId);
                        break;

                    case 2:
                        UpdateBook(adminId);
                        break;

                    case 3:
                        UpdateCategory(adminId);
                        break;

                    case 4:
                        BlockOrActivateUser(adminId);
                        break;

                    case 5:
                        DemoteOrPromoteUser(adminId);
                        break;

                    case 6:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// flow controll to either block or unblock user.
        /// </summary>
        /// <param name="adminId"></param>
        private void BlockOrActivateUser(int adminId)
        {
            Choice = ViewHelper.InputInt("1. Blockera\n2. Avblockera");
            switch (Choice)
            {
                case 1:
                    BlockUser(adminId);
                    break;

                case 2:
                    UnblockUser(adminId);
                    break;
            }
        }

        /// <summary>
        /// prints out if sucess or errormessage if user is blocked or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void BlockUser(int adminId)
        {
            var userId = ViewHelper.GetUserId(adminId);
            if (userId != 0)
            {
                if (Controller.BlockUser(adminId, userId))
                    ViewHelper.SuccessMessage("Kunden är nu blockad.");
            }
            else ViewHelper.ErrorMessage("Du har inte blockerat någon.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// control flow to choose between promote or demote.
        /// </summary>
        /// <param name="adminId"></param>
        private void DemoteOrPromoteUser(int adminId)
        {
            Choice = ViewHelper.InputInt("1. Uppgradera\n2. Nedgradera");
            switch (Choice)
            {
                case 1:
                    PromoteUser(adminId);
                    break;

                case 2:
                    DemoteUser(adminId);
                    break;
            }
        }

        /// <summary>
        /// prints out either sucess or erromessage if user is admin or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void DemoteUser(int adminId)
        {
            var userId = ViewHelper.GetUserId(adminId);
            if (userId != 0)
            {
                if (Controller.DemoteUser(adminId, userId))
                    ViewHelper.SuccessMessage("Användaren är inte längre Admin.");
            }
            else ViewHelper.ErrorMessage("Du har inte gjort någon ändring.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// prints out success or errormesssage if user is demoted to regular user or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void PromoteUser(int adminId)
        {
            var userId = ViewHelper.GetUserId(adminId);
            if (userId != 0)
            {
                if (Controller.PromoteUser(adminId, userId))
                    ViewHelper.SuccessMessage("Användaren är nu Admin.");
            }
            else ViewHelper.ErrorMessage("Du lyckades inte göra någon till Admin.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// Prints out instrucions to change book amount.
        /// </summary>
        /// <param name="adminId"></param>
        private void SetAmount(int adminId)
        {
            var book = ViewHelper.GetBook();
            if (book != null)
            {
                var amount = ViewHelper.InputInt($"Saldot är just nu:{book.Amount} st\nVad önskar du ändra lagersaldot till?");
                Success = Controller.SetAmount(adminId, book.Id, amount);
                if (Success) ViewHelper.SuccessMessage($"Saldot är ändrat till: {amount} st");
                else ViewHelper.ErrorMessage("Saldot kunde inte korrigeras.");
            }
            else
                ViewHelper.ErrorMessage("Sök mer specifikt, eller så finns inte boken.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// prints out if sucess or errormessage if user is active again or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void UnblockUser(int adminId)
        {
            var userId = ViewHelper.GetUserId(adminId);
            if (userId != 0)
            {
                if (Controller.UnblockUser(adminId, userId))
                    ViewHelper.SuccessMessage("Kunden är nu aktiv igen.");
            }
            else ViewHelper.ErrorMessage("Du har inte aktiverat någon.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// Print out instructions for update book.
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateBook(int adminId)
        {
            var book = ViewHelper.GetBook();
            if (book != null)
            {
                ViewHelper.CreateMenu("Vad önskar du uppdatera?", "Titel", "Författare", "Pris");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        book.Title = ViewHelper.InputString("Titel: ");
                        break;

                    case 2:
                        book.Author = ViewHelper.InputString("Författare: ");
                        break;

                    case 3:
                        book.Price = ViewHelper.InputDouble("Pris: ");
                        break;
                }
                Success = Controller.UpdateBook(adminId, book.Price, book.Title, book.Author, book.Id);

                if (Success) ViewHelper.SuccessMessage("Uppdateringen lyckades");
                else ViewHelper.ErrorMessage("Uppdateringen lyckades inte.");
            }
            else
                ViewHelper.ErrorMessage("Sök mer specifikt, eller så finns inte boken.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// Print of instrucitions to update category.
        /// </summary>
        /// <param name="adminId"></param>
        private void UpdateCategory(int adminId)
        {
            var category = ViewHelper.GetCategory("uppdatera");

            if (category != null)
            {
                var Name = ViewHelper.InputString("Nytt kategorinamn: ");
                Success = Controller.UpdateCategory(adminId, category.Id, Name);

                if (Success) ViewHelper.SuccessMessage("Kategorin är uppdaterad.");
                else ViewHelper.ErrorMessage("Kunde inte uppdaters.");
            }
            else
                ViewHelper.ErrorMessage("Välj ett nummer kopplat till listan.");

            Controller.Ping(adminId);
        }
    }
}