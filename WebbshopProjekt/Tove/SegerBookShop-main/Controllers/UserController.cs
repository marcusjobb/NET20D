using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegerBookShop.Controllers
{
    /// <summary>
    /// Handles functions related to users. 
    /// </summary>
    public class UserController : Controller
    {
        BookShop.WebbShopAPI api = new BookShop.WebbShopAPI();   // Connection to API.     
        /// <summary>
        /// Presents index view of users.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IActionResult Index(User obj)
        {
            return View();
        }     
        /// <summary>
        /// Gets list with all users and sends it to the view. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        public ActionResult UserList(int adminId, User obj)
        {
            var userList = api.ListUsers(adminId);
            return View(userList);
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
        /// Creates a new user with the given input. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int adminId, User obj)
        {
            if (ModelState.IsValid)
            {
                var newUser = api.AddUser(adminId, obj.Name, obj.Password);
                var objList = new List<User>();
                objList.Add(obj);
                return View("UserListWithoutButtons", objList);
            }
            return View("CreationFailed");
        }
        /// <summary>
        /// Gets a list with user(s) containing the given keyword. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="keyword"></param>
        /// <returns>Related view</returns>
        public IActionResult FindUser(int adminId, string keyword)
        {
            var searchResult = api.FindUser(adminId, keyword).ToList();
            return View("UserList",searchResult);
        }
        /// <summary>
        /// Presents promotion view and brings a User object to be able to present which user it's about. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Related view</returns>
        public IActionResult Promote(User obj)
        {
            return View(FindUserToSendToView(obj));
           
        }
        /// <summary>
        /// Promotes a user. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Promote(int adminId, User obj)
        {
            var inactivation = api.Promote(adminId, obj.Id);
            if (inactivation == true)
            {
                return View("RequestDone");
            }
            return View(NotFound());

        }
        /// <summary>
        /// Presents demotion view and brings a User object to be able to present which user it's about. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IActionResult Demote(User obj)
        {
            return View(FindUserToSendToView(obj));         
        }
        /// <summary>
        /// Demotes a user. 
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Demote(int adminId, User obj)
        {
            var activation = api.Demote(adminId, obj.Id);
            if (activation == true)
            {
                return View("RequestDone");
            }
            return View(NotFound());
        }
        /// <summary>
        /// Presents activation view and brings a User object to be able to present which user it's about. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IActionResult Activate(User obj)
        {
            return View(FindUserToSendToView(obj));          
        }
        /// <summary>
        /// Activates a user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Activate(int adminId, User obj)
        {
            var activation = api.ActivateUser(adminId, obj.Id);
            if (activation==true)
            {
                return View("RequestDone");
            }
            return View(NotFound());
        }
        /// <summary>
        /// Presents inactivation view and brings a User object to be able to present which user it's about. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IActionResult Inactivate(User obj)
        {
            return View(FindUserToSendToView(obj));
        }
        /// <summary>
        /// Inactivates a user.
        /// </summary>
        /// <param name="adminId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inactivate(int adminId, User obj)
        {
            var inactivation = api.InactivateUser(adminId, obj.Id);
            if (inactivation == true)
            {
                return View("RequestDone");
            }
            return View(NotFound());
        }
        /// <summary>
        /// Finds a user to be able to send user object to post view
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>user object</returns>

        public User FindUserToSendToView(User obj)
        {
            var adminId = 0;
            if (TempData.ContainsKey("adminId"))
                adminId = Convert.ToInt32(TempData["adminId"]);
            TempData.Keep("adminId");
            var user = api.FindUser(adminId, obj.Id);
            return user;
        }
        
    }
}
