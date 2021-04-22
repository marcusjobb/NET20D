using System;
using System.ComponentModel.DataAnnotations;

namespace WebbShopAPI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ////**************************************************// 
            ////
            ////      Seed
            ////
            ////**************************************************//
            Database.Seeder.Seed();

            ////**************************************************//
            ////
            ////      Login(name, password)
            ////
            ////**************************************************//
            //var userId = WebbshopAPI.Login("TestClient", "Codic2021");
            //var userId = WebbshopAPI.Login("Administrator", "CodicRulez");
            //Console.WriteLine($"Logged in with Id: {userId}");

            ////**************************************************// 
            ////
            ////      IsAdmin(userId)
            ////
            ////**************************************************//
            //var checkUser = WebbshopAPI.IsAdmin(userId);
            //Console.WriteLine(checkUser);

            ////**************************************************//
            ////
            ////      Logout(userId)
            ////
            ////**************************************************//
            //WebbshopAPI.Logout(userId);

            ////**************************************************//
            ////
            ////      GetCategories()
            ////
            ////**************************************************//
            //var allCategories = WebbshopAPI.GetCategories();
            //foreach (var item in allCategories)
            //{
            //    Console.WriteLine(item);
            //}

            ////**************************************************//
            ////
            ////      GetCategories(keyword)
            ////
            ////**************************************************//
            //var keywordCategories = WebbshopAPI.GetCategories("or");
            //foreach (var item in keywordCategories)
            //{
            //    Console.WriteLine(item.Name);
            //}

            ////**************************************************//
            ////
            ////      GetCategory(categoryId)
            ////
            ////**************************************************//
            //var idCategory = WebbshopAPI.GetCategory(2);
            //Console.WriteLine(idCategory.Name);

            ////**************************************************//
            ////
            ////      GetAvailableBooks(categoryId)
            ////
            ////**************************************************//
            //var categoryIdBooks = WebbshopAPI.GetAvailableBooks(1);
            //foreach (var item in categoryIdBooks)
            //{
            //    Console.WriteLine($"Book title: {item.Title}");
            //}

            ////**************************************************//
            ////
            ////      GetBook(bookId)
            ////
            ////**************************************************//
            //var bookIdBook = WebbshopAPI.GetBook(1);
            //Console.WriteLine("Id search for book: ");
            //foreach (var item in bookIdBook)
            //{
            //    Console.WriteLine($"Book Title: {item.Title}");
            //}

            ////**************************************************//
            ////
            ////      GetBooks(keyword)
            ////
            ////**************************************************//
            //var keywordBooks = WebbshopAPI.GetBooks("a");
            //Console.WriteLine("Keyword search for books: ");
            //foreach (var item in keywordBooks)
            //{
            //    Console.WriteLine($"Book Title: {item.Title}");
            //}

            ////**************************************************//
            ////
            ////      GetAuthors(keyword)
            ////
            ////**************************************************//
            //var keywordAuthors = WebbshopAPI.GetAuthors("isaac");
            //Console.WriteLine("Keyword search for Authors");
            //foreach (var item in keywordAuthors)
            //{
            //    Console.WriteLine(item.Author);
            //}

            ////**************************************************//
            ////
            ////      BuyBook(userId, bookId)
            ////
            ////**************************************************//
            //var buyBook = WebbshopAPI.BuyBook(1, 2);
            //Console.WriteLine(buyBook);

            ////**************************************************//
            ////
            ////     Ping(userId)
            ////
            ////**************************************************//
            //var ping = WebbshopAPI.Ping(1);
            //Console.WriteLine(ping);

            ////**************************************************//
            ////
            ////      SetSessionTimer(userId)
            ////
            ////**************************************************//
            //var userSessiontimer = WebbshopAPI.SetSessionTimer(1);
            //Console.WriteLine(userSessiontimer);

            ////**************************************************//
            ////
            ////      Register(name, password, passVerify)
            ////
            ////**************************************************//
            //var result = WebbshopAPI.Register("Marcus", "password1", "password1");
            //Console.WriteLine(result);

            ////**************************************************//*****************************************************
            ////
            ////                 AdminMethods                     
            ////
            ////**************************************************//*****************************************************

            ////**************************************************//
            ////
            ////      AddBook(adminId, title, author, price, amount)
            ////
            ////**************************************************//
            //var results = WebbshopAPI.AddBook(1, "bok", "bokman", 250, 3);
            //Console.WriteLine(results);

            ////**************************************************//
            ////
            ////      SetAmount(adminId, bookId)
            ////
            ////**************************************************//
            //Console.Write("set amount to: ");
            //Console.WriteLine(WebbshopAPI.SetAmount(1, 2));

            ////**************************************************//
            ////
            ////      ListUsers(adminId)
            ////
            ////**************************************************//
            //var listOfUsers = WebbshopAPI.ListUsers(1);
            //foreach (var item in listOfUsers)
            //{
            //    Console.WriteLine(item);
            //}

            ////**************************************************//
            ////
            ////      FindUser(adminId, keyword)
            ////
            ////**************************************************//
            //var usersFound = WebbshopAPI.FindUser(1, "te");
            //foreach (var item in usersFound)
            //{
            //    Console.WriteLine(item.Name);
            //}

            ////**************************************************//
            ////
            ////      UpdateBook(adminId, bookId, title, author, price)
            ////
            ////**************************************************//
            //var wasBookUpdated = WebbshopAPI.UpdateBook(1, 7, "En bok", "av mig", 250);
            //Console.WriteLine(wasBookUpdated);

            ////**************************************************//
            ////
            ////      DeleteBook(adminId, bookId)
            ////
            ////**************************************************//
            //var deleteBook = WebbshopAPI.DeleteBook(1, 8);
            //Console.WriteLine(deleteBook);

            ////**************************************************//
            ////
            ////      AddCategory(adminId, name)
            ////
            ////**************************************************//
            //var addedCategory = WebbshopAPI.AddCategory(1, "");
            //Console.WriteLine(addedCategory);

            ////**************************************************//
            ////
            ////      AddBookToCategory(adminId, bookId, categoryId)
            ////
            ////**************************************************//
            //var addCatToBook = WebbshopAPI.AddBookToCategory(1, 2, 4);
            //Console.WriteLine(addCatToBook);

            ////**************************************************//
            ////
            ////      UpdateCategory(adminId, categoryId, name)
            ////
            ////**************************************************//
            //var updatedCat = WebbshopAPI.UpdateCategory(1, 1, "Horror");
            //Console.WriteLine(updatedCat);

            ////**************************************************//
            ////
            ////      DeleteCategory(adminId, categoryId)
            ////
            ////**************************************************//
            //var deletedCat = WebbshopAPI.DeleteCategory(1, 7);
            //Console.WriteLine(deletedCat);

            ////**************************************************//
            ////
            ////      AddUser(adminId, name, password)
            ////
            ////**************************************************//
            //var addedUser = WebbshopAPI.AddUser(1, "Testman", "Bästman");
            //Console.WriteLine(addedUser);

            ////**************************************************//
            ////
            ////      SoldItems(adminId)
            ////
            ////**************************************************//
            //var itemssold = WebbshopAPI.SoldItems(1);
            //Console.WriteLine("Books sold");
            //foreach (var item in itemssold)
            //{
            //    Console.WriteLine($"Book title: {item}");
            //}

            ////**************************************************//
            ////
            ////      MoneyEarned(adminId)
            ////
            ////**************************************************//
            //var sumSold = WebbshopAPI.MoneyEarned(1);
            //Console.WriteLine(sumSold);

            ////**************************************************//
            ////
            ////      BestCustomer(adminId)
            ////
            ////**************************************************//
            //var findBestCustById = WebbshopAPI.BestCustomer(1);
            //Console.WriteLine($"Bestcustomer ID: {findBestCustById}");

            ////**************************************************//
            ////
            ////      Promote(adminId, userId)
            ////
            ////**************************************************//
            //var promoteUser = WebbshopAPI.Promote(1, 5);
            //Console.WriteLine(promoteUser);

            ////**************************************************//
            ////
            ////      Demote(adminId, userId)
            ////
            ////**************************************************//
            //var demoteUser = WebbshopAPI.Demote(1, 5);
            //Console.WriteLine(demoteUser);

            ////**************************************************//
            ////
            ////      ActivateUser(adminId, userId)
            ////
            ////**************************************************//
            //var userActivation = WebbshopAPI.ActivateUser(1, 2);
            //Console.WriteLine(userActivation);

            ////**************************************************//
            ////
            ////      InactivateUser(adminId, userId)
            ////
            ////**************************************************//
            //var userDeactivate = WebbshopAPI.InactivateUser(1, 2);
            //Console.WriteLine(userDeactivate);

            Console.ReadLine();
        }
    }
}
