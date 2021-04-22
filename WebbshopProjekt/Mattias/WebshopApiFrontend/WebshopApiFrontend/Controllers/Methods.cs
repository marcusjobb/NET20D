using System;
using WebbShopAPI;

namespace WebshopApiFrontend.Utility
{
    static class Methods
    {
        /// <summary>
        /// Handles the passing on of user input to API BuyBook.
        /// </summary>
        /// <param name="loggedInUser"></param>
        public static void BuyBookInDatabase(int loggedInUser)
        {
            var result = WebbshopAPI.BuyBook(loggedInUser, UserInputs.BookIdInputs());
            if (!result)
                Console.WriteLine(Errorhandeling.BadIdOrSoldout);
        }
        /// <summary>
        /// Prints the result retrieved from GetBooks.
        /// </summary>
        public static void ListBooksInDatabase()
        {
            var result = WebbshopAPI.GetBooks();
            result.ForEach(b => Console.WriteLine($"id: {b.Id}  Title: {b.Title}  Stock: {b.Amount}"));
        }
        /// <summary>
        /// Handles the passing of user input to GetCategories then prints out the results.
        /// </summary>
        public static void GetCategoriesByKeywordFromDatabase()
        {
            var result = WebbshopAPI.GetCategories(UserInputs.InputKeyword());
            if (result.Count!=0)
                result.ForEach(c => Console.WriteLine($"id: {c.Id}   Name: {c.Name}"));
            else
                Console.WriteLine(Errorhandeling.EmptyReturn);
        }
        /// <summary>
        /// Handles the printing of results from GetCategories
        /// </summary>
        public static void GetCateogiesFromDatabase()
        {
            var categories = WebbshopAPI.GetCategories();
            categories.ForEach(c => Console.WriteLine(c));
        }
        /// <summary>
        /// Handles the passing of user input to GetAuthors then prints the results.
        /// </summary>
        public static void GetAuthorsByKeywordFromDatabase()
        {
            var authorsByKeyword = WebbshopAPI.GetAuthors(UserInputs.InputKeyword());
            if(authorsByKeyword.Count!=0)
                authorsByKeyword.ForEach(a => Console.WriteLine($"Name: {a.Author}"));
            else
                Console.WriteLine(Errorhandeling.EmptyReturn);
        }
        /// <summary>
        /// Handles the passing of user input to GetBooks then prints the results
        /// </summary>
        public static void GetBooksByKeywordFromDatabase()
        {
            var booksByKeyword = WebbshopAPI.GetBooks(UserInputs.InputKeyword());
            if(booksByKeyword.Count!=0)
                booksByKeyword.ForEach(b => Console.WriteLine($"id: {b.Id}   Title: {b.Title}   Author: {b.Author}   Category: {b.Category}"));
            else
                Console.WriteLine(Errorhandeling.EmptyReturn);
        }
        /// <summary>
        /// Handles the passing of user input to GetBook then displays the result or Errorhandeling message
        /// </summary>
        public static void GetBookByIdFromDatabase()
        {
            var book = WebbshopAPI.GetBook(UserInputs.InputId());
            if(book.Count!=0)
                book.ForEach(b => Console.WriteLine($"Id: {b.Id}    Title: {b.Title}    Author: {b.Author}  Category: {b.Category}"));
            else
                Console.WriteLine(Errorhandeling.Invalid);
        }
        /// <summary>
        /// Handles the passing of user input to GetAvaliableBooks then prints the results
        /// </summary>
        public static void GetAvaliableBooksByCatIdFromDatabase()
        {
            var books = WebbshopAPI.GetAvailableBooks(UserInputs.InputId());
            if(books.Count!=0)
                books.ForEach(b => Console.WriteLine($"id: {b.Id}   Title: {b.Title}   Author: {b.Author}   Category: {b.Category}"));
            else
                Console.WriteLine(Errorhandeling.EmptyReturn);
        }
        /// <summary>
        /// Handles the passing of user input to GetCategory then displays the result or Errorhandeling message
        /// </summary>
        public static void GetCategoryByIdFromDatabase()
        {
            var item = WebbshopAPI.GetCategory(UserInputs.InputId());
            if (item!=null)
                Console.WriteLine($"id: {item.Id}   Name: {item.Name}");
            else
                Console.WriteLine(Errorhandeling.Invalid);
        }
    }
}
