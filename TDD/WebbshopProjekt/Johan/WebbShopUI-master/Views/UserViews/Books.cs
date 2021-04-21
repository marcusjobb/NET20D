using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebbShopAPI.Models;

namespace WebbShopUI.Views.UserViews
{
    public class Books
    {
        public int BooksMenu()
        {
            Console.Clear();
            Console.WriteLine("Books!");
            Console.WriteLine("");
            Console.WriteLine("1. List all books in a category");
            Console.WriteLine("2. Get a specific book(s) by searching with a keyword");
            Console.WriteLine("3. Get a specific book using it's ID");
            Console.WriteLine("4. Get books by an author");
            int.TryParse(Console.ReadLine(), out int choice);

            return choice;
        }

        public void ListAllBooks(IEnumerable<Book> listOfBooks)
        {
            var books = listOfBooks;
            if (books != null)
            {
                Console.Clear();
                int count = 1;
                foreach (var b in books)
                {
                    Console.WriteLine($"{count} - {b.Title} - {b.Author} - Amount of books: {b.Amount}");
                    count++;
                }
                
            }
            if(books == null)
            {
                Console.WriteLine("Books not found!");
                Console.ReadKey();
            }
            
        }

        public int BuyBookOption()
        {
            string answer;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Do you want to buy one of the books?");
                Console.WriteLine("Type in Y or N below:");
                answer = Console.ReadLine().ToUpper();

            } while (answer != "Y" && answer != "N");
            
            if (answer == "Y")
            {
                 Console.Write("Type in the id number of the book you want to buy: ");
                 int.TryParse(Console.ReadLine(), out int choice);

                 return choice;
            }
           
            return 0;

        }

        public int SpecificBooksInCategory()
        {
            string input;
            do
            {
                Console.WriteLine("Type in the id of the category where you want to see the associated books!");
                input = Console.ReadLine();


            } while (input == String.Empty);

            int.TryParse(input, out int choice);

            return choice;
        }

        public string SpecificBookKeyword()
        {
            string userKeyword;
            do
            {
                Console.WriteLine("Type in a word or the name of the book you are searching for!");
                userKeyword = Console.ReadLine();

            } while (userKeyword == String.Empty);

            return userKeyword;
        }

        public int SpecificBookId()
        {
            string id;
            do
            {
                Console.WriteLine("Type in the ID of the book you are looking for!");
                id = Console.ReadLine();

            } while (id == String.Empty);

            int.TryParse(id, out int choice);

            return choice;
        }

        public string BookByAuthor()
        {
            string authorKeyword;
            do
            {
                Console.WriteLine("Type in the name of the author you are searching for!");
                authorKeyword = Console.ReadLine();

            } while (authorKeyword == String.Empty);

            return authorKeyword;
        }

        

    }
}
