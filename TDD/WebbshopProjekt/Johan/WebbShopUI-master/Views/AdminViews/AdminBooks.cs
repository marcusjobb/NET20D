using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebbShopUI.Views.AdminViews
{
    class AdminBooks
    {
        public int AdminBooksMenu()
        {
            Console.Clear();
            Console.WriteLine("Book options!");
            Console.WriteLine("");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Add a book to a specific category");
            Console.WriteLine("3. Set a new amount of a book");
            Console.WriteLine("4. Update an existing book");
            Console.WriteLine("5. Delete a book");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }

        public List<string> AddNewBookStrings()
        {
            List<string> newStringBookList = new List<string>();
            //bookId, string title, string author, int price, int amount
            Console.WriteLine("Type in the needed information down below in order to add a new book.");
            Console.WriteLine("");
            Console.Write("Type in Title:");
            string title = Console.ReadLine();
            newStringBookList.Add(title);

            Console.WriteLine("");
            Console.Write("Type in the Author:");
            string author = Console.ReadLine();
            newStringBookList.Add(author);

            return newStringBookList;

        }

        public List<int> AddNewBookInts()
        {
            List<int> newIntBookList = new List<int>();
            Console.WriteLine("");
            Console.Write("Type in bookID:");
            int.TryParse(Console.ReadLine(), out int bookId);
            newIntBookList.Add(bookId);

            Console.WriteLine("");
            Console.Write("Type in the Price:");
            int.TryParse(Console.ReadLine(), out int price);
            newIntBookList.Add(price);

            Console.WriteLine("");
            Console.Write("Type in the Amount:");
            int.TryParse(Console.ReadLine(), out int amount);
            newIntBookList.Add(amount);

            return newIntBookList;
        }


        public List<int> BookToCategory()
        {
            List<int> bookValues = new List<int>();

            Console.Write("Type in the necessary information below!");
            Console.WriteLine("");
            Console.Write("Type in the ID of the book: ");
            int.TryParse(Console.ReadLine(), out int bookId);
            bookValues.Add(bookId);

            Console.WriteLine("");
            Console.Write("Type in the ID of the category you want to add the book to: ");
            int.TryParse(Console.ReadLine(), out int categoryId);
            bookValues.Add(categoryId);

            return bookValues;
        }

        public List<int> SetNewAmount()
        {
            List<int> bookValues = new List<int>();

            Console.Write("Type in the necessary information below!");
            Console.WriteLine("");
            Console.Write("Type in the ID of the book: ");
            int.TryParse(Console.ReadLine(), out int bookId);
            bookValues.Add(bookId);

            Console.WriteLine("");
            Console.Write("Type in the new amount you want to add to the book: ");
            int.TryParse(Console.ReadLine(), out int amount);
            bookValues.Add(amount);

            return bookValues;
        }

        public List<string> UpdateBookInfo()
        {
            List<string> newStringInfoList = new List<string>();
            //bookId, string title, string author, int price, int amount
            Console.WriteLine("Type in the needed information down below to update a book.");
            Console.WriteLine("");
            Console.Write("Type in Title:");
            string title = Console.ReadLine();
            newStringInfoList.Add(title);

            Console.WriteLine("");
            Console.Write("Type in the Author:");
            string author = Console.ReadLine();
            newStringInfoList.Add(author);

            return newStringInfoList;
        }

        public int Price()
        {
            Console.WriteLine("");
            Console.Write("Type in the new price: ");
            int.TryParse(Console.ReadLine(), out int price);

            return price;
        }

        public int BookID()
        {
            Console.WriteLine("");
            Console.Write("Type in the book ID: ");
            int.TryParse(Console.ReadLine(), out int bookId);

            return bookId;

        }

        
    }
}
