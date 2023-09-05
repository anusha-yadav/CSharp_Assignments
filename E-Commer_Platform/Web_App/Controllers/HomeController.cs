using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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