using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to book categories. 
    /// </summary>
    public class BookCategoryController : Controller
    {      
        BookShop.WebbShopAPI api = new BookShop.WebbShopAPI(); // conncection to API.
        /// <summary>
        /// Shows index view of book categories.
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Gets list of categories from API and sends it to view. 
        /// </summary>
        /// <returns>Related view.</returns>
        public IActionResult ListAllCategories()
        {
            var searchResult = api.GetCategories().ToList();
            return View(searchResult);
        }
        /// <summary>
        /// Gets list of books in a category from API and sends it to view. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ShowCategoryResults(int id)
        {
            var searchResult = api.GetCategory(id).ToList();
            return View(searchResult);
        }
        /// <summary>
        /// Gets list of books in a category with a common keyword from API and sends it to view. 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns>Related view</returns>
        public IActionResult ShowCategoryResultsWithKeyword(string keyword)
        {
            var searchResult = api.GetCategories(keyword).ToList();
            return View("ShowCategoryResultsWithKeyword", searchResult);
        }
        /// <summary>
        /// Presents deletion view. 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        public IActionResult Delete(int Id, int adminId, BookCategory obj)
        {           
            return View(obj);
        }
        /// <summary>
        /// Executest deletion request. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int adminId, BookCategory obj)
        {
            if (ModelState.IsValid)
            {
                var deletion= api.DeleteCategory(adminId, obj.Id);
                if (deletion==true)
                {
                return View("DeletionOk");
                }
            }
            return View("DeletionFailed");
        }
        /// <summary>
        /// Presents update view. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult Update(int id, int adminId)
        {

            BookCategory category = api.FindCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        /// <summary>
        ///  Executest update request. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int adminId, BookCategory obj)
        {
            if (ModelState.IsValid)
            {
                var update = api.UpdateCategory(adminId, obj.Id, obj.Name);
                var objList = new List<BookCategory>() { obj};
                return View("ListAllCategories", objList);
            }
            return View(NotFound());
        }
        /// <summary>
        /// Presents creation view.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int adminId, BookCategory obj)
        {
            if (ModelState.IsValid)
            {
                var newUser = api.AddCategory(adminId, obj.Name);
                var objList = new List<BookCategory>();
                objList.Add(obj);
                return View("ListAllCategoriesWithoutButtons", objList);
            }
            return View("CreationFailed");
        }      
    }   
}
