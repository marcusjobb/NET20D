using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Utils;
using WebbShopAPI.Controller;
using WebbShopAPI.View;
using WebbShopAPI.Model;

namespace WebbShopAPI.View
{
    static class MenuOne
    {
        /// <summary>
        /// Displays the first menu options
        /// </summary>
        /// <returns></returns>
        public static string Show()
        {
            bool running = true;
            StringBuilder sb = new StringBuilder();
            while (running)
            {
                Console.Clear();
                sb.Clear();
                sb.Append(Txt.Welcome);
                sb.Append(Txt.TestRun);
                TxtView.MessLine(sb.ToString());
                string choise = Console.ReadLine();

                User admin = new User { IsAdmin = true, Name = "Neo" };
                Book bookMatrix = new Book { ID = 5 };
                switch (choise)
                {
                    case "1":
                        InitClass.StartAPITest();
                        InitClass.StartAdminTest();
                        TxtView.MessLine(Txt.TestDone);
                        TxtView.MessLine(Txt.PressAnyKey);
                        running = false;
                        break;
                    case "2":
                        var book = new Book { Title = "Matrix", Author = "Brothers", Price = 175, Amount = 1 };
                        if (WebbShopAPIClass.AddBook(admin, WebbShopAPIClass.GetBook(book.Title), book.Title, "J.K. Rowling", 175, 5))
                        {
                            {
                                Console.WriteLine($"The book {book.Title} was added to your shop.");
                            }
                        }
                        break;
                    case "3":
                            if (WebbShopAPIClass.BuyBook(admin, bookMatrix))
                            {
                                Console.WriteLine("Book was purchased");
                            }
                        break;
                    case "b":
                        running = false;
                        break;
                    case "B":
                        running = false;
                        break;
                    default:
                        Console.WriteLine(Txt.WrongInput);
                        break;
                }
                Console.ReadKey();
            }
            return "";
        }
    }
}
