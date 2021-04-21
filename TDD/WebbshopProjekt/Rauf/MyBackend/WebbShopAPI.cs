using System;
using System.Collections.Generic;
using System.Linq;
using MyBackend.Database;
using MyBackend.Models;

namespace MyBackend
{
    public class WebbShopAPI
    {
        public static bool status = false; // true om användaren är inloggad.
        public static User user; // används för att ha en inloggad användare genom hela programmet
        public static MyContext context = new MyContext(); // context anropas i alla metoder som behöver kopplas till databasen

        /// <summary>
        /// Inloggningsmetod
        /// </summary>
        /// <returns>UserID</returns>
        public static int Login(string username, string password)
        {
            user = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);

            if (user != null)
            {
                status = true;
                user.LastLogin = DateTime.Now;
                user.SessionTime = DateTime.Now;
                context.Users.Update(user);
                context.SaveChanges();
                return user.Id;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Utloggningsmetod
        /// </summary>
        /// <param name="id"></param>
        public static void Logout(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id && u.SessionTime > DateTime.Now.AddMinutes(-15));

            if (user != null)
            {
                user.SessionTime = DateTime.MinValue;
                context.Users.Update(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deklarera med en variabel för att få en lista med alla kategorier
        /// </summary>
        /// <returns>List of categories</returns>
        public static List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        /// <summary>
        /// Visar alla böcker under samma kategori
        /// </summary>
        /// <returns>List of books</returns>
        public static IEnumerable<Book> ShowBooksByCategory(int catId) 
        {
            var result = new List<Book>();
            result = context.Books.Where(b => b.CategoryId == catId).ToList();
            if (result != null)
            {
                return result;
            }
            else 
            {
                result.Add(new Book {Title ="-", CategoryId= 0 , Amount= 0, Price = 0, Author="-" });
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        public static IEnumerable<Book> ShowAvailableBooksByCategory(int catId)
        {
            var result = new List<Book>();
            result = context.Books.Where(b => b.CategoryId == catId && b.Amount >0).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                result.Add(new Book { Title = "-", CategoryId = 0, Amount = 0, Price = 0, Author = "-" });
                return result;
            }
        }

        /// <summary>
        /// Söker bland kategorier
        /// </summary>
        /// <returns>List of category</returns>
        public static IEnumerable<Category> SearchCategory(string keyword)
        {
            List<Category> result = new List<Category>();
            result = context.Categories.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name).ToList();
            if (result != null)
            {
                return result;
            }
            else
            {
                result.Add(new Category {Id = 0, Name = "-" });
                return result;
            }
        }

        /// <summary>
        /// Ska deklareras för att få en lista av befintliga böcker
        /// </summary>
        /// <returns>List of books</returns>
        public static List<Book> GetAvailableBooks()
        {
            return context.Books.Where(b => b.Amount > 0).ToList();
        }

        /// <summary>
        /// Ska deklareras för att få en lista med alla böcker i databasen
        /// </summary>
        /// <returns>List of books</returns>
        public static List<Book> GetAllBooks()
        {
            return context.Books.ToList();
        }

        /// <summary>
        /// Metod som skapar en ny användare. OBS! Admin kan skapas bara av en annan admin.
        /// </summary>
        public static bool Register(string username, string password, string checkPassword)
        {
            var user = context.Users.FirstOrDefault(u=>u.Name == username);
            if (user.Id > 0)
            {
                if (password == checkPassword)
                {
                    context.Users.Add(new Models.User { Name = $"{username}", Password = $"{password}", LastLogin = DateTime.Now, SessionTime = DateTime.Now, IsActive = true, IsAdmin = false });
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            } return false;


        }

        /// <summary>
        /// Metod som skriver ut information om en bok. Sökningen använder sig av bok ID.
        /// </summary>
        public static Book GetBookById(int bookId)
        {
            var book = context.Books.FirstOrDefault(b=>b.Id == bookId);
            if (book.Id > 0)
            {
                return book;
            }
            else
            {
                book = new Book { Title = "-", CategoryId = 0, Amount = 0, Price = 0, Author = "-" };
                return book;
            }
        }

        /// <summary>
        /// Metod skapar en lista med böcker som innehåller sökordet
        /// </summary>
        /// <returns>List of books</returns>
        public static List<Book> FindBookByName(string bookName)
        {
            var cat = GetCategories().ToList();
            var result = context.Books.Where(b => b.Title.Contains(bookName)).OrderBy(c => c.Title).ToList();
            if (result.Count > 0)
            {
                return result;
            }
            else
            {
                result.Add(new Book { Title = "-", CategoryId = 0, Amount = 0, Price = 0, Author = "-" });
                return result;
            }
        }

        /// <summary>
        /// Metoden skapar en lista med böcker som innehåller sökordet som söker bland författarna 
        /// </summary>
        /// <returns>lsit of books</returns>
        public static List<Book> GetAuthors(string autName)
        {
           
            var result = context.Books.Where(b => b.Author.Contains(autName)).OrderBy(c => c.Title).ToList();

            if (result.Count > 0)
            {
                return result;
            }
            else
            {
                result.Add(new Book { Title = "-", CategoryId = 0, Amount = 0, Price = 0, Author = "-" });
                return result;
            }
        }

        /// <summary>
        /// Metoden listar alla tillgängliga böcker och utför minskning av antalet böcker i databasen 
        /// </summary>
        public static bool BuyABook(int userId, int bookId)
        {
            user = context.Users.FirstOrDefault(u=>u.Id == userId);

            if (user.SessionTime.Minute < 15)
            {
                var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                AddSoldBook(book);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        public static void AddSoldBook (Book book)
        {
            context.SoldBooks.Add(new Models.SoldBook
            {
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Price = book.Price,
                PurchasedDate = DateTime.Now,
                UserId = user.Id
            });
            book.Amount -= 1;
            context.SaveChanges();
        }

        //***************************************** Admin *********************************************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        public static void AddBook(int adminId, string title, string author, int price, int amount)
        {

            if (CheckBook(title, author))
            {
                var book = context.Books.FirstOrDefault(b => b.Title == title && b.Author == author);
                SetAmount(book.Id, adminId, amount);
            }else 

            context.Books.Add(new Models.Book { Title = title, Author = author, Price = price, Amount = amount});
            context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public static bool CheckBook(string titel, string author)
        {
            var search = context.Books.Where(b => b.Author.Contains(author) && b.Title.Contains(titel)).ToList();
            if (search.Count != 0)
            {
                return true;
            }else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="adminId"></param>
        /// <param name="addAmount"></param>
        public static void SetAmount(int bookId, int adminId, int addAmount)
        {
            user = context.Users.FirstOrDefault(u=>u.Id==adminId);
            if (user.IsAdmin)
            {
                var book = GetBookById(bookId);
                book.Amount += addAmount;
                context.SaveChanges();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static List<User> ListUsers(int adminId)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id == adminId);
            var users = context.Users.ToList();
            if (user.IsAdmin)
            {
                return users;
            }
            else
            {
                users.Add(new User { Name = "-", Password = "-"});
                return users;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<User> FindUser(int adminId, string keyword)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id == adminId);
            var result = context.Users.Where(u => u.Name.Contains(keyword)).OrderBy(c => c.Id).ToList();
            if (user.IsAdmin)
            {
                return result;
            }
            else
            {
                result.Add(new User { Name = "-", Password = "-" });
                return result;
            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            var book = context.Books.FirstOrDefault(b=>b.Id == bookId);
            var user = context.Users.FirstOrDefault(u=>u.Id == adminId);
            if (user.IsAdmin && book.Id > 0)
            {
                book.Title = title;
                book.Author = author;
                book.Price = price;
                context.SaveChanges();
                return true;
            }
            else return false;
        }
         
        /// <summary>
        /// Minskar book.Amount, om det blir 0 raderar boken
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public static bool DeleteBook(int adminId, int bookId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b => b.Id == bookId);
            if (user.IsAdmin && book != null)
            {
                if (book.Amount > 0)
                {
                    book.Amount -= 1;
                    context.SaveChanges();
                } else
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool AddCategory(int adminId, string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                context.Categories.Add(new Models.Category { Name = name });
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            var book = context.Books.FirstOrDefault(b=>b.Id == bookId);
            if (user.IsAdmin)
            {
                book.CategoryId = categoryId;
                context.SaveChanges();
                return true;
            }
            else return false;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id == adminId);
            if (user.IsAdmin)
            {
                var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                category.Name = name;
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static bool DeleteCategory(int adminId, int categoryId)
        {
            var user = context.Users.FirstOrDefault(u=> u.Id == adminId);
            var category = context.Categories.FirstOrDefault(c=>c.Id==categoryId);
            var books = context.Books.Where(b=>b.CategoryId == categoryId);
            if (user.IsAdmin && books == null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool AddUser(int adminId, string name, string password)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id==adminId);
            var names = context.Users.Where(u => u.Name.Contains(name)).ToList();

            if (user.IsAdmin && names.Count == 0 && password != null)
            {
                context.Users.Add(new User { Name = name, Password = password, IsActive = true, IsAdmin = false }); ;
                context.SaveChanges();
                return true;
            }
            else return false;
        }

        //******************************************** VG funktioner *****************************************//

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public static List<SoldBook> SoldItems(int adminId)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id == adminId);
            var books = new List<SoldBook>();
            if (user.IsAdmin)
            {
                books = context.SoldBooks.OrderBy(b => b.Title).ToList();
                return books;
            }
            else
            {
                books.Add(new SoldBook { Title = "", Author =""});
                return books;
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="adminId"></param>
       /// <param name="userId"></param>
       /// <returns></returns>
        public static bool ActivateUser(int adminId, int userId)
        {
            var user = context.Users.FirstOrDefault(u=>u.Id == adminId);
            if (user.IsAdmin)
            {
                user = context.Users.FirstOrDefault(u => u.Id == userId);
                user.IsActive = true;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool InactivateUser(int adminId, int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                user = context.Users.FirstOrDefault(u => u.Id == userId);
                user.IsActive = false;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool Promote(int adminId, int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                user = context.Users.FirstOrDefault(u => u.Id == userId);
                user.IsAdmin = true;
                context.SaveChanges();
                return true;
            }
            else return false;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool Demote(int adminId, int userId)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == adminId);
            if (user.IsAdmin)
            {
                user = context.Users.FirstOrDefault(u => u.Id == userId);
                user.IsAdmin = false;
                context.SaveChanges();
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Metoden öppnar upp en meny med val av vilka parametrar ska ändras av en angiven användare.
        /// </summary>
        public static void ChangeUser()
        {
            string ans = "";
            Console.Write("Välj användare du vill redigera (ID): ");
            int uId = Convert.ToInt32(Console.ReadLine());
            var user = context.Users.FirstOrDefault(u => u.Id == uId);
            if (user != null)
            {
                do
                {
                    Console.WriteLine("====================================");
                    Console.WriteLine($"1. Username: {user.Name}");
                    Console.WriteLine($"2. Password: {user.Password}");
                    Console.WriteLine($"3. Admin: {user.IsAdmin.ToString()}");
                    Console.WriteLine($"4. Active: {user.IsActive.ToString()}");
                    Console.WriteLine($"q. Gå till huvudmenyn");
                    Console.WriteLine("====================================");
                    Console.Write("Vad vill du ändra på:");
                    ans = Console.ReadLine();
                    switch (ans)
                    {
                        case "1":
                            {
                                Console.Write("Nytt användarnamn: ");
                                user.Name = Console.ReadLine();
                                context.SaveChanges();
                                break;
                            }
                        case "2":
                            {
                                Console.Write("Nytt lösenord: ");
                                user.Password = Console.ReadLine();
                                context.SaveChanges();
                                break;
                            }
                        case "3":
                            {
                                Console.Write("Ändra adminstatus (true/false): ");
                                user.IsAdmin = Convert.ToBoolean(Console.ReadLine());
                                context.SaveChanges();
                                break;
                            }
                        case "4":
                            {
                                Console.Write("Ändra aktivitetsstatus (true/false): ");
                                user.IsActive = Convert.ToBoolean(Console.ReadLine());
                                context.SaveChanges();
                                break;
                            }
                        case "q":
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Fel val i menyn. Var vänlig försök igen.");
                                break;
                            }
                    }

                } while (ans != "q");
            }

        }
    }
}