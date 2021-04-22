namespace FrontEndJesperPersson.View.AdminMenu
{
    using FrontEndJesperPersson.Controller;
    using System;
    using WebbShopJesperPersson.Model;

    internal class Create
    {
        private static bool KeepGoing;
        private AdminController Controller = new AdminController();

        /// <summary>
        /// Startpage and menu of Create.
        /// </summary>
        /// <param name="adminId"></param>
        public void Menu(int adminId)

        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu("---Skapa---", "Användare", "Bok", "Kategori", "Addera kategori till bok", "Tillbaka");
                var choice = ViewHelper.InputInt();
                switch (choice)
                {
                    case 1:
                        CreateUser(adminId);
                        break;

                    case 2:
                        CreateBook(adminId);
                        break;

                    case 3:
                        CreateCategory(adminId);
                        break;

                    case 4:
                        AddCategoryToBook(adminId);
                        break;

                    case 5:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// Prints out if category could connect to book or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddCategoryToBook(int adminId)
        {
            var book = ViewHelper.GetBook();
            var category = ViewHelper.GetCategory("koppla till boken");
            if (book != null && category != null)
            {
                if (Controller.AddCategoryToBook(adminId, book.Id, category.Id))
                    ViewHelper.SuccessMessage($"{category.Name} är nu kopplad till {book.Title}");
            }
            else ViewHelper.ErrorMessage("Kopplingen gick att inte göra.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// Print of instruction for adding a new book to database.
        /// </summary>
        /// <param name="adminId"></param>
        private void AddNewBook(int adminId)
        {
            Console.WriteLine("Var god fyll i uppgifterna för boken du önskar lägga till");
            int id = default;
            var title = ViewHelper.InputString("Titel: ");
            var author = ViewHelper.InputString("Författare: ");
            double price = ViewHelper.InputDouble("Pris: ");
            var amount = ViewHelper.InputInt("Antal: ");

            if (Controller.CreateBook(adminId, amount, id, title, author, price))
                ViewHelper.SuccessMessage($"{title} är skapad!");
            else ViewHelper.ErrorMessage("Boken skapades inte.");
        }

        /// <summary>
        /// Print out and takes input for adding amount to book.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="book"></param>
        private void BookExists(int adminId, Book book)
        {
            Console.WriteLine("Boken finns redan. Skriv in hur många du vill addera på saldot");
            var amount = ViewHelper.InputInt("Antal: ");
            if (Controller.CreateBook(adminId, amount, book.Id) && amount > 0)
                ViewHelper.SuccessMessage($"Uppdateringen gick bra. Saldot är nu {book.Amount + amount}");
            else ViewHelper.ErrorMessage("Gick ej att utöka saldot");
        }

        /// <summary>
        /// Flow control for either creating a new book or adding an amount to exïsting book.
        /// </summary>
        /// <param name="adminId"></param>
        private void CreateBook(int adminId)
        {
            var book = ViewHelper.GetBook();
            if (book == null)
            {
                AddNewBook(adminId);
            }
            else
            {
                BookExists(adminId, book);
            }
            Controller.Ping(adminId);
        }

        /// <summary>
        /// Print out information for creating category and if succeeded or not.
        /// </summary>
        /// <param name="adminId"></param>
        private void CreateCategory(int adminId)
        {
            string categoryName = ViewHelper.InputString("Skapa kategorin: ");

            if (Controller.CreateCategory(adminId, categoryName))
                ViewHelper.SuccessMessage($"{categoryName} är nu skapad");
            else
                ViewHelper.ErrorMessage("Kategorin finns möjligen redan.");

            Controller.Ping(adminId);
        }

        /// <summary>
        /// Prints out instruction for creating a new user.
        /// </summary>
        /// <param name="adminId"></param>
        private void CreateUser(int adminId)
        {
            var name = ViewHelper.InputString("Användarnamn: ");
            var password = ViewHelper.InputString("Lösenord [default=Codic2021]: ");
            var success = Controller.CreateUser(adminId, name, password);
            if (success) ViewHelper.SuccessMessage($"{name} är nu skapad som ny användare.");
            else ViewHelper.ErrorMessage($"{name} kunde inte skapas. Var god pröva ett annat användarnamn");

            Controller.Ping(adminId);
        }
    }
}