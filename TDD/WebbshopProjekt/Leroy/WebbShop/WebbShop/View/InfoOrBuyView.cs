using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.LeeUtils;
using WebbShop.Controller;
using WebbShopAPI.Model;

namespace WebbShop.View
{
    class InfoOrBuyView
    {
        /// <summary>
        /// This gives you the option to find information or to buy a book
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <param name="skipCat"></param>
        /// <param name="book"></param>
        public static void Show(string name, User user, bool skipCat, bool book)
        {
            bool run = true;
            string choise = "";
            while (run)
            {
                TxtMessClass.Mess(Txt.ShowInfoOrBuyBook);
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        run = false;
                        if (skipCat)
                        {
                            TxtMessClass.Mess(BookController.ShowInformationByBook(name, book)).Equals(Txt.Nothing);
                        }
                        else
                        {
                            TxtMessClass.Mess(BookController.ShowInformation(name)).Equals(Txt.Nothing);
                        }
                        break;
                    case "2":
                        run = false;
                        if (skipCat)
                        {
                            string result = BookController.BuyBookByName(name, user, book);
                            TxtMessClass.Mess(result);
                            if (result.Equals(Txt.NoBookPurchased))
                                LogOut(user);
                        }
                        else
                        {
                            string result = BookController.BuyBook(name, user);
                            TxtMessClass.Mess(result);
                            if (result.Equals(Txt.NoBookPurchased))
                                LogOut(user);
                        }
                        break;
                    case "b":
                        run = false;
                        break;
                    case "B":
                        run = false;
                        break;
                    default:
                        TxtMessClass.Mess(Txt.WrongInputOrBack);
                        break;
                }
            }
        }

        private static void LogOut(User user)
        {
            TxtMessClass.Mess(Txt.SessiontimeOver);
            if (LogInController.LogOut(user))
                TxtMessClass.Mess(Txt.LogOut);
            else
                TxtMessClass.Mess(Txt.LogOutFail);
            LogInView.Show();
        }
    }
}
