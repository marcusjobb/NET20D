using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to logging in. 
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Presents log in view.
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Index()
        {                      
            return View();
        }
        /// <summary>
        /// Logs in a user if log in details are correct. 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <returns>Related view</returns>
        public IActionResult LoginVerification(string Name, string Password)
        {
            BookShop.WebbShopAPI api = new BookShop.WebbShopAPI();
            var login = api.Login(Name, Password);
            if (login != 0)
            {                
                TempData["id"] = login;
                TempData.Keep();
                return View("LoginVerification", login);
            }           
                return View("LoginFailed");          
        }
       
    }
}
