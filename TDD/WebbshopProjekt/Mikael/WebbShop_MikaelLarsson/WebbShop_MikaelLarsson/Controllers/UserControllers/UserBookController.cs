namespace WebbShop_MikaelLarsson.Controllers
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using WebbShop_MikaelLarsson.Views;
    using WebbShop_MikaelLarsson.Views.UserView;

    /// <summary>
    /// Klass för hantering av bokmenyn.
    /// </summary>
    internal static class UserBookController
    {
        /// <summary>
        /// Controller för bokmenyn
        /// </summary>
        internal static void BookMenu()
        {
            var choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    MenuView.bookMenu = false;
                    break;
                case 2:
                    string search = UserBookView.SearchBook();
                    UserBookView.ListBooks(WebbShopAPI.GetBooks(search));
                    MessageView.PressEnter();
                    break;
                case 3:
                    search = UserBookView.SearchAuthor();
                    UserBookView.ListBooks(WebbShopAPI.GetAuthors(search));
                    MessageView.PressEnter();
                    break;
            }
        }
    }
}
