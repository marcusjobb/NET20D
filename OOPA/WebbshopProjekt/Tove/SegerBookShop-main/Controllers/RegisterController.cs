using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to registering. 
    /// </summary>
    public class RegisterController : Controller
    {
        /// <summary>
        /// Presensts registration view. 
        /// </summary>
        /// <returns>Related view</returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Presents a confirmation view if registration succeeded, otherwhise a "fail view". 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <param name="Passwordverify"></param>
        /// <returns>One of the related views</returns>
        public IActionResult RegisterVerification(string Name, string Password, string Passwordverify)
        {
            BookShop.WebbShopAPI api = new BookShop.WebbShopAPI();
            var register = api.Register(Name, Password, Passwordverify);
            if (register == true)
            {
                return View("RegisterVerification");
            }
            return View("RegistrationFailed");
        }
    }
}
