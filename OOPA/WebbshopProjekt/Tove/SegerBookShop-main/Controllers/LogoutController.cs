using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to logging out. 
    /// </summary>
    public class LogoutController : Controller
    {
        /// <summary>
        /// Presents log out view.
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Presents a confirmation view if log out succeeded. otherwhise a "fail view".
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adminId"></param>
        /// <returns>One of the related views</returns>
        public IActionResult LogoutOk(int id, int adminId)
        {
            BookShop.WebbShopAPI api = new BookShop.WebbShopAPI();
            if (TempData.ContainsKey("adminId"))
            {
                adminId = Convert.ToInt32(TempData["adminId"]);
                var logout = api.Logout(adminId);
                if (logout == true)
                {
                    return View();
                }
            }
            if (TempData.ContainsKey("id"))
            {
                id = Convert.ToInt32(TempData["id"]);
                var logout = api.Logout(id);
                if (logout == true)
                {
                    return View();
                }
            }
                
            return View("LogoutFailed");
        }
    }
}
