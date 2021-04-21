using Inlämning2;
using WebbshopFrontEnd.Views;
using WebbshopFrontEnd.Views.Admin;

namespace WebbshopFrontEnd.Controllers.AdminControllers
{
    /// <summary>
    /// Klass för att sköta admins inmatning i menyerna.
    /// </summary>
    public static class AdminChoiceController
    {
        public static WebbShopAPI api = new WebbShopAPI();
        
        /// <summary>
        /// Metoden för adminmenyn.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="choice"></param>
        public static void AdminMenuChoice(int adminId, int choice)
        {
            switch (choice)
            {
                case 1:
                    AdminBookMenu.ShowBookMenu(adminId);
                    break;

                case 2:
                    AdminCatMenu.ShowCatMenu(adminId);
                    break;
                
                case 3:
                    AdminUserMenu.ShowUserMenu(adminId);
                    break;
                
                case 4:
                    Message.SignOut();
                    api.LogOut(adminId);
                    break;

                default:
                    Message.ErrorInput();
                    break;
            }
        }

        /// <summary>
        /// Metod för bokmenyn.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="choice"></param>
        public static void BookMenuChoice(int adminId, int choice)
        {
            switch (choice)
            {
                case 1:
                    AdminBookController.AddBook(adminId);
                    break;

                case 2:
                    AdminBookController.SetAmountBooks(adminId);
                    break;

                case 3:
                    AdminBookController.UpdateBook(adminId);
                    break;

                case 4:
                    AdminBookController.DeleteBook(adminId);
                    break;

                case 5:
                    AdminViews.AdminMenu(adminId);
                    break;

                default:
                    Message.ErrorInput();
                    break;
            }
        }

        /// <summary>
        /// Metod för kategorimenyn.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="choice"></param>
        public static void CatMenuChoice(int adminId, int choice)
        {
            switch (choice)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    break;

                case 5:
                    AdminViews.AdminMenu(adminId);
                    break;

                default:
                    Message.ErrorInput();
                    break;

            }
        }

        /// <summary>
        /// Metod för användarmenyn.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="choice"></param>
        public static void UserMenuChoice(int adminId, int choice)
        {
            switch (choice)
            {
                case 1:
                    break;

                case 2:
                    break;

                case 3:
                    break;

                case 4:
                    AdminViews.AdminMenu(adminId);
                    break;
                
                default:
                    Message.ErrorInput();
                    break;

            }
        }
    }
}
