using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to revenue. 
    /// </summary>
    public class RevenueController : Controller
    {
        BookShop.WebbShopAPI api = new BookShop.WebbShopAPI();// Connection to API.
        /// <summary>
        /// Presents index view of Revenues.
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Gets a list with all sold items and sends it to the view.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult SoldItems(int adminId)
        {
            var allSoldItems = api.SoldItems(adminId);
            return View(allSoldItems);
        }
        /// <summary>
        /// Gets the sum (price) of all sold books and sends it to the view. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult MoneyEarned(int adminId)
        {
            var sumOfMoneyEarned = api.MoneyEarned(adminId);
            ViewData ["sumOfMoneyEarned"]= sumOfMoneyEarned;
            return View();
        }
        /// <summary>
        /// Gets the most occurring user id in sold books adn returns it to the view. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Related view</returns>
        public IActionResult BestCustomer(int adminId)
        {
            var theBestCustomer = api.BestCustomer(adminId);
            ViewData["theBestCustomer"] = theBestCustomer;
            return View(theBestCustomer);
        }       
    }
}
