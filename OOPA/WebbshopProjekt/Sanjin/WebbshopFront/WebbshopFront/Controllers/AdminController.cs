using InlamningDB2;
using InlamningDB2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebbshopFront.Views.Admin;

namespace WebbshopFront.Controllers
{
    
 internal class AdminController
    {
        WebbShopAPI Api = new WebbShopAPI();
        public void Addbook(int userId)
        { 
            Api.Ping(userId);
            Console.Clear();
            var book = Views.AdminView.AddBook();
            Api.Addbook(userId, 0, book.Titel, book.Author, book.Price, book.Amount);
        }

        public void SetAmount(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            SetAmountView.Amount(out int bookId, out int amount);
            Api.SetAmount(userId, bookId, amount); 
        }

        public void ListUser(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            ListUserView.ListOfUsers(Api.ListUsers(userId));
        }

        public void FindUser(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            var keyword = Views.Admin.FindUserView.FindUsers();
            var user = Api.FindUsers(userId,keyword);
            ListUserView.ListOfUsers(user);     
            Views.GetCategory.Pause();
        }

        public void Updatebook(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            var keyword = Views.GetCategory.AskforBookName();
            var bookId = Views.GetCategory.ShowBooks(Api.GetBooks(keyword));
            if (bookId !=0)
            {
                var book = Api.GetBook(bookId);
                Views.GetCategory.ShowBook(book);
                var oldBook = Views.Admin.EditbookView.EditBook(book);
                Api.UpdateBook(userId, bookId, oldBook.Titel, oldBook.Author, oldBook.Price);
            }
        }

        public void Deletebook(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            var bookId = Views.Admin.DeleteBookView.DeleteBooks(); 
            Api.Deletebook(userId, bookId);
        }

        public void AddCategory( int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            string name = Views.Admin.AddCategoryView.AddCategories();        
            Api.AddCategory(userId, name);
        }

        public void AddBookToCategory(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            var bookName = Views.Admin.AddBookToCategoryView.AskForBookName();
            var categoryName = Views.Admin.AddBookToCategoryView.AskForCategoryName();
            var category = Api.GetCategories(categoryName);
            int counter = 1;
            foreach (var item in category)
            {
                Console.WriteLine($"{counter}. {item.Name}");
                counter++;
            }
            int.TryParse(Console.ReadLine(), out int categoryChoice);
            var book = Api.GetBooks(bookName);
            counter = 1;
            foreach (var item in book)
            {
                Console.WriteLine($"{counter}. {item.Titel}");
                counter++;
            }
            int.TryParse(Console.ReadLine(), out int bookChoice);
            if (bookChoice!=0 && categoryChoice!=0)
            {
                Api.AddBookToCategory(userId, book[bookChoice - 1].Id, category[categoryChoice - 1].Id);
            }
        }

        public void UpdateCategory(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            Views.GetCategory.ShowList(Api.GetCategories());
            int categoryId = Views.Admin.UpdateCategoryView.UpdateCategoryId();
            string categoryNewNames = Views.Admin.UpdateCategoryView.UpdateCategories();
            Api.UpdateCategory(userId, categoryId, categoryNewNames);
        }

        public void DeleteCategory(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            var categoryId = Views.Admin.DeleteCategoryView.DeleteCategories();
            Api.DeleteCategory(userId, categoryId);
        }

        public void AddUser(int userId)
        {
            Api.Ping(userId);
            Console.Clear();
            List<string> input = new List<string>();
            input = Views.Admin.AddUserView.AdminAddUser();
            Api.AddUser(userId, input[0], input[1]);
        }
    }
}
