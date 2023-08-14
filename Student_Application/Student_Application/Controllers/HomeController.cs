using Microsoft.AspNetCore.Mvc;
using Student_Application.Models;
using System.Diagnostics;

namespace Student_Application.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /*
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            User userObj = new User();
            var user = userObj.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Authenticate the user (e.g., store user info in session)
                // Redirect to the desired page after successful login
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }
        */

        public IActionResult Register()
        {
            return View("~/Views/Registers/Create.cshtml");
        }
    }
}