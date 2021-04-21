namespace WebbShop_MikaelLarsson.Views
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using Microsoft.IdentityModel.Tokens;
    using WebbShop_MikaelLarsson.Controllers;
    using WebbShop_MikaelLarsson.Views.Admin;
    using WebbShop_MikaelLarsson.Views.UserView;

    /// <summary>
    /// Klass för hantering av admins bokmeny
    /// </summary>
    internal static class AdminBookController
    {
        /// <summary>
        /// Controller för hantering av View.AdminBookMenu().
        /// </summary>
        internal static void AdminBookMenu(int adminId )
        {
           var choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    var add = AdminBookView.AddBook();
                    WebbShopAPI.AddBook(adminId, add[0], add[1], ControlHelper.TryParse(add[2]), ControlHelper.TryParse(add[3]));
                    MessageView.PressEnter();
                    break;
                case 3:
                    var bookId = AdminBookView.ListBooks(WebbShopAPI.GetBooks(UserBookView.SearchBook()));
                    AdminBookView.GetAmount();
                    var setAmount = ControlHelper.TryParseReadLine();
                    WebbShopAPI.SetAmount(adminId, bookId, setAmount);
                    MessageView.PressEnter();
                    break;
                case 4:
                    bookId = AdminBookView.ListBooks(WebbShopAPI.GetBooks(UserBookView.SearchBook()));
                    var update = AdminBookView.UpdateBook();
                    WebbShopAPI.UpdateBook(adminId, bookId, update[0], update[1], ControlHelper.TryParse(update[2]));
                    MessageView.PressEnter();
                    break;
                case 5:
                    bookId = AdminBookView.ListBooks(WebbShopAPI.GetBooks(UserBookView.SearchBook()));
                    WebbShopAPI.DeleteBook(adminId, bookId);
                    MessageView.PressEnter();
                    break;
                case 6:
                    bookId = AdminBookView.ListBooks(WebbShopAPI.GetBooks(UserBookView.SearchBook()));
                    UserCategoryView.ListCategories(WebbShopAPI.GetCategories());
                    AdminCategoryView.ChooseCategory();
                    var categoryId = ControlHelper.TryParseReadLine();
                    WebbShopAPI.AddBookToCategory(adminId, bookId, categoryId);
                    MessageView.PressEnter();
                    break;
            }
        }
    }
}