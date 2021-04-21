using System;
using WebbutikFrontend.Views.Shared;
using static WebbutikFrontend.Utils.Helper;

namespace WebbutikFrontend.Controllers
{
    public class SoldBooksController
    {
        /// <summary>
        /// Shows a sold books menu to the <paramref name="adminId"/>.
        /// </summary>
        /// <param name="adminId"></param>
        public void Index(int adminId)
        {
            while (true)
            {
                Message.Ping(adminId);
                Views.SoldBooksMenu.Index.View();
                bool exit;
                do
                {
                    exit = true;
                    switch (Get.Choice())
                    {
                        case 1:
                            ShowSoldBooks(adminId);
                            break;

                        case 2:
                            MoneyEarned(adminId);
                            break;

                        case 3:
                            BestCustomer(adminId);
                            break;

                        case 4:
                            return;

                        default:
                            Message.Error();
                            exit = false;
                            break;
                    }
                } while (!exit);
            }
        }

        /// <summary>
        /// Lets the <paramref name="adminId"/> see the customer
        /// that has bought the most books.
        /// </summary>
        /// <param name="adminId"></param>
        private void BestCustomer(int adminId)
        {
            var (customer, books) = API.BestCustomer(adminId);
            if (customer != null)
            {
                Views.SoldBooksMenu.BestCustomer.View((customer, books));
                Console.ReadKey(true);
            }
            else
            {
                Message.Error("There are no customers.");
            }
        }

        /// <summary>
        /// Shows the <paramref name="adminId"/> the total sum
        /// of all the earnings from sold books.
        /// </summary>
        /// <param name="adminId"></param>
        private void MoneyEarned(int adminId)
        {
            Views.SoldBooksMenu.MoneyEarned.View(API.MoneyEarned(adminId));
            Console.ReadKey(true);
        }

        /// <summary>
        /// Shows all the sold books to the <paramref name="adminId"/>.
        /// </summary>
        /// <param name="adminId"></param>
        private void ShowSoldBooks(int adminId)
        {
            var books = API.SoldItems(adminId);
            if (books != null)
            {
                Views.SoldBooksMenu.ShowSoldBooks.View(books);
            }
            else
            {
                Message.Error("There are no sold books.");
            }

            Console.ReadKey(true);
        }
    }
}
