namespace WebbShopAPI
{
    using System;
    using System.Collections.Generic;
    using WebbShopAPI.APIHelper;
    using WebbShopAPI.Database;
    using WebbShopAPI.Models;

    /// <summary>
    /// Defines the <see cref="API" />.
    /// </summary>
    internal class API
    {
        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        private int UserId { get; set; }

        /// <summary>
        /// Gets or sets the AdminId.
        /// </summary>
        private int AdminId { get; set; }

        /// <summary>
        /// Defines the Hepler.
        /// </summary>
        private WebbShopAPIHelper Hepler = new WebbShopAPIHelper();

        /// <summary>
        /// Runs a test of API to shows how it works
        /// </summary>
        public void Run()
        {
            Seeder.Seed();
            Console.WriteLine("\n      *** WELCOME TO MY WEBBSHOP ***  ");
            Console.WriteLine("--------------------------------------------\n");
            UserId = Hepler.Login("TestCustomer", "Codic2021");
            Console.WriteLine(" TestCustomer successfully logged in  \n");
            Console.WriteLine("---------------------------------------------\n");
            PrintCategories();
            Console.WriteLine("\n---------------------------------------------\n");
            PrintBooksInCategory("Horror");
            Console.WriteLine("\n---------------------------------------------\n");
            buy("Cabal (Nightbreed)");
            Console.WriteLine("\n---------------------------------------------\n");
            Console.WriteLine("Press Enter to login as Adimn: ");
            Console.ReadLine();
            Console.Clear();
            AdminId = Hepler.Login("Administrator", "CodicRulez");
            Console.WriteLine("\nTestAdmin successfully logged in as Administrator \n");
            Console.WriteLine("---------------------------------------------");
            AddCategory("Classics");
            AddbookToCategory("Classics");
            Console.WriteLine("\n---------------------------------------------\n");
            AddUser("TestUser6", "123456");
            Console.WriteLine("\n---------------------------------------------\n");
            GetSoldItems();
            Console.WriteLine();
            GetMoneyEarned();
            Console.WriteLine();
            GetBestCustomer();
            Console.WriteLine("---------------------------------------------\n");
            Console.ReadKey();
        }

        /// <summary>
        /// Shows the categories in database.
        /// </summary>
        public void PrintCategories()
        {
            List<BookCategory> myCategories = new List<BookCategory>();
            Hepler.UpdateSessionTimer(UserId);
            Console.WriteLine("BOOK CATEGORIES: \n");
            myCategories = WebbShopAPIHelper.GetCategories();
            foreach (var item in myCategories)
            {
                Console.WriteLine(item.Name);
            }
        }

        /// <summary>
        /// Show books in a category
        /// </summary>
        /// <param name="category">The category<see cref="string"/>.</param>
        public void PrintBooksInCategory(string category)
        {
            List<Book> books = new List<Book>();
            Hepler.UpdateSessionTimer(UserId);
            books = Hepler.GetCategory(category);
            Console.WriteLine($"Books that are in the {category} category: \n");
            foreach (var item in books)
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// Show how buy method works 
        /// </summary>
        /// <param name="book">The book<see cref="string"/>.</param>
        public void buy(string book)
        {
            Book myBook = new Book();
            myBook = WebbShopAPIHelper.GetBook(book);
            Console.WriteLine($"Available amount for {myBook.Title} is {myBook.Amount}");
            bool controller = Hepler.BuyBook(UserId, myBook.Id);
            if (controller)
            {
                myBook = WebbShopAPIHelper.GetBook(myBook.Id);
                Console.WriteLine("Your purchase was successful");
                Console.WriteLine($"{myBook.Amount} books remain.");
            }
            else
            {
                Console.WriteLine("Your purchase was not successful");
            }
        }

        /// <summary>
        /// Admin adds a book to a category
        /// </summary>
        /// <param name="book">The book<see cref="string"/>.</param>
        /// <param name="category">The category<see cref="string"/>.</param>
        public void AddbookToCategory(string category)
        {
            Hepler.AddBook(AdminId, "The Glass Hotel", " Emily St. John Mandel", 300, 3);
            Book myBook = WebbShopAPIHelper.GetBook("The Glass Hotel");
            bool controller = Hepler.AddBookToCategory(AdminId, myBook.Id, category);
            if (controller)
            {
                Console.WriteLine($"{myBook.Title} was successfully added to {category} category ");
            }
            else
            {
                Console.WriteLine("The book could not be added");
            }
        }

        /// <summary>
        /// Admin adds a book to a category
        /// </summary>
        /// <param name="CategotyName">The CategotyName<see cref="string"/>.</param>
        public void AddCategory(string CategotyName)
        {
            bool controller = Hepler.AddCategory(AdminId, CategotyName);
            if (controller)
            {
                Console.WriteLine($"{CategotyName} successfully added by TestAdmin ");
            }
            else
            {
                Console.WriteLine("Category could not be added");
            }
        }

        /// <summary>
        /// Admin adds a test user to users
        /// </summary>
        /// <param name="userName">The userName<see cref="string"/>.</param>
        /// <param name="password">The password<see cref="string"/>.</param>
        public void AddUser(string userName, string password)
        {
            bool controller = Hepler.AddUser(AdminId, userName, password);
            if (controller)
            {
                Console.WriteLine("The user successfully added by TestAdmin");
            }
            else
            {
                Console.WriteLine("User could not be added ");
            }
        }

        /// <summary>
        /// Shows sold items.
        /// </summary>
        public void GetSoldItems()
        {
            List<SoldBook> soldbooks = new List<SoldBook>();
            soldbooks = Hepler.SoldItems(AdminId);
            Console.WriteLine("Sold books :");
            foreach (var item in soldbooks)
            {
                Console.WriteLine(item.Title);
            }
        }

        /// <summary>
        /// Shows money earned of selling books
        /// </summary>
        public void GetMoneyEarned()
        {
            int moneyEarned;
            moneyEarned = Hepler.MoneyEarned(AdminId);
            Console.WriteLine($"The amount of earned money from selling books is {moneyEarned} :-");
        }

        /// <summary>
        /// Shows information of best customer
        /// </summary>
        public void GetBestCustomer()
        {
            User bestCustomer = Hepler.BestCustomer(AdminId);
            Console.WriteLine($"{bestCustomer.Name} is the best customer and has bough the most books.\n");
        }
    }
}
