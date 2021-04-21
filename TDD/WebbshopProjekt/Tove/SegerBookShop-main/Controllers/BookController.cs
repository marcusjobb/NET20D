using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BookShop.Models;

namespace SegerBookShop.Controllers

{
    /// <summary>
    /// Handles functions related to books. 
    /// </summary>
    public class BookController : Controller
    {
        BookShop.WebbShopAPI api = new BookShop.WebbShopAPI(); // Connection to API.
        /// <summary>
        /// Presents index page for books. 
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Gets list with a specific book and sends it to the view.  
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Related view</returns>
        public IActionResult ShowSearchResults(int id)
        {           
            var searchResult = api.GetBook(id).ToList();
            return View(searchResult);
        }
        /// <summary>
        /// Gets list with books containing a specific keyword and sends it to the view.  
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Related view</returns>
        public IActionResult ShowSearchResultsWithKeyword(string keyword)
        {
            var searchResult = api.GetBooks(keyword).ToList();
            return View(searchResult);
        }
        /// <summary>
        ///  Gets list with books thas has the same author and sends it to the view.  
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Related view</returns>
        public IActionResult MatchingAuthorList(string keyword)
        {
            var searchResult = api.GetAuthors(keyword).ToList();
            return View(searchResult);
        }
        /// <summary>
        ///  Gets list with all books and sends it to the view.  
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult AllBooks(int adminId)
        {
            adminId = 0;
            if (TempData.ContainsKey("adminId"))
                adminId = Convert.ToInt32(TempData["adminId"]);
            TempData.Keep("adminId");
            var bookList = api.GetBookList(adminId);
            return View(bookList);
        }
        /// <summary>
        ///  Presents creation view.  
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Creates a book with given input. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int adminId, Book obj)
        {
            if (ModelState.IsValid)
            {
                var newUser = api.AddBook(adminId, obj.Title, obj.Author, obj.Price, obj.Amount);
                var objList = new List<Book>();
                objList.Add(obj);
                return View("AllBooksWithoutButtons", objList);
            }
            return View("CreationFailed");
        }
        /// <summary>
        /// Presents update view. 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult Update(int Id, int adminId)
        {
            var thisBook = api.GetBook(Id);
            if (Id == 0)
            {
                return NotFound();
            }
            return View(thisBook[0]);
        }
        /// <summary>
        /// Updates book object with given input. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int adminId, Book obj)
        {
            if (ModelState.IsValid)
            {
                var newUser = api.UpdateBook(adminId, obj.Id, obj.Title, obj.Author, obj.Price);
                var objList = new List<Book>();
                objList.Add(obj);
                return View("AllBooks", objList);
            }
            return View("CreationFailed");
        }
        /// <summary>
        /// Presents deletion view. 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult Delete(int Id, int adminId)
        {
            var thisBook = api.GetBook(Id);
            if (Id == 0)
            {
                return NotFound();
            }
            return View(thisBook[0]);
        }
        /// <summary>
        /// Deletes a book. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int adminId, Book obj)
        {
            if (ModelState.IsValid)
            {
                api.DeleteBook(adminId, obj.Id);
                var objList = new List<Book>();
                objList.Add(obj);
                return View("DeletionOk");
            }
            return View("CreationFailed");
        }
        /// <summary>
        /// Gets a list with all available books (stock >0) and sends it to the view. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Related view</returns>
        public IActionResult AllAvailableBooks(int id)
        {
            var bookList = api.GetAvailableBooks(id);
            return View("AvailableBooks", bookList);
        }
        /// <summary>
        /// Adds the chosen book to table "sold books" and decreases stock with 1. User must be logged in.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        public IActionResult BuyBook(int id, Book obj)
        {       
            if (TempData.ContainsKey("id"))
                id = Convert.ToInt32(TempData["id"]);
            TempData.Keep();
            var boughtBook = api.BuyBook(id, obj.Id);
            if (boughtBook == true)
            {
                return View();
            }
            return View("BuyFailed");
        }
        /// <summary>
        /// Presents stock correction view. 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult StockCorrection(int Id, int adminId)
        {
            var thisBook = api.GetBook(Id);
            if (Id == 0)
            {
                return NotFound();
            }
            return View(thisBook[0]);
        }
        /// <summary>
        /// Corrects stock to given stock level. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StockCorrection(int adminId, Book obj)
        {
            if (ModelState.IsValid)
            {
                obj.Amount = api.SetAmount(adminId, obj.Id, obj.Amount);
                var objList = new List<Book>();
                objList.Add(obj);
                return View("AllBooks", objList);
            }
            return View("CreationFailed");
        }
        /// <summary>
        /// Presents view to add a book to a specific category.
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult AddBookToCategory()
        {
            return View();
        }
        /// <summary>
        /// Adds a book to a given category. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBookToCategory(int adminId, Book obj)
        {
            if (ModelState.IsValid)
            {
                var added = api.AddBookToCategory(adminId, obj.Id, obj.CategoryId);
                if (added == true)
                {
                    return View("BookAddedToCategory");
                }
            }
            return View("CreationFailed");
        }
    }
}
