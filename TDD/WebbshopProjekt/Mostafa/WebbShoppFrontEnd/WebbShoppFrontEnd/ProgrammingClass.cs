using System;
using System.Collections.Generic;
using System.Text;
using WebbShop;
namespace WebbShoppFrontEnd
{
    public class ProgrammingClass
    {
        
        WebbShopApi api = new WebbShopApi();

       
        public void LogIn()
        {
            string username, password;
            Console.WriteLine("Enter your name");
            username = Console.ReadLine();
            Console.WriteLine("Enter your password");
            password = Console.ReadLine();

            var _login = api.Login(username, password);
            Console.WriteLine(_login);
            Console.ReadLine();
        }

        public void LogOut()
        {
            Console.WriteLine("Enter your ID");
            int userid = int.Parse(Console.ReadLine());
            api.LogOut(userid);
        }

        public void GetCategories()
        {
            Console.WriteLine("1. List all categories");
            Console.WriteLine("2. List all categories by keyword");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                var getcategories = api.GetCategories();
                foreach (var item in getcategories)
                {
                    Console.WriteLine($"ID: {item.ID} | Name: {item.Name}");
                }
            }

            else if (choice == "2")
            {
               
                    Console.WriteLine("Enter name of category");
                    string category = Console.ReadLine();
                    var getcategories = api.GetCategories(category);

                    foreach (var item in getcategories)
                    {
                        Console.WriteLine($"ID: {item.ID} | Name: {item.Name}");
                    }
                
               
            }
        }

        public void GetCategory()
        {
            
                Console.WriteLine("Enter a id");
                int id = int.Parse(Console.ReadLine());
                
                foreach (var item in api.GetCategory(id))
                {
                    Console.WriteLine($"ID: {item.ID} | Title: {item.Title} | Author: {item.Author} | Price: {item.Price}:- | Amount: {item.Ammount}");
                }
            

           
        }

        public void GetAvailableBooks()
        {
            
                Console.WriteLine("Enter a categoryID");
                int ID = int.Parse(Console.ReadLine());
                foreach (var item in api.GetAvailableBooks(ID))
                {
                    Console.WriteLine($"ID: {item.ID} | Title: {item.Title} | Author: {item.Author} | Price: {item.Price}:- | Amount: {item.Ammount}");
                }


            
           

        }

        public void GetBook()
        {
            
                Console.WriteLine("Enter the  bookID");
                int bookid = int.Parse(Console.ReadLine());
                Console.WriteLine(api.GetBook(bookid));
            
           
        }

        public void GetBooks()
        {
            
                Console.WriteLine("Enter a title of the book");
                int price = int.Parse(Console.ReadLine());
                foreach (var item in api.GetBooks(price))
                {
                    Console.WriteLine($"Title: {item.Title} | Author: {item.Author} | Price: {item.Price}:- | Amount: {item.Ammount}");
                }
            

          
        }

        public void GetAuthors()
        {
            
                Console.WriteLine("Select author");
                string author = Console.ReadLine();
                foreach (var item in api.GetAuthors(author))
                {
                    Console.WriteLine($"ID: {item.ID} | Title: {item.Title} | Author: {item.Author} | Price: {item.Price}:- | Amount: {item.Ammount}");
                }

            

            
                
        }

        public void BuyBook()
        {
            int userid, bookid;
            Console.WriteLine("Enter your ID");
            userid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select the bookID");
            bookid = int.Parse(Console.ReadLine());

            Console.WriteLine(api.BuyBook(userid, bookid));
        }

        public void Ping()
        {
            Console.WriteLine("Enter your ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(api.Ping(id));
            
        }

        public void Register()
        {
            Console.WriteLine("Select username");
            string username = Console.ReadLine();
            Console.WriteLine("Select password");
            string password = Console.ReadLine();
            Console.WriteLine("Verify your password");
            string verify = Console.ReadLine();
            Console.WriteLine(api.Register(username, password,verify));

        }

        public void AddBook()
        {
            Console.WriteLine("Enter your adminID");
            int adminid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select title");
            string title = Console.ReadLine();
            Console.WriteLine("Select author");
            string author = Console.ReadLine();
            Console.WriteLine("Select price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Select amount");
            int amount = int.Parse(Console.ReadLine());
            Console.WriteLine(api.AddBook(adminid, title, author, price, amount));

        }

        public void SetAmount()
        {
            Console.WriteLine("Enter your adminID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the bookID");
            int bookid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select amount");
            int amount = int.Parse(Console.ReadLine());
            api.SetAmount(id, bookid, amount);
            
        }

        public void ListOfUsers()
        {
            Console.WriteLine("Enter yor adminID");
            int adminid = int.Parse(Console.ReadLine());
            foreach (var item in api.ListUsers(adminid))
            {
                Console.WriteLine($"ID: {item.ID} | Name: {item.Name} | Password: {item.Password} | Laslogin: {item.Lastlogin} |" +
                    $" SessionTimer: {item.SessionTimer} | IsActive: {item.IsActive} | IsAdmin: {item.IsAdmin}");
            }
        }

        public void FindUser()
        {
            Console.WriteLine("Enter your adminID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Select name");
            string User = Console.ReadLine();
            foreach (var item in api.FindUser(id, User))
            {
                Console.WriteLine($"ID: {item.ID} | Name: {item.Name} | Password: {item.Password} | Laslogin: {item.Lastlogin} |" +
                $" SessionTimer: {item.SessionTimer} | IsActive: {item.IsActive} | IsAdmin: {item.IsAdmin}");
            }

        }

        public void UpdateBook()
        {
            Console.WriteLine("Enter your adminID");
            int adminid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select the bookID");
            int bookid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select title");
            string title = Console.ReadLine();
            Console.WriteLine("Select author");
            string author = Console.ReadLine();
            Console.WriteLine("Select price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine(api.UpdateBook(adminid, bookid, title, author, price));
        }

        public void DeleteBook()
        {
            Console.WriteLine("Enter your adminID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Select bookID");
            int bookid = int.Parse(Console.ReadLine());
            Console.WriteLine(api.DeleteBook(id, bookid));
        }

        public void AddCategory()
        {
            Console.WriteLine("Enter your adminID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Select name");
            string name = Console.ReadLine();
            Console.WriteLine(api.AddCategory(id, name));
           

        }

        public void AddBookToCategory()
        {
            Console.WriteLine("Enter your adminID");
            int adminid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter bookID");
            int BookID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter categoryID");
            int categoryID = int.Parse(Console.ReadLine());
            Console.WriteLine(api.AddBookToCategory(adminid, BookID, categoryID));
        }

        public void UpdateCategory()
        {
            Console.WriteLine("Enter your adminID");
            int adminid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter categoryID");
            int categoryid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select categoryname");
            string categoryname = Console.ReadLine();

            Console.WriteLine(api.UpdateCategory(adminid, categoryid, categoryname));

        }

        public void DeleteCategory()
        {
            Console.WriteLine("Enter your adminID");
            int adminid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter categoryID");
            int categoryid = int.Parse(Console.ReadLine());
            Console.WriteLine(api.DeleteCategory(adminid, categoryid));
        }

        public void AddUser()
        {
            Console.WriteLine("Enter your adminID");
            int adminid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select name");
            string name = Console.ReadLine();
            Console.WriteLine("Select password");
            string password = Console.ReadLine();
            Console.WriteLine(api.AddUser(adminid,name, password));

        }
    }
}
