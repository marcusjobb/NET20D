
namespace WebbshopFrontEnd.Controllers.UserControllers
{
    using Inlämning2;
    using WebbshopFrontEnd.Views;

    public static class UserChoiceController
    {
        public static WebbShopAPI api = new WebbShopAPI();

        public static void UserChoice(int userId, int choice)
        {
            switch (choice)
            {
                case 1:
                    UserCatController.ListAllCategory(userId);
                    break;

                case 2:
                    UserCatController.SearchCategories(userId);
                    break;

                case 3:
                    UserBookController.GetBooksInCat(userId);
                    break;

                case 4:
                    UserBookController.GetBooksAvaliable(userId);
                    break;

                case 5:
                    UserBookController.SearchBook(userId);
                    break;

                case 6:
                    UserBookController.SearchBookByAuthor(userId);
                    break;

                case 7:
                    Message.SignOut();
                    api.LogOut(userId);
                    //Start.RunStart();
                    break;
                    
                default:
                    Message.ErrorInput();
                    break;
            }
        }
    }
}
