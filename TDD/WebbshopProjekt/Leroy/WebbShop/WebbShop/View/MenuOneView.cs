using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Model;
using WebbShop.LeeUtils;

namespace WebbShop.View
{
    static class MenuOneView
    {
        /// <summary>
        /// This is the first menu you enter witch gives you options on how to navigate through the shop
        /// </summary>
        /// <param name="user"></param>
        public static void Show(User user)
        {
            user.SesionTimer = DateTime.Now;
            bool run = true;
            string choise = "";
            while (run)
            {
                if (user.IsAdmin)
                    TxtMessClass.Mess(Txt.AdminMenu);
                else
                    TxtMessClass.Mess(Txt.UserMenu);
                choise = Console.ReadLine();
                string name = "";
                string result = "";
                switch (choise)
                {
                    case "1":
                        TxtMessClass.Mess(Controller.CategoryController.ShowAllCategories());
                        break;
                    case "2":
                        TxtMessClass.Mess(Txt.Keyword);
                        name = Console.ReadLine();
                        TxtMessClass.Mess(Controller.CategoryController.FindCategory(name));
                        break;
                    case "3":
                        TxtMessClass.Mess(Txt.Keyword);
                        name = Console.ReadLine();
                        TxtMessClass.Mess(Controller.BookController.ShowAllBooksInCategory(name));
                        break;
                    case "4":
                        TxtMessClass.Mess(Txt.Keyword);
                        name = Console.ReadLine();
                        result = Controller.BookController.GetAvailableBooksFromCategory(name);
                        TxtMessClass.Mess(result);
                        if (!result.Equals(Txt.Nothing))
                            InfoOrBuyView.Show(name, user, false, true);
                        break;
                    case "5":
                        TxtMessClass.Mess(Txt.Keyword);
                        name = Console.ReadLine();
                        result = Controller.BookController.GetBooksByKeyword(name);
                        TxtMessClass.Mess(result);
                        if (!result.Equals(Txt.Nothing))
                            InfoOrBuyView.Show(name, user, true, true);
                        break;
                    case "6":
                        TxtMessClass.Mess(Txt.Keyword);
                        name = Console.ReadLine();
                        result = Controller.BookController.GetBooksByAuthor(name);
                        TxtMessClass.Mess(result);
                        if (!result.Equals(Txt.Nothing))
                            InfoOrBuyView.Show(name, user, true, false);
                        break;
                    case "7":
                        if (user.IsAdmin)
                            AdminView.Show(user);
                        else
                            TxtMessClass.Mess(Txt.NoAccess);
                        break;
                    case "b":
                        run = false;
                        if (LogInController.LogOut(user))
                            TxtMessClass.Mess(Txt.LogOut);
                        else
                            TxtMessClass.Mess(Txt.LogOutFail);
                        break;
                    case "B":
                        run = false;
                        if (LogInController.LogOut(user))
                            TxtMessClass.Mess(Txt.LogOut);
                        else
                            TxtMessClass.Mess(Txt.LogOutFail);
                        break;
                    default:
                        TxtMessClass.Mess(Txt.WrongInputOrBack);
                        break;
                }
            }

        }
    }
}
