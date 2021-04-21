using InlamningDB2;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebbshopFront.Controllers
{
    class CategoriesAndBookController
    {
        WebbShopAPI Api = new WebbShopAPI();
        public void GetBooksByCategory(int userId)
        {
            var input = Views.GetCategory.AskForCategoryName(Api.GetCategories());
            var books = Api.GetAvailableBooks(input);
            var book = Views.GetCategory.ShowBooks(books);
            if (book!=0)
            {
                Views.GetCategory.ShowBook(Api.GetBook(book));
                if (Views.GetCategory.AskToBuyBook(Api.GetBook(book)))
                {
                    Api.BuyBook(userId, book);
                }
                Views.GetCategory.Pause();
            }
        }

        public void Search(int userId)
        {
            var keyword = Views.GetCategory.AskforCategoryName();
            var input = Views.GetCategory.AskForCategoryName(Api.GetCategories(keyword));
            var books = Api.GetAvailableBooks(input);
            var book = Views.GetCategory.ShowBooks(books);
            if (book!=0)
            {
                if (Views.GetCategory.AskToBuyBook(Api.GetBook(book)))
                {
                    Api.BuyBook(userId, book);
                }
                Views.GetCategory.Pause();
            }
        }

        public void SearchBook(int userId)
        {
            var keyword = Views.GetCategory.AskforBookName();
            var books = Api.GetBooks(keyword);
            var book = Views.GetCategory.ShowBooks(books);
            if (book !=0)
            {
                if (Views.GetCategory.AskToBuyBook(Api.GetBook(book)))
                {
                    Api.BuyBook(userId, book);
                }
                Views.GetCategory.Pause();
            }
        }

        public void SearchAuthor(int userId)
        {
            var keyword = Views.GetCategory.AskforAuthor();
            var books = Api.GetAuthors(keyword);
            var book = Views.GetCategory.ShowBooks(books);
            if (book!=0)
            {
                Views.GetCategory.ShowBook(Api.GetBook(book));
                if (Views.GetCategory.AskToBuyBook(Api.GetBook(book)))
                {
                    Api.BuyBook(userId, book);
                }
                Views.GetCategory.Pause();
            }
        }
    }
}
