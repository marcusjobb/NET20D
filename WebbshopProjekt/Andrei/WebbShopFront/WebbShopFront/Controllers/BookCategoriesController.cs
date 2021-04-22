namespace WebbShopFront.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using WebbShopApi;
    using WebbShopApi.Models;

    public class BookCategoriesController : Controller
    {
        /// <summary>
        /// GET: BookCategories
        /// </summary>
        public IActionResult Index() => View(WebbShopAPI.GetCategories());

        /// <summary>
        /// GET: BookCategories/Create
        /// </summary>
        public IActionResult Create() => View();

        /// <summary>
        /// POST: BookCategories/Create
        /// </summary>
        /// <param name="bookCategory">specify BookCategory object</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BookCategoryId,Name")] BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                WebbShopAPI.AddCategory((int)HttpContext.Session.GetInt32("Id"), bookCategory.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        /// <summary>
        /// GET: BookCategories/Edit/5
        /// </summary>
        /// <param name="id">specify user id</param>
        public IActionResult Edit(int? id)
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

            var bookCategory = WebbShopAPI.GetCategoryById((int)HttpContext.Session.GetInt32("Id"), (int)id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        /// <summary>
        /// POST: BookCategories/Edit/5
        /// </summary>
        /// <param name="id">specify user id</param>
        /// <param name="bookCategory">specify BookCategory object</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCategoryId,Name")] BookCategory bookCategory)
        {
            if (id != bookCategory.BookCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                WebbShopAPI.UpdateCategory((int)HttpContext.Session.GetInt32("Id"), bookCategory.BookCategoryId, bookCategory.Name);
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        /// <summary>
        /// GET: BookCategories/Delete/5
        /// </summary>
        /// <param name="id">specify user id</param>
        public async Task<IActionResult> Delete(int? id)
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

            var bookCategory = WebbShopAPI.GetCategoryById((int)HttpContext.Session.GetInt32("Id"), (int)id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        /// <summary>
        /// Delete the book [POST: BookCategories/Delete/5]
        /// </summary>
        /// <param name="id">specify user id</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            WebbShopAPI.DeleteCategory((int)HttpContext.Session.GetInt32("Id"), id);
            return RedirectToAction(nameof(Index));
        }
    }
}
