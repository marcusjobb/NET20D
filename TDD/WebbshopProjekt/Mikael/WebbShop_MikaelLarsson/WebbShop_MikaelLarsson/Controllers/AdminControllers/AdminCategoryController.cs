namespace WebbShop_MikaelLarsson.Views
{
    using System;
    using Inlamn2WebbShop_MLarsson;
    using WebbShop_MikaelLarsson.Views.Admin;
    using WebbShop_MikaelLarsson.Views.UserView;

    /// <summary>
    /// Klass för hantering av admins category-meny
    /// </summary>
    internal static class AdminCategoryController
    {
        /// <summary>
        /// Controller för hantering av View.AdminCategoryMenu().
        /// </summary>
        internal static void AdminCategoryMenu(int adminId)
        {
            int choice = ControlHelper.TryParseReadLine();
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    AdminCategoryView.AddCategory();
                    var add = ControlHelper.AdjustName();
                    WebbShopAPI.AddCategory(adminId, add);
                    MessageView.PressEnter();
                    break;
                case 3:
                    UserCategoryView.ListCategories(WebbShopAPI.GetCategories());
                    AdminCategoryView.ChooseCategory();
                    var categoryId = ControlHelper.TryParseReadLine();
                    AdminCategoryView.UpdateCategory();
                    var newName = ControlHelper.AdjustName();
                    WebbShopAPI.UpdateCategory(adminId, categoryId, newName);
                    MessageView.PressEnter();
                    break;
                case 4:
                    UserCategoryView.ListCategories(WebbShopAPI.GetCategories());
                    AdminCategoryView.ChooseCategory();
                    var _categoryId = ControlHelper.TryParseReadLine();
                    WebbShopAPI.DeleteCategory(adminId, _categoryId);
                    MessageView.PressEnter();
                    break;
            }
        }
    }
}