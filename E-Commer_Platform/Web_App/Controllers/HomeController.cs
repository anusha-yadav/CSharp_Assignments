using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_App.Models;
using Web_App.Data;
using SQLitePCL;

namespace Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ECommerceContext _context;

        public HomeController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return View("~/Views/Users/Login.cshtml");
        }

        public IActionResult Register()
        {
            return View("~/Views/Users/Create.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}