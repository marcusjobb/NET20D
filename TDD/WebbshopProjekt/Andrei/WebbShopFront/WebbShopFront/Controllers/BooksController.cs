namespace WebbShopFront.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using WebbShopApi;
    using WebbShopApi.Database;
    using WebbShopApi.Models;
    using System;

    public class BooksController : Controller
    {
        private readonly MyContext _context;

        public BooksController(MyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Books
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var sort = HttpContext.Request.Query["categoryId"];
            var myContext = _context.Books.Include(b => b.BookCategory);

            if (!string.IsNullOrEmpty(sort))
            {
                // redirect to login page if the user is not logged in
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
                {
                    return Redirect("/users/login");
                }
                else
                {
                    var books = WebbShopAPI.GetBooksFromCategory((int)HttpContext.Session.GetInt32("Id"), Int32.Parse(sort));
                    return View(books);
                }
            }
            return View(await myContext.ToListAsync());
        }


        /// <summary>
        /// GET: Books/Details/5
        /// </summary>
        /// <param name="id">specify book id</param>
        public async Task<IActionResult> Details(int id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                // redirect to login page if the user is not logged in
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
                {
                    return Redirect("/users/login");
                }

                return View(WebbShopAPI.GetBook((int)HttpContext.Session.GetInt32("Id"), id));
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// Buy a book [POST: Books/Buy/1]
        /// </summary>
        /// <param name="id">specify book id</param>
        public IActionResult Buy(int id)
        {
            WebbShopAPI.BuyBook((int)HttpContext.Session.GetInt32("Id"), id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET: Books/Create
        /// </summary>
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                ViewData["BookCategoryId"] = new SelectList(WebbShopAPI.GetCategories(), "BookCategoryId", "Name");
                return View();
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// POST: Books/Create
        /// </summary>
        /// <param name="book">specify Book object</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Name,Author,Price,Amount,BookCategoryId")] Book book)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (ModelState.IsValid)
                {
                    WebbShopAPI.AddBook((int)HttpContext.Session.GetInt32("Id"), book.BookId, book.Name, book.Author, book.Price, book.Amount, book.BookCategoryId);
                    return RedirectToAction(nameof(Index));
                }
                ViewData["BookCategoryId"] = new SelectList(WebbShopAPI.GetCategories(), "BookCategoryId", "BookCategoryId", book.BookCategoryId);
                return View(book);
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// GET: Books/Edit/5
        /// </summary>
        /// <param name="id">specify book id</param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id == null)
                {
                    return NotFound();
                }

                // redirect to login page if the user is not logged in
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
                {
                    return Redirect("/users/login");
                }

                var book = WebbShopAPI.GetBook((int)HttpContext.Session.GetInt32("Id"), (int)id);
                if (book == null)
                {
                    return NotFound();
                }
                ViewData["BookCategoryId"] = new SelectList(WebbShopAPI.GetCategories(), "BookCategoryId", "Name", book.BookCategoryId);
                return View(book);
            }
            return Redirect("/users/denied");
        }

        /// <summary>
        /// POST: Books/Edit/5
        /// </summary>
        /// <param name="id">specify book id</param>
        /// <param name="book">specify book object</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Name,Author,Price,Amount,BookCategoryId")] Book book)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id != book.BookId)
                {
                    return NotFound();
                }

                // redirect to login page if the user is not logged in
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
                {
                    return Redirect("/users/login");
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebbShopAPI.UpdateBook((int)HttpContext.Session.GetInt32("Id"), book.BookId, book.Name, book.Author, book.Price, book.Amount, book.BookCategoryId);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (WebbShopAPI.GetBook((int)HttpContext.Session.GetInt32("Id"), book.BookId) == null)
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
                ViewData["BookCategoryId"] = new SelectList(WebbShopAPI.GetCategories(), "BookCategoryId", "Name", book.BookCategoryId);
                return View(book);
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// GET: Books/Delete/5
        /// </summary>
        /// <param name="id">specify book id</param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                if (id == null)
                {
                    return NotFound();
                }

                // redirect to login page if the user is not logged in
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
                {
                    return Redirect("/users/login");
                }

                var book = WebbShopAPI.GetBook((int)HttpContext.Session.GetInt32("Id"), (int)id);
                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            }
            return Redirect("/users/denied");

        }

        /// <summary>
        /// POST: Books/Delete/5
        /// </summary>
        /// <param name="id">specify book id</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = WebbShopAPI.DeleteBook((int)HttpContext.Session.GetInt32("Id"), id);
            return RedirectToAction(nameof(Index));
        }
    }
}
