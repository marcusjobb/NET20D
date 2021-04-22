using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShopAPI.Models;

namespace WebbShopUI.Views.UserViews
{
    class Categories
    {

        public int CategoriesMenu()
        {
            Console.Clear();
            Console.WriteLine("Categories!");
            Console.WriteLine("");
            Console.WriteLine("1. List all categories of books");
            Console.WriteLine("2. Get a specific category/categories by searching with a keyword");
            Console.WriteLine("3. Get a specific category using it's ID");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }

        public string SpecificCategoryKeyword()
        {
            Console.WriteLine("Type in a word or the name of the category you are searching for!");
            string userKeyword = Console.ReadLine();

            return userKeyword;
        }

        public int SpecificCategoryId()
        {
            string input;
            do
            {
                Console.WriteLine("Type in the ID of the category you are looking for!");
                input = Console.ReadLine();


            } while (input == String.Empty);

            int.TryParse(input, out int choice);

            return choice;
        }

        public void ListCategories(IEnumerable<BookCategory> listOfCategories)
        {
            var categories = listOfCategories;
            if (categories != null)
            {
                Console.Clear();
                foreach (var cat in categories)
                {
                    Console.WriteLine($"{cat.Id} - {cat.Name}");
                }
                Console.ReadKey();
            }
            if (categories.Count() == 0)
            {
                Console.WriteLine("Category doesn't exist.");
                Console.ReadKey();
            }
        }

        public void ListBook(IEnumerable<Book> books)
        {
            var book = books;
            if (book != null)
            {
                Console.Clear();
                foreach (var b in book)
                {
                    Console.WriteLine($"{b.Title} - {b.Author}");
                }
                Console.ReadKey();
            }
            if(book == null)
            {
                Console.WriteLine("No books found in that category.");
            }
        }



    }
}
