using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Database;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class BookCategoryController
    {
        ///// <summary>
        ///// GetCategories method will display all the current categories of books
        ///// </summary>
        ///// <returns></returns>
        //public static IEnumerable<BookCategory> GetCategories(int UserId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(UserId);
        //        var GetCat = db.BookCategories.OrderBy(c => c.Name).ToList();
        //        return GetCat;
        //    }
        //}

        ///// <summary>
        ///// GetCategories will display all categories based on search keyword
        ///// </summary>
        ///// <param name="Keyword"></param>
        ///// <returns></returns>
        //public static IEnumerable<BookCategory> GetCategories(int UserId, string Keyword)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(UserId);
        //        var GetCat = db.BookCategories.Where(c => c.Name.Contains(Keyword)).OrderBy(c => c.Name).ToList();
        //        return GetCat;
        //    }
        //}

        ///// <summary>
        ///// AddCategory Method that will let the admin to add new categories for the books
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="name"></param>
        //public static void AddCategory(int AdminId, string name)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();
        //        if (admin == true)
        //        {
        //            var book = db.BookCategories.FirstOrDefault(c => c.Name == name);
        //            if (book == null)
        //            {
        //                db.BookCategories.Add(new BookCategory
        //                {
        //                    Name = name
        //                });
        //            }
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, user is NOT Admin.");
        //        }
        //    }
        //}

        ///// <summary>
        ///// UpdateCategory method that will let us rename a specific category
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="CategoryId"></param>
        ///// <param name="Name"></param>
        //public static void UpdateCategory(int AdminId, int CategoryId, string Name)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

        //        if (admin == true)
        //        {
        //            var cat = db.BookCategories.SingleOrDefault(c => c.Id == CategoryId);
        //            if (cat != null)
        //            {
        //                cat.Name = Name;
        //                db.Update(cat);
        //                db.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, because user is Not Admin");
        //        }
        //    }
        //}

        ///// <summary>
        ///// AddCategory Method that will display all books in a specific category
        ///// </summary>
        ///// <param name="CategoryId"></param>
        //public static void GetCategory(int userId, int CategoryId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        WebShopApi.Ping(userId);
        //        foreach (var cat in db.BookCategories.Include("Books").Where(c => c.Id == CategoryId))
        //        {
        //            Console.WriteLine($"{cat.Name}");
        //            foreach (var book in cat.Books)
        //            {
        //                Console.Write($"{book.Title}, ");
        //            }
        //            Console.WriteLine();
        //        }
        //    }
        //}

        ///// <summary>
        ///// DeleteCategory method that lets us delete a category, as long as it doesnt have any books connected to it
        ///// There is also a check that you have to have adminid to be able to execute this method
        ///// </summary>
        ///// <param name="AdminId"></param>
        ///// <param name="CategoryId"></param>
        //public static void DeleteCategory(int AdminId, int CategoryId)
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        var admin = db.Users.Where(a => a.Id == AdminId).Select(a => a.IsAdmin).FirstOrDefault();

        //        if (admin == true)
        //        {
        //            foreach (var cat in db.BookCategories.Include("Books").Where(c => c.Id == CategoryId).ToList())
        //            {
        //                if (cat.Books.Count != 0)
        //                {
        //                    Console.WriteLine("Category cannot be deleted, because there are still books connected to it");
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Category can be deleted, because there are no books connected to it");
        //                    db.Attach(cat);
        //                    db.Remove(cat);
        //                    db.SaveChanges();
        //                }
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Method cannot be executed, user is Not Admin.");
        //        }
        //    }
        //}
    }
}