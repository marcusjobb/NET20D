namespace WebbShop_MikaelLarsson.Controllers
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using WebbShop_MikaelLarsson.Views;
    using WebbShop_MikaelLarsson.Views.UserView;

    /// <summary>
    /// Klass för hantering av category-menyn.
    /// </summary>
    internal static class UserCategoryController
    {
        /// <summary>
        /// Controller för categorimenyn
        /// </summary>
        public static void CategoryMenu()
        {
            int choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    MenuView.categoryMenu = false;
                    break;
                case 2:
                    UserCategoryView.ListCategories(WebbShopAPI.GetCategories());
                    MessageView.PressEnter();
                    break;
                case 3:
                    string search = UserCategoryView.SearchCategory();
                    UserCategoryView.ListCategories(WebbShopAPI.GetCategories(search));
                    MessageView.PressEnter();
                    break;
                case 4:
                    int categoryId = UserCategoryView.GetCategoryId();
                    UserCategoryView.ListCategory(WebbShopAPI.GetCategory(categoryId));
                    MessageView.PressEnter();
                    break;
                case 5:
                    categoryId = UserCategoryView.GetCategoryId();
                    UserCategoryView.ListCategory(WebbShopAPI.GetAvailableBooks(categoryId));
                    MessageView.PressEnter();
                    break;
            }
        }
    }
}
