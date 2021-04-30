using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Database;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class BookController
    {
        ///// <summary>
        ///// GetAvailableBooks method that displays all books that are currently in stock in a category
        ///// </summary>
        ///// <param name="CategoryId"></param>
        //public static void GetAvailableBooks(int userId, int CategoryId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(userId);

        //        foreach (var cat in db.BookCategories.Include("Books").Where(c => c.Id == CategoryId))
        //        {
        //            Console.WriteLine($"{cat.Name}");
        //            foreach (var book in cat.Books.Where(b => b.Amount > 0))
        //            {
        //                Console.Write($"{book.Title}, ");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        ///// <summary>
        ///// GetBook Method that will give us information about a specific book with help of the id of the book
        ///// </summary>
        ///// <param name="Bookid"></param>
        //public static void GetBook(int userId, int Bookid)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(userId);
        //        var book = db.Books.FirstOrDefault(b => b.Id == Bookid);
        //        if (book != null)
        //        {
        //            Console.WriteLine("Book Information");
        //            Console.WriteLine($"Title: {book.Title}");
        //            Console.WriteLine($"Author: {book.Author}");
        //            Console.WriteLine($"Price: {book.Price}");
        //            Console.WriteLine($"Ammount: {book.Amount}");
        //        }
        //    }
        //}

        ///// <summary>
        ///// Method that displays books based on searching for title
        ///// </summary>
        ///// <param name="Keyword"></param>
        ///// <returns></returns>
        //public static IEnumerable<Book> GetBooks(int userId, string Keyword)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(userId);
        //        var GetBooks = db.Books.Where(b => b.Title.Contains(Keyword)).OrderBy(b => b.Title).ToList();
        //        return GetBooks;
        //    }
        //}

        ///// <summary>
        ///// Get Authors method returns book based on searching with keyword for the author
        ///// </summary>
        ///// <param name="Keyword"></param>
        ///// <returns></returns>
        //public static IEnumerable<Book> GetAuthors(int userId, string Keyword)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(userId);
        //        var GetAuthors = db.Books.Where(a => a.Author.Contains(Keyword)).OrderBy(a => a.Author).ToList();
        //        return GetAuthors;
        //    }
        //}

        ///// <summary>
        ///// BuyBook Method will let an user buy a book and the records of the user and the book will be copied to the table SoldBooks
        ///// Will only be possible if the user been active for the last 15 minutes
        ///// </summary>
        ///// <param name="UserId"></param>
        ///// <param name="BookId"></param>
        //public static void BuyBook(int UserId, int BookId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var user = db.Users.FirstOrDefault(u => u.Id == UserId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
        //        WebShopApi.Ping(UserId);
        //        if (user != null)
        //        {
        //            foreach (var book in db.Books.Include("BookCategories").Where(b => b.Id == BookId).ToList())
        //            {
        //                foreach (var cat in book.BookCategories)
        //                {
        //                    var catid = cat.Id;

        //                    db.SoldBooks.Add(new SoldBook
        //                    {
        //                        Title = book.Title,
        //                        Author = book.Author,
        //                        Price = book.Price,
        //                        PurchaseDate = DateTime.Now,
        //                        CategoryId = catid,
        //                        UserId = UserId
        //                    });
        //                    db.SaveChanges();
        //                    book.Amount = book.Amount - 1;
        //                    db.Update(book);
        //                    db.SaveChanges();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("User have not been active for 15 minutes. To be able to buy a book, please login again");
        //        }
        //    }
        //}

        ///// <summary>
        ///// AddBookToCategory method lets us add a book based on id to be connected to a category based on their id
        ///// To create a relation between them
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="BookId"></param>
        ///// <param name="CategoryId"></param>
        //public static void AddBookToCategory(int AdminId, int BookId, int CategoryId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

        //        if (admin == true)
        //        {
        //            var book = db.Books.Include("BookCategories").FirstOrDefault(b => b.Id == BookId);

        //            if (book.BookCategories == null)
        //            {
        //                book.BookCategories = new List<BookCategory>();
        //            }

        //            foreach (var bookcategory in db.BookCategories.ToList())
        //            {
        //                var cat = db.BookCategories.FirstOrDefault(c => c.Id == CategoryId);
        //                if (cat == null)
        //                {
        //                    cat = new BookCategory
        //                    {
        //                        Id = CategoryId
        //                    };
        //                }
        //                book.BookCategories.Add(cat);
        //            }
        //            db.Update(book);
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, user is Not Admin.");
        //        }
        //    }
        //}

        ///// <summary>
        ///// AddBook Method that will let us add either more of the same book which will increase the amount
        ///// Or if book currently doesnt exist, it will be created
        ///// NOTE - in the spec it was said that we should set the ID of the book. But in my opinion its better for EF
        ///// To generate the Id's on their own so that we dont mess something up
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="Title"></param>
        ///// <param name="Author"></param>
        ///// <param name="Price"></param>
        ///// <param name="Amount"></param>
        //public static void AddBook(int AdminId, string Title, string Author, int Price, int Amount)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

        //        if (admin == true)
        //        {
        //            var book = db.Books.SingleOrDefault(b => b.Title == Title);

        //            if (book != null)
        //            {
        //                book.Amount = book.Amount + Amount;
        //                db.Update(book);
        //                db.SaveChanges();
        //                Console.WriteLine("Book amount updated");
        //            }
        //            else
        //            {
        //                book = new Book
        //                {
        //                    Title = Title,
        //                    Author = Author,
        //                    Price = Price,
        //                    Amount = Amount
        //                };
        //                db.Books.Add(book);
        //                db.SaveChanges();
        //                Console.WriteLine("New book has been added");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, because user is Not Admin");
        //        }
        //    }
        //}

        ///// <summary>
        ///// SetAmount Method that lets the admin change the amount of books for a certain book
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="BookId"></param>
        ///// <param name="BookAmount"></param>
        //public static void SetAmount(int AdminId, int BookId, int BookAmount)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
        //        if (admin == true)
        //        {
        //            var result = db.Books.SingleOrDefault(b => b.Id == BookId);
        //            if (result != null)
        //            {
        //                result.Amount = BookAmount;
        //                db.Update(result);
        //                db.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, because user is NOT Admin.");
        //        }
        //    }
        //}

        ///// <summary>
        ///// UpdateBook Method that will let the admin update information about a specific book
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="Bookid"></param>
        ///// <param name="Title"></param>
        ///// <param name="Author"></param>
        ///// <param name="Price"></param>
        //public static void UpdateBook(int AdminId, int Bookid, string Title, string Author, int Price)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
        //        if (admin == true)
        //        {
        //            var book = db.Books.SingleOrDefault(b => b.Id == Bookid);
        //            if (book != null)
        //            {
        //                book.Title = Title;
        //                book.Author = Author;
        //                book.Price = Price;
        //                db.Update(book);
        //                db.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, because user is NOT Admin.");
        //        }
        //    }
        //}

        ///// <summary>
        ///// DeleteBook Method that will let admin remove 1 amount of book, if its 0 the book will be removed from the database
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="BookId"></param>
        //public static void DeleteBook(int AdminId, int BookId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
        //        if (admin == true)
        //        {
        //            var book = db.Books.SingleOrDefault(b => b.Id == BookId);
        //            if (book != null)
        //            {
        //                book.Amount = book.Amount - 1;
        //                db.Update(book);
        //                db.SaveChanges();

        //                if (book.Amount <= 0)
        //                {
        //                    db.Attach(book);
        //                    db.Remove(book);
        //                    db.SaveChanges();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method will not be executed, because user is NOT Admin.");
        //        }
        //    }
        //}
    }
}