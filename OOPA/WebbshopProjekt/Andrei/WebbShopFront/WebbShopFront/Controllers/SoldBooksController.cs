namespace WebbShopFront.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using WebbShopApi;
    using WebbShopApi.Database;

    public class SoldBooksController : Controller
    {
        private readonly MyContext _context;

        public SoldBooksController(MyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: SoldBooks
        /// </summary>
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("IsAdmin") == "True")
            {
                int bestCustomerId = WebbShopAPI.BestCustomer((int)HttpContext.Session.GetInt32("Id"));
                if (bestCustomerId != 0)
                {
                    ViewBag.BestCustomer = WebbShopAPI.GetUserById(bestCustomerId);
                }


                if (WebbShopAPI.MoneyEarned((int)HttpContext.Session.GetInt32("Id")) >= 1)
                {
                    ViewBag.MoneyEarned = WebbShopAPI.MoneyEarned((int)HttpContext.Session.GetInt32("Id"));
                }
                var myContext = _context.SoldBooks.Include(s => s.BookCategory);
                return View(await myContext.ToListAsync());
            }
            return Redirect("/users/denied");
        }
    }
}
