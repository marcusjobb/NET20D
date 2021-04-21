namespace FrontEndJesperPersson
{
    using FrontEndJesperPersson.Controller;
    using System;
    using System.Collections.Generic;
    using WebbShopJesperPersson.Model;

    internal static class ViewHelper
    {
        private static int Choice;
        private static AdminController Controller = new AdminController();
        private static CustomerController HomeController = new CustomerController();

        /// <summary>
        /// To create and empty row for better User Interface.
        /// </summary>
        public static void BlankStep()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Help-method to create a menu with a header.
        /// </summary>
        /// <param name="header">Top of the list, a menu name.</param>
        /// <param name="rows">print outs the menuoptions.</param>
        public static void CreateMenu(string header, params string[] rows)
        {
            int counter = 1;
            Console.Clear();
            Console.WriteLine(header);
            foreach (var row in rows)
            {
                Console.WriteLine($"{counter++}. {row}");
            }
        }

        /// <summary>
        /// Print out a textmessage.
        /// </summary>
        /// <param name="text"></param>
        public static void ErrorMessage(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }

        /// <summary>
        /// Help-method to select a book.
        /// </summary>
        /// <returns>the book if it could be found. Null if not found.</returns>
        public static Book GetBook()
        {
            var keyword = ViewHelper.InputString("Sök efter bok: ");
            var bookList = HomeController.GetBooksByKeyword(keyword);
            if (bookList.Count != 0)
            {
                Console.WriteLine($"Är det { bookList[0].Title} du sökte, skriven av {bookList[0].Author}?");
                Choice = ViewHelper.InputInt($"1. Ja\n2. Nej");

                if (Choice == 1) return bookList[0];
            }
            return null; // null= couldn´t find book.
        }

        /// <summary>
        /// Help-method to select a category. Print out all categoris and then the user choose by enter a number."
        /// </summary>
        /// <param name="option">Either update, delete or pick for exampel.</param>
        /// <returns>the BookCategory or null. </returns>
        public static BookCategory GetCategory(string option)
        {
            var categoryList = HomeController.ListCategories();
            ViewHelper.WriteOutList(categoryList);
            Choice = ViewHelper.InputInt($"Välj kategori du önskar {option} genom att mata in en siffra och tryck enter.");
            if (categoryList.Count >= Choice && Choice != 0) // if user picks a number from the list. Can´t be 0.
            {
                var pickedCategory = Choice - 1;
                return categoryList[pickedCategory];
            }
            else return null;
        }

        public static int GetUserId(int adminId)
        {
            var keyword = ViewHelper.InputString("Sök upp kund: ");
            var userList = Controller.FindUser(adminId, keyword);
            if (userList.Count != 0)
            {
                Console.WriteLine($"är det { userList[0].Name} du vill uppdatera?");
                Choice = ViewHelper.InputInt($"1. Ja\n2. Nej");
                if (Choice == 1) return userList[0].Id;
            }
            return 0; // 0=fails or no.
        }

        /// <summary>
        ///  Handle double inputs with a tryparse.
        /// </summary>
        /// <param name="question">If you want to print out a textmessage before input.</param>
        /// <returns>the input in double or 0 if fails.</returns>
        public static double InputDouble(string question = "")
        {
            if (question != "")
                Console.WriteLine(question);

            Console.Write("> ");

            var success = double.TryParse(Console.ReadLine(), out double nr);
            return nr;
        }

        /// <summary>
        /// Handle integers inputs with a tryparse.
        /// </summary>
        /// <returns>the input in int or 0 if fails.</returns>
        public static int InputInt(string question = "")
        {
            if (question != "")
                Console.WriteLine(question);

            Console.Write("> ");

            var success = int.TryParse(Console.ReadLine(), out int nr);
            return nr;
        }

        /// <summary>
        /// handle string inputs.
        /// </summary>
        /// <returns>returns the input</returns>
        public static string InputString(string question = "")
        {
            if (question != "")
                Console.WriteLine(question);

            return Console.ReadLine();
        }

        /// <summary>
        /// Print out a textmessage.
        /// </summary>
        /// <param name="text"></param>
        public static void SuccessMessage(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }

        /// <summary>
        /// Print out a the name of categories. Errormessage if list is empty.
        /// </summary>
        /// <param name="list">BookCategory</param>
        public static void WriteOutList(List<BookCategory> list)
        {
            if (list.Count != 0)
            {
                int counter = 1;
                foreach (var item in list)
                {
                    Console.WriteLine($"{counter++}. Kategori: {item.Name}");
                }
            }
            else ErrorMessage("Kategorin du sökte fanns inte");
        }

        /// <summary>
        /// overloaded method, print out user information, if empty errormessage.
        /// </summary>
        /// <param name="list">of users</param>
        public static void WriteOutList(List<User> list)
        {
            if (list.Count != 0)
            {
                foreach (var item in list) Console.WriteLine($"ID:{item.Id}.\nNamn: {item.Name}\nLösenord: {item.Password}");
            }
            else ErrorMessage("Användaren du sökte finns tyvärr inte");

            Console.ReadLine();
        }

        /// <summary>
        /// overloaded method the prints out information about book, erromessage if list is empty.
        /// </summary>
        /// <param name="list"></param>
        public static void WriteOutList(List<Book> list)
        {
            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine("---------");
                    Console.WriteLine($"ID:{item.Id}\nBok: {item.Title}\nFörfattare: {item.Author}\nPris: {item.Price}\nLagerstatus: {item.Amount}");
                    if (item.Category != null)
                        Console.WriteLine($"Kategori: {item.Category.Name}");
                    Console.WriteLine("---------");
                }
            }
            else ErrorMessage("Boken fanns tyvärr inte");
            Console.ReadLine();
        }
    }
}