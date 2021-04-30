using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to Admin Login.
    /// </summary>
    public class AdminLoginController : Controller
    {      
        /// <summary>
        /// Shows admin log in view. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        public IActionResult Index(User obj)
        {
            obj = KeepAdminDetails(obj);        
            if (obj.IsAdmin==true && obj.Id!=0)
            {
                return View("LoginVerification");
            }
                return View();                                                      
        }
        /// <summary>
        /// Logs in an admin user.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <returns>If success: login verification view, otherwhise: login failed view</returns>
        public IActionResult AdminLogin(string Name, string Password)
        {
            BookShop.WebbShopAPI api = new BookShop.WebbShopAPI();            
            var adminCheck = api.CheckIfAdmin(Name, Password);           
            if (adminCheck == true)
            {
                var login = api.Login(Name, Password);
                TempData["adminId"] = login;
                TempData["adminCheck"] = adminCheck;
                TempData.Keep();
                return View("LoginVerification", adminCheck);
            }
            return View("LoginFailed");
        }
        /// <summary>
        /// Shows login verification view. 
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult LoginVerification()
        {
            return View();
        }
        /// <summary>
        /// Saves admin details in Temp Data to avoid having to log in as admin over and over again. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>User object</returns>
        public User KeepAdminDetails(User obj)
        {
            if (TempData.ContainsKey("adminCheck"))
                obj.IsAdmin = Convert.ToBoolean(TempData["adminCheck"]);
            if (TempData.ContainsKey("adminId"))
                obj.Id = Convert.ToInt32(TempData["adminId"]);
            TempData.Keep();
            return obj;
        }



    }
}
