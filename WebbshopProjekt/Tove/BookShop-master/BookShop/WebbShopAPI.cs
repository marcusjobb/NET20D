using BookShop.Controllers;
using BookShop.Data;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class WebbShopAPI
    {        
        /// <summary>
        /// Validates if user name + password is correct or not. If successful, session timer is set and access is given to buy books.
        /// </summary>
        /// <param name="userName">User name provided by user</param>
        /// <param name="password">Password provided by user</param>
        public int Login(string userName, string password)
        {
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == userName && u.Password == password && u.IsActive == true);
                if(user != null)
                {
                    user.LastLogin = DateTime.Now;
                    user.SessionTimer = DateTime.Now;
                    context.Users.Update(user);
                    context.SaveChanges();
                    Console.WriteLine($"Welcome {userName}!");
                    var pingResult = Ping(user.Id);
                    return user.Id;
                }
            }
            Console.WriteLine("Login failed, please review your input");
            return 0; // If user doesn't exist, 0 is returned
        }
        /// <summary>
        ///User gets logged out. Resets session timer.
        /// </summary>
        /// /// <param name="id">User Id</param>
        public bool Logout(int userId)
        {            
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.SessionTimer = DateTime.MinValue;
                    context.Users.Update(user);
                    context.SaveChanges();
                    Console.WriteLine("You're now logged out");
                    var pingResult = Ping(userId);
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// Lists all book categories.
        /// </summary>
        public List<BookCategory> GetCategories()
        {
            using (var context = new BookShopContext())
            {
                var bookCategories = context.BookCategories.ToList();
                if (bookCategories.Count==0)
                {
                    Console.WriteLine("No categories were found.");
                }
                return bookCategories;
            }                           
        }
        /// <summary>
        /// Lists categories matching a keyword.
        /// </summary>
        /// <param name="keyword">keyword provided by user</param>
        public List<BookCategory> GetCategories(string keyword)
        {
            using (var context = new BookShopContext())
            {
                var categoriesWithKeyword= context.BookCategories.Where(c => c.Name == keyword).ToList();
                if (categoriesWithKeyword.Count==0)
                {
                    Console.WriteLine($"No categories contain {keyword}.");
                }
                return categoriesWithKeyword;
            }
           
        }
        /// <summary>
        /// Lists all books in a specific category
        /// </summary>
        /// <param name="categoryId">Book category id</param>
        public List<Book> GetCategory(int categoryId) 
        {            
            using (var context = new BookShopContext())
            {
                var booksInCategory = context.Books.Where(c => c.CategoryId == categoryId).ToList();
                if (booksInCategory.Count==0)
                {
                    Console.WriteLine("No books were found. Try another category.");
                }
                return booksInCategory;              
            }
        }
        /// <summary>
        /// Lists books with stock matching a specific category
        /// </summary>
        /// <param name="categoryId"></param>
        public List<Book> GetAvailableBooks(int categoryId)
        {
            using (var context = new BookShopContext())
            {
                var availableBooksInCategory= context.Books.Where(c => c.CategoryId == categoryId && c.Amount > 0).ToList();
                if (availableBooksInCategory.Count==0)
                {
                    Console.WriteLine("No books are available in this category.");
                }
                return availableBooksInCategory;               
            }
        }
        /// <summary>
        /// Gets information about a specfic book
        /// </summary>
        /// <param name="bookId"></param>
        public List<Book> GetBook(int bookId)
        {
            using (var context = new BookShopContext())
            {
                var book = context.Books.Where(b => b.Id == bookId).ToList();
                if (book.Count==0)
                {
                    Console.WriteLine("Book could not be found. Are you sure the Id is correct?");
                }
                return book;
            }

        }
        /// <summary>
        /// Lists matching books with keyword as common denominator
        /// </summary>
        /// <param name="keyword">Word to unite different books</param>
        public List<Book> GetBooks(string keyword)
        {
            using (var context = new BookShopContext())
            {
                var booksWithKeyword= context.Books.Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword)).ToList();
                if (booksWithKeyword.Count==0)
                {
                    Console.WriteLine($"No books contain {keyword} in title or author field");
                }
                return booksWithKeyword;
            }
        }
        /// <summary>
        /// Lists matching books with author as common denominator
        /// </summary>
        /// <param name="keyword">Name of author</param>
        public List<Book> GetAuthors(string keyword)
        {
            using (var context = new BookShopContext())
            {
                var authorsWithKeyword= context.Books.Where(b => b.Author.Contains(keyword)).ToList();
                if (authorsWithKeyword.Count==0)
                {
                    Console.WriteLine($"No books were found written by {keyword}");
                }
                return authorsWithKeyword;
            }
        }
        /// <summary>
        /// Connects book to user with id as common denominator. Adds information to table "Sold Books".
        /// Thus user must be logged in, otherwise request will fail. 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public bool BuyBook(int userId, int bookId) 
        {
            using (var context = new BookShopContext())
            {
                var pingResult = Ping(userId);
                var user = context.Users.FirstOrDefault(u=>u.Id==userId);               
                var soldBook = context.Books.FirstOrDefault(b => b.Id == bookId);
                var bookStock = 0;
                if (soldBook==null)
                {
                    Console.WriteLine("This book could not be found. Sure Id is correct?");                    
                }
                else
                {
                    bookStock = soldBook.Amount;            
                }   
                if(user != null)
                {
                    var sessionTimerCheck = DateTime.Now - user.SessionTimer;               
                    var convertedTimerCheck = sessionTimerCheck.TotalMinutes;               
                    try
                    {
                        if (soldBook != null && soldBook.Amount >0 && convertedTimerCheck <15) // Book can be purchased if book is in stock & user hasn't been inactive for more than 15 min 
                        {
                            SoldBook newSoldBook = new SoldBook()
                            {
                                Title = soldBook.Title,
                                Author = soldBook.Author,
                                Price = soldBook.Price,
                                CategoryId = soldBook.CategoryId,
                                UserId = userId
                            };
                            context.SoldBooks.Add(newSoldBook);
                            soldBook.Amount = bookStock - 1; //Decreases stock in book table
                            context.SaveChanges();
                            user.SessionTimer = DateTime.Now;//Refreshes session timer
                            Console.WriteLine($"Congratulations, you just bought {soldBook.Title} - great choice!");
                            return true;
                        }
                            if (convertedTimerCheck >15)
                            {
                                Console.WriteLine("You've been inactive for too long. Please log in again to make the purchase.");
                            }
                        Console.WriteLine("This book is not available. Maybe you want to buy another book?");
                        return false;               
                        }
                    catch (Exception)
                    {
                        Console.WriteLine("Book could not be purchased. Sure Id exists?");
                        return false;
                    }
                }
                return false;
            }
            
        }

        /// <summary>
        /// Returns "Pong" if customer is online, string.empty if customer is offline.
        /// </summary>
        /// <param name="userId"></param>
        public string Ping(int userId)
        {
            using (BookShopContext context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u=>u.Id==userId);
                if(user != null)
                {
                    if (user.SessionTimer==DateTime.MinValue)
                    {
                        return string.Empty;
                    }
                    return "Pong";
                }
                return $"User isn't logged in";
            }
        }
        /// <summary>
        /// Adds user in table "Users" if user doesn't already exist and verified password is same as password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="passwordVerify"></param>
        /// <returns></returns>
        public bool Register(string userName, string password, string passwordVerify)
        {
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u=>u.Name == userName);

                if (user!=null)
                {
                    Console.WriteLine("User already exists. Please choose another user name");
                }
                else if (user == null && password != string.Empty && password == passwordVerify)
                {
                    user = new User
                    {
                        Name = userName,
                        Password = password
                    };
                    context.Users.Add(user);
                    context.SaveChanges();
                    Console.WriteLine($"Welcome {userName}, you're now registed as a user.");
                    return true;
                }
                if (password == string.Empty)
                {
                    Console.WriteLine("Password has to contain a value");
                }
                if (password!=passwordVerify)
                {
                    Console.WriteLine("Passwords don't match. Try again");
                }

                return false;
            }
        }
        //Below methods only concerns admin mode
        /// <summary>
        /// Checks  if user is admin or not.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public bool CheckIfAdmin(string userName, string password)
        {
            using (var context = new BookShopContext())
            {
              var userListCheck = context.Users.Where(u => u.Name == userName && u.Password == password && u.IsAdmin==true).ToList();
                if (userListCheck.Count <=0)
                {
                    Console.WriteLine("Sorry, you're not registered as admin");                   
                }
                else if (userListCheck.Count> 0)
                {
                   // AdminMode(userName, password); //Had to comment this out to make it work with the front end.
                    return true;
                }
                return false;
            }            
        }
        /// <summary>
        /// Checks if admin has been active for the last 15 minutes. If not, admin has to log in again to access admin functionality.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True if admin has been active for the last 15 minutes. Otherwhise false.</returns>
        public bool CheckAdminActivity(int id)
        {
            var pingResult = Ping(id);           
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id==id && u.IsAdmin == true);
                var sessionTimerCheck = DateTime.Now - user.SessionTimer;
                var convertedTimerCheck = sessionTimerCheck.TotalMinutes;                
                if (convertedTimerCheck < 15)
                {
                    user.SessionTimer = DateTime.Now;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return true;
                }
               
                Console.WriteLine("Please log in as admin again to access this.");                  
               
                return false;
            }
        }
        /// <summary>
        /// Menu only available for admin.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void AdminMode(string userName, string password)
        {
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Name == userName && u.Password == password);                
                var userInput = 0;
                while (userInput!=20)
                {
                    Console.WriteLine("**Admin mode** What do you want to do?");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. Stock correction");
                    Console.WriteLine("3. List all users");
                    Console.WriteLine("4. Search for a user");
                    Console.WriteLine("5. Update a book");
                    Console.WriteLine("6. Delete a book");
                    Console.WriteLine("7. Add book category");
                    Console.WriteLine("8. Add a book to a category");
                    Console.WriteLine("9. Update a book category");
                    Console.WriteLine("10. Delete a book category");
                    Console.WriteLine("11. Add a user");
                    Console.WriteLine("12. List all sold books");
                    Console.WriteLine("13.Show earnings from sold books");
                    Console.WriteLine("14. Show the customer that has bought most books");
                    Console.WriteLine("15. Promote a user");
                    Console.WriteLine("16. Demote a user");
                    Console.WriteLine("17. Activate a user");
                    Console.WriteLine("18. Inactivate a user");
                    Console.WriteLine("19. Go back to main menu");
                    Console.WriteLine("20. Exit");                    
                    try
                    {
                        userInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Make sure to enter a number between 1-20. No other symbols are allowed.");

                    }
                    switch (userInput)
                    {
                            case 1:
                                var adminCheck=CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                var enterStatus = false;
                                string title = null;
                                string author = null;
                                double price = 0;
                                int amount = 0;
                            while (enterStatus == false)
                            {
                                Console.Write("Enter book title:");
                                title = Console.ReadLine();
                                enterStatus=CheckInput(title);//Checks if input is empty or not to avoid an empty field in book title column
                            }
                            enterStatus = false;
                            while (enterStatus == false)
                            {
                                Console.Write("Enter author:");
                                author = Console.ReadLine();
                                enterStatus = CheckInput(author);//Checks if input is empty or not to avoid an empty field in book author column
                            }                          
                            Console.Write("Enter price:");                          
                            var tryPrice = double.TryParse(Console.ReadLine(), out var p);
                            if (tryPrice == true)
                            {
                                price = p; 
                            }
                            Console.Write("Enter amount:");
                            var tryAmount = int.TryParse(Console.ReadLine(), out var a);
                            if (tryAmount == true)
                            {
                                amount = a;
                            }
                            var successfulAddition = AddBook(user.Id, title, author, price, amount);                           
                                break;
                            case 2:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                var bookId = 0;
                                Console.Write("Enter book id for the book you want to do stock correction for:");
                                var tryId = int.TryParse(Console.ReadLine(), out var id);
                                if (tryId==true)
                                {
                                    bookId = id;
                                } 
                                if (bookId==0)
                                {
                                    Console.WriteLine("Book id is 0, please try again.");
                                    goto case 2;
                                }
                                SetAmount(user.Id, bookId);
                                break;
                            case 3:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                var userList=ListUsers(user.Id);
                                foreach (var u in userList)
                                {
                                    Console.WriteLine($"Name:{u.Name}  Password:{u.Password}  Last login:{u.LastLogin}  Session timer:{u.SessionTimer} Is active:{u.IsActive}  Is Admin:{u.IsAdmin}");
                                }
                                break;
                            case 4:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter keyword:");
                                var keyword = Console.ReadLine();
                                var foundUser = FindUser(user.Id, keyword);
                                    foreach (var fU in foundUser)
                                    {
                                        Console.WriteLine($"Name:{fU.Name}  Password:{fU.Password}  Last login:{fU.LastLogin}  Session timer:{fU.SessionTimer} Is active:{fU.IsActive}  Is Admin:{fU.IsAdmin}");
                                    }
                                break;
                            case 5:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter book id for the book you want to update:");
                                var tryBookId = int.TryParse(Console.ReadLine(), out bookId);
                                    if (bookId == 0)
                                    {
                                        Console.WriteLine("Book id is 0, please try again");
                                        goto case 5;
                                    }                            
                                Console.WriteLine("Fill in below lines with the updated information");
                                Console.Write("Enter book title:");
                                title = Console.ReadLine();
                                Console.Write("Enter book author:");
                                author = Console.ReadLine();
                                Console.Write("Enter book price:");                               
                                tryPrice = double.TryParse(Console.ReadLine(), out  price);
                                var successfulUpdate = UpdateBook(user.Id, bookId, title, author, price);
                                break;
                            case 6:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter book id for the book you want to delete:");
                                tryBookId = int.TryParse(Console.ReadLine(), out bookId);
                                    if (bookId == 0)
                                    {
                                        Console.WriteLine("Book id is 0, please try again");
                                        goto case 6;
                                    }
                            var successfulDeletion = DeleteBook(user.Id, bookId);
                                break;
                            case 7:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter name of the new category:");
                                var categoryName = Console.ReadLine();
                                AddCategory(user.Id, categoryName);
                                break;
                            case 8:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter book id for the book you want to specify category for:");
                                tryBookId = int.TryParse(Console.ReadLine(), out bookId);
                                if (bookId == 0)
                                {
                                    Console.WriteLine("Book id is 0, please try again");
                                    goto case 8;
                                }
                                var tryCategoryId = false;
                                while (tryCategoryId == false)
                                {
                                    Console.Write("Enter category id:");
                                    tryCategoryId = int.TryParse(Console.ReadLine(), out var enteredCategoryId);
                                    if (enteredCategoryId == 0)
                                    {
                                        Console.WriteLine("Book id is 0, please try again");                                    
                                    }
                                    AddBookToCategory(user.Id, bookId, enteredCategoryId);
                                }                                
                                break;
                            case 9:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter category id for the category you want to update:");
                                tryCategoryId = int.TryParse(Console.ReadLine(), out var categoryId);
                                    if (categoryId == 0)
                                    {
                                        Console.WriteLine("Book id is 0, please try again");
                                        goto case 9;
                                    }
                                Console.Write("Enter updated category name:");
                                categoryName = Console.ReadLine();
                                successfulUpdate=UpdateCategory(user.Id, categoryId, categoryName);
                                break;
                            case 10:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter category id for the category you want to delete:");
                                tryCategoryId = int.TryParse(Console.ReadLine(), out var idToDelete);
                                    if (idToDelete == 0)
                                    {
                                        Console.WriteLine("Book id is 0, please try again");
                                        goto case 9;
                                    }
                                var succesfulDeletion=DeleteCategory(user.Id, idToDelete);
                                break;
                            case 11:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.Write("Enter user name for new user:");
                                userName = Console.ReadLine();
                                Console.Write("Enter password for new user:");
                                password = Console.ReadLine();
                                var additionSuccess=AddUser(user.Id, userName, password);
                                break;
                            case 12:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                var soldBooks=SoldItems(user.Id);
                                    foreach (var sB in soldBooks)
                                    {
                                        Console.WriteLine($"ID:{sB.Id}  Name:{sB.Title}  Author:{sB.Author}  Price:{sB.Price} Purchased Date:{sB.PurchasedDate} Category Id:{sB.UserId}  ");
                                    }                       
                                break;
                            case 13:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                var earnings= MoneyEarned(user.Id);
                                Console.WriteLine($"Total earnings as per {DateTime.Now.ToShortDateString()}: {earnings}");
                                break;
                            case 14:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                var bestCustomerId=BestCustomer(user.Id);
                                Console.WriteLine($"Id of best customer: {bestCustomerId}");                    
                                break;
                            case 15:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.WriteLine("Enter Id of the user that you want to promote:");
                                var tryIdToPromote = int.TryParse(Console.ReadLine(), out var idToPromote);
                                if (idToPromote == 0)
                                {
                                    Console.WriteLine("Book id is 0, please try again");
                                    goto case 15;
                                }
                                Promote(user.Id, idToPromote);                  
                                break;
                            case 16:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.WriteLine("Enter Id of the user that you want to demote:");
                                var tryIdToDemote = int.TryParse(Console.ReadLine(), out var idToDemote);
                                if (idToDemote == 0)
                                {
                                    Console.WriteLine("Book id is 0, please try again");
                                    goto case 16;
                                }
                                Demote(user.Id, idToDemote);
                                break;
                            case 17:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.WriteLine("Enter Id of the user that you want to activate:");
                                var tryIdToActivate = int.TryParse(Console.ReadLine(), out var idToActivate);
                                if (idToActivate == 0)
                                {
                                    Console.WriteLine("Book id is 0, please try again");
                                    goto case 17;
                                }
                                ActivateUser(user.Id, idToActivate);
                                break;
                            case 18:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                Console.WriteLine("Enter Id of the user that you want to inactivate:");
                                var tryIdToInactivate = int.TryParse(Console.ReadLine(), out var idToInactivate);
                                if (idToInactivate == 0)
                                {
                                    Console.WriteLine("Book id is 0, please try again");
                                    goto case 18;
                                }
                            InactivateUser(user.Id, idToInactivate);
                                    break;
                                case 19:
                                adminCheck = CheckAdminActivity(user.Id);
                                MenuPresenter(adminCheck);
                                RunProgram menuRunner = new RunProgram();
                                menuRunner.Menu();                               
                                break;
                            case 20:
                                System.Environment.Exit(0);
                                break;

                            default:
                                    Console.WriteLine("Request could not be fulfilled. Please try again.");                          
                                break;
                    }                  
                }
            }           
        }
        /// <summary>
        /// Adds book to table "Books" if book doesn't already exist. Otherwhise book amount will increase instead.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool AddBook(int adminId, string title, string author, double price, int amount )
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Title == title && b.Author== author);
                    if(book==null)
                    {
                        Book newBook = new Book()
                        {
                            Title = title,
                            Author = author,
                            Price = price,
                            Amount = amount
                        };
                        context.Books.Add(newBook);
                        context.SaveChanges();
                        Console.WriteLine("Book was sucessfully added");
                    }
                    else if (book!=null)
                    {
                        book.Amount = book.Amount + amount;
                        context.Books.Update(book);
                        context.SaveChanges();
                        Console.WriteLine("Book already exists. Amount was increased.");
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Book couldn't be added, please review your input.");
                return false;
            }            
        }
        /// <summary>
        /// Executes stock correction for an already existing book.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        public int SetAmount(int adminId, int bookId) 
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    Console.Write("Enter amount of available books:");
                    var tryAmount = int.TryParse(Console.ReadLine(), out var amount);                   
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    try
                    {
                    if (book != null)
                    {
                        book.Amount = amount;
                        context.Update(book);
                        context.SaveChanges();
                        Console.WriteLine($"Stock was corrected to {amount}");
                            return book.Amount;
                    }
                    }                   
                    catch (Exception)
                    {
                        Console.WriteLine("Stock correction failed, please review your input.");
                    }                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Stock correction failed, please review your input.");
            }
            return 0;
        }
        public int SetAmount(int adminId, int bookId, int amount) // Added, needed for fron end
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {                   
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    try
                    {
                        if (book != null)
                        {
                            book.Amount = amount;
                            context.Update(book);
                            context.SaveChanges();
                            Console.WriteLine($"Stock was corrected to {amount}");
                            return book.Amount;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Stock correction failed, please review your input.");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Stock correction failed, please review your input.");
            }
            return 0;
        }
        /// <summary>
        /// Lists all users that exists in table "Users".
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public List<User> ListUsers(int adminId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var userList = context.Users.ToList();
                if (userList.Count == 0)
                {
                    Console.WriteLine("No users exist.");
                }
                return userList.OrderBy(u => u.Name).ToList();
            }
        }
        /// <summary>
        /// Finds one or many users containing a specific keyword in table "Users".
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<User> FindUser(int adminId, string keyword)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var userList = context.Users.Where(u => u.Name.Contains(keyword)).ToList();
                if (userList.Count == 0)
                {
                    Console.WriteLine("No user contains this keyword");
                }
                return userList;
            }
        }
        /// <summary>
        /// Finds a specific user using user id. Needed to pass on information to front end. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>user object</returns>
        public User FindUser(int adminId, int userId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    Console.WriteLine("No user contains this keyword");
                }
                return user;
            }
        }
        /// <summary>
        /// Updates an already existing book in table "Books".
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, double price)
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    context.Update(book);
                    context.SaveChanges();
                    Console.WriteLine("Book was sucessfully updated");
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Update failed, please review your input.");
                return false;
            }           
        }
        /// <summary>
        /// Deletes a book from table "Books" if amount is <1 after this deletion. Otherwhise book amount will decrease with 1 instead.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool DeleteBook(int adminId, int bookId) 
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);   
                    if (book !=null && book.Amount > 1)
                    {
                        book.Amount = book.Amount - 1;
                        context.Update(book);
                        context.SaveChanges();
                        Console.WriteLine("Book amount was decreased with 1.");
                        return true;
                    }
                  
                    context.Remove(book);
                    context.SaveChanges();
                    Console.WriteLine("Stock count after this removal is zero, thus book was removed.");
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Book couldn't be deleted, please review your input.");
                return false;
            }
        }
        /// <summary>
        /// Adds a category to table "Categories". 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public bool AddCategory(int adminId, string categoryName)
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var category = context.BookCategories.FirstOrDefault(c => c.Name == categoryName);
                    if (category == null)
                    {
                        category = new BookCategory()
                        {
                            Name = categoryName
                        };
                        context.Add(category);
                        context.SaveChanges();
                        Console.WriteLine("Category was sucessfully added");
                        return true;
                    }
                    else if(category != null)
                    {
                        Console.WriteLine("Category already exists");
                    }
                        return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Category couldn't be added, please review your input.");
                return false;
            }
        }
        /// <summary>
        /// Adds a category id to the column "CategoryId" in table "Books".
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="bookId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == bookId);
                    if (book != null)
                    {
                        book.CategoryId = categoryId;
                        context.Update(book);
                        context.SaveChanges();
                        Console.WriteLine("Category was sucessfully added to book");
                        return true;
                    }
                    else if (book == null)
                    {
                        Console.WriteLine("Book not found, please review your input.");
                    }
                        return false;                                                  
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Book couldn't be connected to category, please review your input.");
                return false;
            }
        }
        /// <summary>
        /// Updates an already existing category with given input.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public bool UpdateCategory(int adminId, int categoryId, string categoryName)
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var category = context.BookCategories.FirstOrDefault(c => c.Id == categoryId);
                    category.Name = categoryName;
                    context.Update(category);
                    context.SaveChanges();
                    Console.WriteLine("Category name was sucessfully changed");
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Category couldn't be updated, please review your input.");
                return false;
            }
        }
        /// <summary>
        /// Deletes a category from table "Categories".
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            var pingResult = Ping(adminId);
            try
            {
                using (var context = new BookShopContext())
                {
                    var category = context.BookCategories.FirstOrDefault(b => b.Id == categoryId);
                    foreach (var book in context.Books)
                    {
                        if (book.CategoryId == categoryId)
                        {
                            Console.WriteLine("One or more books belong to this category. These have to be removed first.");
                            return false;
                        }
                    }
                    context.Remove(category);
                    context.SaveChanges();
                    Console.WriteLine("Category was sucessfully removed");
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Category couldn't be added, please review your input.");
                return false;
            }
        }
        /// <summary>
        /// Adds a user in table "Users". Password verification isn't applied here since this is available for admin only.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool AddUser(int adminId, string userName, string password)
        {
            var pingResult = Ping(adminId);            
            try
            {
                using (var context = new BookShopContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Name == userName);

                    if (user!=null)
                    {
                        Console.WriteLine("User already exists. Please choose another user name");
                        return false;
                    }

                    User newUser = new User()
                    {
                        Name = userName,
                        Password = password
                    };
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    Console.WriteLine("User was sucessfully added");
                    return true;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("User couldn't be added, please review your input.");
                return false;
            }
        }
        /// <summary>
        ///Lists all items in table "Sold Books".
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>List with all sold items</returns>
        public List<SoldBook> SoldItems(int adminId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var soldItemsList = context.SoldBooks.ToList();
                if (soldItemsList.Count==0)
                {
                    Console.WriteLine("No books have been sold yet");
                }
                return soldItemsList;                               
            }                
        }
        /// <summary>
        /// Presents money earned from sold books.  
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>SUm of all rows in column "Price" from table "Sold Books".  </returns>
        public double MoneyEarned(int adminId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var earnings = context.SoldBooks.Sum(b=>b.Price);
                return earnings;
            }
        }
        /// <summary>
        /// Presents the customer that has bought the most books.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>The most occurring Id in column "UserId"</returns>
        public int BestCustomer(int adminId)
        {
            using (var context = new BookShopContext())
            {
                var bestCustomer=0;
                var list = context.SoldBooks.ToList();
                if (list.Count==0)
                {
                    Console.WriteLine("No user to present. No customers seem to exist.");
                }
                else
                {
                    bestCustomer = list.GroupBy(i => i.UserId).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
                }
                return bestCustomer;
            }            
        }
        /// <summary>
        /// Promotes a user by setting value to true in column "IsAdmin" in table "Users".  
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if promotion was successful, otherwhise false.</returns>
        public bool Promote(int adminId, int userId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsAdmin = true;
                    context.Update(user);
                    context.SaveChanges();
                    Console.WriteLine("User was successfully promoted.");
                    return true;
                }
                Console.WriteLine("User couldn't be promoted. Please try again");                
                return false;
            }                      
        }
        /// <summary>
        /// Demotes a user by setting value to false in column "IsAdmin" in table "Users". 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if demotion was successful, otherwhise false.</returns>
        public bool Demote(int adminId, int userId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsAdmin = false;
                    context.Update(user);
                    context.SaveChanges();
                    Console.WriteLine("User was successfully demoted.");
                    return true;
                }            
                Console.WriteLine("User couldn't be demoted. Please try again");               
                return false;
            }
        }
        /// <summary>
        /// Activates a user by setting value to true in column "IsActive" in table "Users". 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if activation was successful, otherwhise false.</returns>
        public bool ActivateUser(int adminId, int userId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);               
                    if (user != null)
                    {
                        user.IsActive = true;
                        context.Update(user);
                        context.SaveChanges();
                        Console.WriteLine("User was successfully activated.");
                        return true;
                    }                              
                Console.WriteLine("User couldn't be activated. Please review your input");                                   
                return false;
            }
        }
        /// <summary>
        /// Inactivates a user by setting value to false in column "IsActive" in table "Users". 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="userId"></param>
        /// <returns>True if inactivation was successful, otherwhise false.</returns>
        public bool InactivateUser(int adminId, int userId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {                
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsActive = false;
                    context.Update(user);
                    context.SaveChanges();
                    Console.WriteLine("User was successfully inactivated.");
                    return true;
                }                
                Console.WriteLine("User couldn't be inactivated. Please review your input");               
                return false;
            }
        }
        /// <summary>
        /// Presents menu to user if admin check is false. Otherwhise nothing happens.  
        /// </summary>
        /// <param name="adminCheck"></param>
        public void MenuPresenter(bool adminCheck)
        {
            if (adminCheck == false)
            {
                RunProgram runner = new RunProgram();
                runner.Menu();
            }
        }
        /// <summary>
        /// Checks whether a string is empty or not.
        /// </summary>
        /// <param name="stringToCheck"></param>
        /// <returns></returns>
        public bool CheckInput(string stringToCheck)
        {
            if (stringToCheck==string.Empty)
            {
                Console.WriteLine("A value has to be inserted. Try again.");
                return false;
            }
            return true;
        }

        public List<Book> GetBookList(int adminId)
        {
            var pingResult = Ping(adminId);
            using (var context = new BookShopContext())
            {
                var bookList = context.Books.ToList();
                if (bookList.Count == 0)
                {
                    Console.WriteLine("No users exist.");
                }
                return bookList.OrderBy(u => u.Title).ToList();
            }
        }
     /// <summary>
     /// Finds a specific book category. Function required in front end. 
     /// </summary>
     /// <param name="name"></param>
     /// <returns>Book Category object</returns>
        public BookCategory FindCategory(int id)
        {
            using (var context = new BookShopContext())
            {
                BookCategory category = context.BookCategories.FirstOrDefault(c=>c.Id == id);
                if(category != null)
                {
                return category;
                }
            }
            return null;
        }
    }
}
