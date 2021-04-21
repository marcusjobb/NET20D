namespace WebbShopFront.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using WebbShopFront.Models;

    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Index
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: Privacy
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
