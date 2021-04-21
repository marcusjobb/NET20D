namespace WebbShopFront.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebbShopApi;
    using WebbShopApi.Database;
    using WebbShopApi.Models;
    using Microsoft.AspNetCore.Http;

    public class UsersController : Controller
    {
        private readonly MyContext _context;

        public UsersController(MyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                return Redirect("/users/login");
            }
            return View(WebbShopAPI.GetAllUsers());
        }

        /// <summary>
        /// Show user details [GET: Users/Details/5]
        /// </summary>
        /// <param name="id"></param>
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = WebbShopAPI.GetUserById((int)id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// GET: Users/Create
        /// </summary>
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                return View();
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// GET: Users/Denied
        /// </summary>
        public IActionResult Denied() => View();

        /// <summary>
        /// GET: Users/Login
        /// </summary>
        public IActionResult LogIn()
        {
            HttpContext.Session.Clear();
            return View();
        }

        /// <summary>
        /// POST: Users/Login
        /// </summary>
        /// <param name="user"><see cref="User"/></param>
        [HttpPost]
        public IActionResult LogIn([Bind("Name,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var id = WebbShopAPI.Login(user.Name, user.Password);
                if (id > 0)
                {
                    var resUser = WebbShopAPI.GetUserById(id);
                    HttpContext.Session.SetString("Name", resUser.Name);
                    HttpContext.Session.SetInt32("Id", resUser.UserId);
                    HttpContext.Session.SetString("IsAdmin", resUser.IsAdmin.ToString());
                    HttpContext.Session.SetString("IsActive", resUser.IsActiove.ToString());
                    return Redirect("/");
                }
            }
            return View();
        }

        /// <summary>
        /// Log out the user. Clear session
        /// </summary>
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Password")] User user)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (ModelState.IsValid)
                {
                    WebbShopAPI.AddUser((int)HttpContext.Session.GetInt32("Id"), user.Name, user.Password);
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// Show edit user view [GET: Users/Edit/5]
        /// </summary>
        /// <param name="id"></param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = WebbShopAPI.GetUserById((int)id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// POST: Users/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Password,LastLogin,IsActiove,IsAdmin")] User user)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id != user.UserId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UserExists(user.UserId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                return View(user);
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// Activate the user
        /// </summary>
        /// <param name="id"><see cref="int"/></param>
        public IActionResult Activate(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (ModelState.IsValid)
                {
                    WebbShopAPI.ActivateUser((int)HttpContext.Session.GetInt32("Id"), id);
                    return Redirect("/users");
                }
                return Redirect("Index");
            }
            return Redirect("/users/denied");


        }

        /// <summary>
        /// Deactivate the user
        /// </summary>
        /// <param name="id"><see cref="int"/></param>
        public IActionResult Deactivate(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (ModelState.IsValid)
                {
                    WebbShopAPI.InactivateUser((int)HttpContext.Session.GetInt32("Id"), id);
                    return Redirect("/users");
                }
                return Redirect("Index");
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// Promote the user
        /// </summary>
        /// <param name="id"><see cref="int"/></param>
        public IActionResult Promote(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (ModelState.IsValid)
                {
                    WebbShopAPI.Promote((int)HttpContext.Session.GetInt32("Id"), id);
                    return Redirect("/users");
                }
                return Redirect("Index");
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// Promote the user
        /// </summary>
        /// <param name="id"><see cref="int"/></param>
        public IActionResult Demote(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (ModelState.IsValid)
                {
                    WebbShopAPI.Demote((int)HttpContext.Session.GetInt32("Id"), id);
                    return Redirect("/users");
                }
                return Redirect("Index");
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// Delete the user [GET: Users/Delete/5]
        /// </summary>
        /// <param name="id"><see cref="int"/>spcify user id</param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var user = await _context.Users
                    .FirstOrDefaultAsync(m => m.UserId == id);
                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// Delete the user [POST: Users/Delete/5]
        /// </summary>
        /// <param name="id"><see cref="int"/>spcify user id</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Check if the user exist
        /// </summary>
        /// <param name="id"><see cref="int"/>spcify user id</param>
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
