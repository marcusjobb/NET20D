using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopAPI.Controllers;
using WebbShopAPI.Models;

namespace WebbShopAPI
{
    /// <summary>
    /// Access and control users, books and categories. Get statistics for sold books.
    /// </summary>
    public class WebbShopApi
    {
        /// <summary>
        /// Create test subjects for books, categories, users, admins and sold books.
        /// </summary>
        /// <returns></returns>
        public string InitializeDefaults()
        {
            try
            {
                var db = new Database.WebbShopAPIContext();
                if (db.Users.FirstOrDefault(u => u.Name == "Administrator") == null)
                {
                    var result = db.Users.Add(new Users()
                    {
                        IsAdmin = true,
                        Name = "Administrator",
                        Password = "CodicRulez"
                    });
                    db.SaveChanges();
                }
                var id = Login("Administrator", "CodicRulez");

                AddUser(
                    id,
                    "TestClient",
                    "CodicRulez"
                );

                AddUser(
                    id,
                    "PraktikanteN^",
                    "praktik4Life1337"
                );

                AddCategory(id, "Horror");
                AddCategory(id, "Humor");
                AddCategory(id, "Science Fiction");
                AddCategory(id, "Romance");

                List<Books> books = new List<Books>()
                {
                    new Books()
                    {
                        Amount = 3,
                        Title = "The Shining",
                        CategoryId = 1,
                        Price = 200,
                        Author= "Stephen King"
                    },
                    new Books()
                    {
                        Amount = 2,
                        Title = "Cabal (Nightbreed)",
                        CategoryId = 1,
                        Price = 250,
                        Author= "Clive Barker"
                    },
                    new Books()
                    {
                        Amount = 1,
                        Title = "Doctor Sleep",
                        CategoryId = 1,
                        Price = 250,
                        Author= "Stephen King"
                    },
                    new Books()
                    {
                        Amount = 5,
                        Title = "Liftarens guide till galaxen",
                        CategoryId = 2,
                        Price = 99,
                        Author= "Douglas Adams"
                    },
                    new Books()
                    {
                        Amount = 2,
                        Title = "Femtio nyanser av honom",
                        CategoryId = 4,
                        Price = 59,
                        Author= "E L James"
                    },
                    new Books()
                    {
                        Amount = 5,
                        Title = "I Robot",
                        CategoryId = 3,
                        Price = 150,
                        Author= "Isaac Asimov"
                    }
                };

                foreach (Books b in books)
                {
                    var retvals = AddBook(id, b.CategoryId, b.Title, b.Author, b.Price, b.Amount);
                }
                id = -1;
                return "success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Create a new instance of the API.
        /// <para>Will trigger <see cref="InitializeDefaults"/></para>
        /// </summary>
        public WebbShopApi()
        {
            InitializeDefaults();
        }

        #region Not requiring administrative permission
        /// <summary>
        /// A super simple non-secure, non-encrypted, non-modern, not to be trusted, worse than ever method to sign in to a system.
        /// </summary>
        /// <param name="username">The username you wish to use</param>
        /// <param name="password">The associated password for that username</param>
        /// <returns>The user id of the login, if the login fails, you'll receive either one of these fail codes:
        /// <list type="bullet">
        /// <item>
        /// -1 The user was not found
        /// </item>
        /// <item>
        /// -2 The user is inactive (it must be enabled by an administrator first)
        /// </item>
        /// </list>
        /// </returns>
        public int Login(string username, string password)
        {
            return UsersController.Login(username, password);
        }

        /// <summary>
        /// Invalidate the current session, forcing the user to sign in again
        /// </summary>
        /// <param name="id">The user to sign out</param>
        /// <returns>Yes or no, the only situation where a user can't be signed out is if the user doesn't exist</returns>
        public bool Logout(int id)
        {
            return UsersController.Logout(id);
        }

        /// <summary>
        /// Get all book categories (no filter).
        /// </summary>
        /// <returns>Every book category in db so far.</returns>
        public List<BookCategory> GetCategories()
        {
            return BookCategoryController.GetCategories();
        }

        /// <summary>
        /// Get all categories by a search word (keyword).
        /// </summary>
        /// <param name="keyword">Your needle, what you want to search for. You can search for "rom" for Romance or "ram" for Drama.</param>
        /// <returns>A list of all categories that matches your search word.</returns>
        public List<BookCategory> GetCategories(string keyword)
        {
            return BookCategoryController.GetCategories(keyword);
        }

        /// <summary>
        /// Get all books in a certain category, independent of other criterias.
        /// </summary>
        /// <param name="categoryId">What category id to browse books by.</param>
        /// <returns>Returns any books that contains a category id matching the parameter.</returns>
        public List<Books> GetCategory(int categoryId)
        {
            return BookController.GetCategory(categoryId);
        }

        /// <summary>
        /// Returns available books for a specific category
        /// </summary>
        /// <param name="categoryId">Category id</param>
        /// <returns>List of books</returns>
        public List<Books> GetAvailableBooks(int categoryId)
        {
            return BookController.GetAvailableBooks(categoryId);
        }

        /// <summary>
        /// Get book by id number
        /// </summary>
        /// <param name="bookId">Book id</param>
        /// <returns>Book object</returns>
        public Books GetBook(int bookId)
        {
            return BookController.GetBook(bookId);
        }

        /// <summary>
        /// Return any book with a certain keyword in it.
        /// </summary>
        /// <param name="keyword">Your needle for the haystack. You may search for any part of a title, such as "shi" from Stephen Kings book "The Shining".</param>
        /// <returns>A list of books matching your critera.</returns>
        public List<Books> GetBooks(string keyword)
        {
            return BookController.GetBooks(keyword);
        }

        /// <summary>
        /// List books with a certain author.
        /// </summary>
        /// <param name="keyword">Your needle for the haystack. You may search for any part of a author, such as "ki" from Stephen King.</param>
        /// <returns>A list of books matching the search criteria.</returns>
        public List<Books> GetAuthors(string keyword)
        {
            return BookController.GetAuthors(keyword);
        }

        /// <summary>
        /// Buy a book
        /// </summary>
        /// <param name="uid">User id who bought it</param>
        /// <param name="bookId">The specific book to modify</param>
        public bool BuyBook(int uid, int bookId)
        {
            return BookController.BuyBook(uid, bookId);
        }

        /// <summary>
        /// Prolong the current session of the user, requires that:
        /// <list type="number">
        /// <item>A user must exist</item>
        /// <item>A user already has an active session</item>
        /// </list>
        /// </summary>
        /// <param name="uid">The users identification number</param>
        /// <returns>States 
        /// <list type="table">
        /// <item>
        /// 1 means that nothing is wrong and the session has been extended
        /// </item>
        /// <item>
        /// -1 means that the user was not found
        /// </item>
        /// <item>
        /// -2 means that the session has already been invalidated and the user must login anew.
        /// </item>
        /// </list>
        /// </returns>
        public string Ping(int uid)
        {
            return UsersController.Ping(uid) == true ? "pong" : string.Empty;
        }

        /// <summary>
        /// Allows you to register a new customer.
        /// </summary>
        /// <param name="name">The users name</param>
        /// <param name="password">The users preferRed associated password</param>
        /// <param name="passwordVerify">The users preferRed associated password. Must match previous parameter password.</param>
        /// <returns>True for success or false if any of the following conditions are not met:
        /// <list type="bullet">
        /// <item>The name provided is null or empty (not set or "")</item>
        /// <item>The password provided in either password or passwordVerify is null or empty (not set or "")</item>
        /// <item>The name is already taken.</item>
        /// </list></returns>
        public bool Register(string name, string password, string passwordVerify)
        {
            return CustomerController.Register(name, password, passwordVerify);
        }
        #endregion

        #region Administrative functionality
        /// <summary>
        /// Allows administators to add a book to your inventory. If the book already exists, the amount will automatically be added to that book instead.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="title">The original full title of the book</param>
        /// <param name="author">The author of the book</param>
        /// <param name="price">The price for each copy</param>
        /// <param name="amount">The amount of copies to add</param>
        /// <returns>Returns true if any modifications or additions was made, if any of these conditions are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        ///  2 The book exists and was updated with the amount
        /// </item>
        /// <item>
        ///  1 The book didn't exist and was therefor created
        /// </item>
        /// <item>
        /// -1 The user is not an administrator
        /// </item>
        /// <item>
        /// -2 The title is empty
        /// </item>
        /// <item>
        /// -3 The author is empty
        /// </item>
        /// </list>
        /// </returns>
        public bool AddBook(int adminId, int categoryId, string title, string author, double price, int amount)
        {
            return BookController.AddBook(adminId, categoryId, title, author, price, amount);
        }

        /// <summary>
        /// Allows administators to set the amount of copies of a certain book
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="amount">The amount of copies to add</param>
        /// <returns>False if any of these conditions are not met:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// <item>
        /// The amount is less than 0
        /// </item>
        /// </list>
        /// </returns>
        public bool SetAmount(int adminId, int bookId, int amount)
        {
            return BookController.SetAmount(adminId, bookId, amount);
        }

        /// <summary>
        /// Allows administators to list all users
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <returns>A list of all users ever</returns>
        public List<Users> ListUsers(int adminId)
        {
            return UsersController.ListUsers(adminId);
        }

        /// <summary>
        /// Allows administators to check if the user exists, and then return that user.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="keyword">The keyword to search for in the users name</param>
        /// <returns>Null for no result or a users object</returns>
        public Users FindUser(int adminId, string keyword)
        {
            return UsersController.FindUser(adminId, keyword);
        }

        /// <summary>
        /// Allows administators to update a book with new information. Any field left empty will not be set ("" or 0).
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="title">New title, if left empty, no title will be updated</param>
        /// <param name="author">New author, if left empty, no new author will be set</param>
        /// <param name="price">New price, if set to 0, no new price will be set</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public bool UpdateBook(int adminId, int bookId, string title, string author, double price)
        {
            return BookController.UpdateBook(adminId, bookId, title, author, price);
        }

        /// <summary>
        /// Allows administators to delete one specific copy of a book
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public bool DeleteBook(int adminId, int bookId)
        {
            return BookController.DeleteBook(adminId, bookId);
        }

        /// <summary>
        /// Allows administators to add a new category.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="name">The name you wish the category to have.</param>
        /// <returns>False if any of these conditions are not met:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The name is either null or empty (nothing is enteRed but "")
        /// </item>
        /// <item>
        /// The category already exists
        /// </item>
        /// </returns>
        public bool AddCategory(int adminId, string name)
        {
            return BookCategoryController.AddCategory(adminId, name);
        }

        /// <summary>
        /// Allows administators to adds a category to the book.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="bookId">The specific book to modify</param>
        /// <param name="categoryId">Which category to add the book to</param>
        /// <returns>Returns true if all conditions are met, if any of these are not met, false is returned:
        /// <list type="bullet">
        /// <item>
        /// The user is not an administrator
        /// </item>
        /// <item>
        /// The id is pointing to a book that doesn't exist
        /// </item>
        /// <item>
        /// The id is pointing to a category that doesn't exist
        /// </item>
        /// <item>
        /// The book already has the category
        /// </item>
        /// </list></returns>
        public bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            return BookController.AddBookToCategory(adminId, bookId, categoryId);
        }

        /// <summary>
        /// Allows administators to update a category name.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="categoryId">Which category you'd like to change name for</param>
        /// <param name="name">What name you want to set.</param>
        /// <returns>Returns false if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The category id is pointing to a category that doesn't exist.
        /// </item>
        /// <item>
        /// The name is either null or empty (not set (""))
        /// </item>
        /// </list>
        /// </returns>
        public bool UpdateCategory(int adminId, int categoryId, string name)
        {
            return BookCategoryController.UpdateCategory(adminId, categoryId, name);
        }

        /// <summary>
        /// Allows administators to delete a category, to do this, you must not have any books related to this category.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="categoryId">What category to delete</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The category id is pointing to a category that doesn't exist
        /// </item>
        /// <item>
        /// There are books that has this category assigned to it.
        /// </item>
        /// </list>
        /// </returns>
        public bool DeleteCategory(int adminId, int categoryId)
        {
            return BookCategoryController.DeleteCategory(adminId, categoryId);
        }

        /// <summary>
        /// Allows administators to create a new user.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="name">The desiRed username</param>
        /// <param name="password">The password to associate with this username</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The name is null or empty (not set (""))
        /// </item>
        /// <item>
        /// The password is null or empty (not set (""))
        /// </item>
        /// <item>
        /// The username is already taken
        /// </item>
        /// </list>
        /// </returns>
        public bool AddUser(int adminId, string name, string password)
        {
            return UsersController.AddUser(adminId, name, password);
        }

        /// <summary>
        /// Allows administators to get all items sold ever
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <returns>A list of all sold items</returns>
        public List<SoldBooks> SoldItems(int adminId)
        {
            return SoldBooksController.SoldItems(adminId);
        }

        /// <summary>
        /// Allows administators to get how much money has been generated by selling books.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <returns>A decimal value containing the total</returns>
        public double MoneyEarned(int adminId)
        {
            return SoldBooksController.MoneyEarned(adminId);
        }

        /// <summary>
        /// Allows administators to get the customer that has generated the best income for the business
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <returns>The id of the user</returns>  
        public int BestCustomer(int adminId)
        {
            return SoldBooksController.BestCustomer(adminId);
        }

        /// <summary>
        /// Allows administators to promote a regular user to administrator status
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="uid">The target user to set status for</param>
        /// <returns>False if any of the criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The target user id is less than 1
        /// </item>
        /// <item>
        /// The target user id doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public bool Promote(int adminId, int uid)
        {
            return UsersController.Promote(adminId, uid);
        }

        /// <summary>
        /// Allows administators to demote an administrator to regular user.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="uid">The target user to set status for</param>
        /// <returns>False if any of these criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The uid provided is not an expected uid (less than 1)
        /// </item>
        /// <item>
        /// The administrator is attempting to demote her-/himself
        /// </item>
        /// <item>
        /// The target user doesn't exist
        /// </item>
        /// </list></returns>
        public bool Demote(int adminId, int uid)
        {
            return UsersController.Demote(adminId, uid);
        }

        /// <summary>
        /// Allows administators to activate user allows you to activate a user account if you know the users id.
        /// </summary>        
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool ActivateUser(int adminId, int uid)
        {
            return UsersController.ActivateUser(adminId, uid);
        }

        /// <summary>
        /// Allows administators to disable a user, making it impossible to sign in.
        /// </summary>
        /// <param name="adminId">Administator performing the task</param>
        /// <param name="uid">The target user id to affect</param>
        /// <returns>False if any of the criterias are not met:
        /// <list type="bullet">
        /// <item>
        /// The administrator is not an administrator
        /// </item>
        /// <item>
        /// The target user id is less than 1
        /// </item>
        /// <item>
        /// The target user id doesn't exist
        /// </item>
        /// </list>
        /// </returns>
        public bool DisableUser(int adminId, int uid)
        {
            return UsersController.DisableUser(adminId, uid);
        }

        #endregion

        public void Red(string errorMessage)
        {
            errorMessage = "Error: " + errorMessage;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        #region examples
        #region example 1
        /// <summary>
        /// Run example number 1 for the school assignment
        /// <list type="number">
        /// <item>Logga in Testuser</item>
        /// <item>Fråga efter kategorier </item>
        /// <item>Välj kategori Horror </item>
        /// <item>Lista böcker i kategorin </item>
        /// <item>Välj boken Dr Sleep </item>
        /// <item>Hur många finns tillgängliga? </item>
        /// <item>Köp bok </item>
        /// <item>Kontrollera antal böcker som finns tillgängliga </item>
        /// <item>UML Diagram som visar dina klasser </item>
        /// <item>ER Diagram som visar dina tabeller</item>
        /// </list>
        /// <see cref="Login(string, string)"/>
        /// <seealso cref="GetCategories"/>
        /// <seealso cref="GetAvailableBooks(int)"/>
        /// <seealso cref="BuyBook(int, int)"/>
        /// </summary>
        public void RunExample1()
        {
            var id = Login("TestClient", "CodicRulez");
            if (id > 0)
            {
                Console.WriteLine("Get Categories = = = = = = = =");
                var categories = GetCategories();
                foreach (BookCategory bc in categories)
                {
                    Console.WriteLine(bc.ToString());
                }
                Console.WriteLine("Get Category = = = = = = = =");
                if (categories != null)
                {
                    var horror = categories.FirstOrDefault(c => c.Name.ToLower() == "horror"); //eftersom vi inte vet id på horror
                    if (horror != null)
                    {
                        Console.WriteLine(horror.ToString());
                        Console.WriteLine("Get books by category = = = = = = = =");
                        var booksInHorror = GetAvailableBooks(horror.Id);   //eftersom vi nu vet id på horror
                        foreach (Books b in booksInHorror)
                        {
                            Console.WriteLine(b.ToString());
                        }

                        if (booksInHorror != null)
                        {
                            Console.WriteLine("Get book = = = = = = = =");
                            var drSleep = booksInHorror.FirstOrDefault(b => b.Title.ToLower() == "doctor sleep");   //eftersom vi inte vet id på doctor sleep
                            if (drSleep != null)
                            {
                                Console.WriteLine(drSleep.ToString());
                                Console.WriteLine("Get book amount = = = = = = = =");
                                Console.WriteLine($"There are {drSleep.Amount} books of {drSleep.Title} remaining available");
                                Console.WriteLine("Buy book = = = = = = = =");
                                if (BuyBook(id, drSleep.Id))
                                    Console.WriteLine($"Successfully bought one of the '{drSleep.Title}' books.");
                                Console.WriteLine("Get book amount = = = = = = = =");

                                /*
                                    eftersom jag gjort modifikationer ovan så vill jag inte jobba med gammal data:
                                        eftersom jag inte vet id på doctor sleep och det kan ändras i databasen beroende på flera olika faktorer (slutsåld och sen tillagd igen bla) 
                                        så väljer jag en lite klumpig väg istället för att bygga till en till 
                                        funktion för att hämta specifika böcker per titel
                                */
                                categories = GetCategories();
                                if (categories != null)
                                {
                                    horror = categories.FirstOrDefault(c => c.Name.ToLower() == "horror"); //eftersom den kan ha ändrats i en annan kontext och vi inte vill jobba med gammal raderad eller uppdaterad data
                                    if (horror != null)
                                    {
                                        booksInHorror = GetAvailableBooks(horror.Id);
                                        if (booksInHorror != null)
                                        {
                                            drSleep = booksInHorror.FirstOrDefault(b => b.Title.ToLower() == "doctor sleep"); //eftersom vi vill ha nya datat om den
                                            if (drSleep != null)
                                                Console.WriteLine($"There are {drSleep.Amount} books of {drSleep.Title} remaining available");
                                            else
                                                Red("There are no more 'Doctor Sleep' remaining");
                                        }
                                        else
                                            Red("There are no books in the horror genre.");
                                    }
                                    else
                                        Red("There is no genre called horror");
                                }
                                else
                                    Red("There are no genres.");
                            }
                            else
                                Red("Couldn't find 'Doctor Sleep' in the horror genre.");
                        }
                        else
                            Red("There are no books in the horror genre.");
                    }
                    else
                        Red("There is no genre called horror");
                }
                else
                    Red("There are no genres.");
            }
            else
                Red("Sign in failed");
            Logout(id);
        }
        #endregion
        #region example 2
        /// <summary>
        /// Run the example number 2 for the school assignment
        /// <list type="number">
        /// <item>Logga in som Admin</item>
        /// <item>Skapa kategori</item>
        /// <item>Flytta en bok dit</item>
        /// </list>
        /// <see cref="Login(string, string)"/>
        /// <seealso cref="GetCategories"/>
        /// <seealso cref="GetBooks(string)"/>
        /// <seealso cref="AddBookToCategory(int, int, int)"/>
        /// <seealso cref="Logout(int)"/>
        /// </summary>
        public void RunExample2()
        {
            var id = Login("Administrator", "CodicRulez");
            if (id > 0)
            {
                if (AddCategory(id, "Fantasy"))
                    Console.WriteLine("Successfully created the category fantasy.");

                var category = GetCategories().FirstOrDefault(c => c.Name.ToLower() == "fantasy");
                if (category != null)
                {
                    var books = GetBooks("Doctor Sleep");
                    if (books.Count > 0)
                    {
                        var book = books[0]; //eftersom en bok får bara förekomma en gång i databasen, annars ökar antalet, så vi kan bara plocka första objektet
                        if (book != null)
                        {
                            if (AddBookToCategory(id, book.Id, category.Id))
                                Console.WriteLine($"\n{book.Title} was successfully moved to {category.Name}.");
                            else
                            {
                                var current = GetCategories().FirstOrDefault(c => c.Id == book.CategoryId);
                                Red($"Failed to add the book {book.Title} to {category.Name}, {book.Title} has category {current.Name}");
                            }
                        }
                        else
                            Red("Book not found");
                    }
                    else
                        Red("No books named 'Doctor Sleep' found.");
                }
                else
                    Red("Category not found");
            }
            else
                Red("Failed to sign in.");
            Logout(id);
        }
        #endregion
        #region example 3
        /// <summary>
        /// Run the example number 3 for the school assignment
        /// <list type="number">
        /// <item>Logga in som Admin</item>
        /// <item>Skapa en användare</item>
        /// </list>
        /// <see cref="Login(string, string)"/>
        /// <seealso cref="AddUser(int, string, string)"/>
        /// <seealso cref="Logout(int)"/>
        /// </summary>
        public void RunExample3()
        {
            var id = Login("Administrator", "CodicRulez");
            if (id > 0)
            {
                if (AddUser(id, "Demo Demosson", "demooooooo0!"))
                    Console.WriteLine("User was successfully created");
                else
                    Red("Demo Demosson already exists.");
            }
            else
                Red("Failed to sign in.");
            Logout(id);
        }
        #endregion
        #endregion
    }
}
