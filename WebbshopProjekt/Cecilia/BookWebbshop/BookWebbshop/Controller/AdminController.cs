using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WebbShopAPI;

namespace BookWebbshop.Controller
{
    class AdminController
    {
        public int LogInAdmin()
        {
            var api = new WebbshopAPI();

            Console.WriteLine("" +
                "\nLogga in som admin:");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            int userID = api.Login(name, password);
            api.GetAdminID(userID);

            if (userID > 0)
            {
                Console.WriteLine("" +
                    "\nDu är inloggad");
                return userID;
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
                return 0;
            }
        }

        public void AddUser(int adminId)
        {
            var api = new WebbshopAPI();

            Console.WriteLine("" +
                "\nFyll i användarens uppgifter");
            Console.Write("Namn: ");
            string name = Console.ReadLine();
            Console.Write("Lösenord: ");
            string password = Console.ReadLine();

            if (api.AddUser(adminId, name, password) == true)
            {
                Console.WriteLine("" +
                    "\nAnvändaren finns nu i systemet");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }
        }

        public void SearchUser(int adminId)
        {
            var api = new WebbshopAPI();

            Console.Write("" +
                "\nSökord: ");
            string keyword = Console.ReadLine();

            api.FindUser(adminId, keyword);

        }

        public void AddBook(int adminId)
        {
            var api = new WebbshopAPI();

            Console.WriteLine("" +
                "\nFyll i uppgifter:");
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();
            Console.Write("Pris: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("Antal: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (api.AddBook(adminId, title, author, price, amount) == true)
            {
                Console.WriteLine("" +
                    "\nNu finns boken i systemet");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }
        }

        public void AddCategory(int adminId)
        {
            var api = new WebbshopAPI();

            Console.WriteLine("" +
                "\nFyll i uppgifter:");
            Console.Write("Namn på ny kategori: ");
            string title = Console.ReadLine();

            if (api.AddCategory(adminId, title) == true)
            {
                Console.WriteLine("" +
                    "\nNu finns kategorin i systemet");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }
        }

        public void AddBookToCategory(int adminId)
        {
            var api = new WebbshopAPI();

            Console.Write("" +
                "\nSök efter titel på boken som du vill lägga till: ");
            string keyword = Console.ReadLine();
            int bookId = api.GetBookId(keyword);

            api.GetCategories();
            Console.Write("Välj kategori (ID-nummer): ");
            int catId = Convert.ToInt32(Console.ReadLine());


            if (api.AddBookToCategory(adminId, bookId, catId) == true)
            {
                Console.WriteLine("" +
                    "\nNu ligger boken i kategorin");
            }
            
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }

        }

        public void UpdateBook(int adminId)
        {
            var api = new WebbshopAPI();

            Console.Write("" +
                "\nSök efter titel på boken som du vill ändra: ");
            string keyword = Console.ReadLine();
            int bookId = api.GetBookId(keyword);

            Console.WriteLine("Fyll i nya uppgifter:");
            Console.Write("Titel: ");
            string title = Console.ReadLine();
            Console.Write("Författare: ");
            string author = Console.ReadLine();
            Console.Write("Pris: ");
            int price = Convert.ToInt32(Console.ReadLine());

            if (api.UpdateBook(adminId, bookId, title, author, price) == true)
            {
                Console.WriteLine("" +
                    "\nBoken är uppdaterad");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }
        }

        public void UpdateBookAmount(int adminId)
        {
            var api = new WebbshopAPI();

            Console.Write("" +
                "\nSök efter titel på boken som du vill ändra: ");
            string keyword = Console.ReadLine();
            int bookId = api.GetBookId(keyword);
            
            Console.Write("Ange antal: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            if (api.SetAmount(adminId, bookId, amount) == true)
            {
                Console.WriteLine("" +
                    "\nNu är antal ändrat!");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }
        }

        public void UpdateCategory(int adminId)
        {
            var api = new WebbshopAPI();

            api.GetCategories();

            Console.Write("" +
                "\nVälj kategori som ska uppdateras (Id-nummer): ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ange nytt namn på kategori: ");
            string newCategory = Console.ReadLine();

            if (api.UpdateCategory(adminId, categoryId, newCategory) == true)
            {
                Console.WriteLine("" +
                    "\nNu är kategorin uppdaterad!");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, testa igen");
            }
        }

        public void DeleteBook(int adminId)
        {
            var api = new WebbshopAPI();

            Console.Write("" +
                "\nSök efter titel på boken som du vill ta bort: ");
            string title = Console.ReadLine();
            int bookId = api.GetBookId(title);
            
            api.GetBook(bookId);

            Console.WriteLine("" +
                "\nIs this the book you want to delete (y/n):");
            string userInput = Console.ReadLine();

            if (userInput == "y")
            {
                if (api.DeleteBook(adminId, bookId) == true)
                {
                    Console.WriteLine("" +
                        "\nBoken är borttagen");
                }
                else
                {
                    Console.WriteLine("" +
                        "\nNågot gick fel, boken ligger kvar i systemet, testa igen");
                }
            }

        }

        public void DeleteCategory(int adminId)
        {
            var api = new WebbshopAPI();

            Console.Write("" +
                "\nVälj kategori som ska tas bort (Id-nummer): ");
            api.GetCategories();
            int categoryId = Convert.ToInt32(Console.ReadLine());

            if (api.DeleteCategory(adminId, categoryId) == true)
            {
                Console.WriteLine("" +
                    "\nNu är kategorin borttagen");
            }
            else
            {
                Console.WriteLine("" +
                    "\nNågot gick fel, kategorin ligger kvar i systemet, testa igen");
            }
        }
    }
}
