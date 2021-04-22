namespace FrontEndJesperPersson.View
{
    using FrontEndJesperPersson.Controller;
    using System;

    internal class Categories
    {
        private int Choice;
        private CustomerController Controller = new CustomerController();
        private bool KeepGoing;

        /// <summary>
        /// Prints out all categories.
        /// </summary>
        /// <param name="userId"></param>
        public void ListCategories(int userId)
        {
            ViewHelper.WriteOutList(Controller.ListCategories());
            Console.ReadLine();
            Controller.Ping(userId);
        }

        /// <summary>
        /// Prints out meny of Categories.
        /// </summary>
        /// <param name="userId"></param>
        public void Menu(int userId)
        {
            do
            {
                KeepGoing = true;
                ViewHelper.CreateMenu(@"---Kategorier---", "Lista alla kategorier", "Sök kategori genom nyckelord",
                    "Lista böcker i en viss kategorier", "Tillbaka");
                Choice = ViewHelper.InputInt();
                switch (Choice)
                {
                    case 1:
                        ListCategories(userId);
                        break;

                    case 2:
                        SearchCategoryByKeyword(userId);
                        break;

                    case 3:
                        ListBooksInCategory(userId);
                        break;

                    case 4:
                        KeepGoing = false;
                        break;
                }
            } while (KeepGoing);
        }

        /// <summary>
        /// Prints out all books that are connected to a certain category.
        /// </summary>
        /// <param name="userId"></param>
        private void ListBooksInCategory(int userId)
        {
            var keyword = ViewHelper.InputString("Skriv in din kategori");
            var categoryList = Controller.SearchCategories(keyword);
            if (categoryList.Count != 0)
            {
                var bookList = Controller.ListBookInCategory(categoryList[0].Id);
                ViewHelper.WriteOutList(bookList);
            }
            Controller.Ping(userId);
        }

        /// <summary>
        /// Prints out all categories that matches or contains the keyword.
        /// </summary>
        /// <param name="userId"></param>
        private void SearchCategoryByKeyword(int userId)
        {
            var keyword = ViewHelper.InputString("Skriv in sökning");
            ViewHelper.WriteOutList(Controller.SearchCategories(keyword));
            Console.ReadLine();
            Controller.Ping(userId);
        }
    }
}