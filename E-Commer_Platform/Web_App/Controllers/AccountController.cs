using Microsoft.AspNetCore.Mvc;
using Web_App.Models;
using Web_App.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;


namespace Web_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ECommerceContext _context;

        public AccountController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public User GetUser(string username) 
        {
            var cust = (from c in _context.Users
                        where c.username == username
                        select c).FirstOrDefault();
            return cust;
        }

        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                _context.SaveChanges();

                HttpContext.Session.SetString("username", user.username);
                TempShpData.UserID = GetUser(user.username).Id;
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(FormCollection form)
        {
            string username = form["Username"];
            string password = form["Password"];

            if (ModelState.IsValid)
            {
                var cust = (from m in _context.Users
                            where (m.username == username && m.password == password)
                            select m).SingleOrDefault();

                if (cust != null)
                {
                    TempShpData.UserID = cust.Id;
                    HttpContext.Session.SetString("Username",cust.username);
                    return RedirectToAction("Index","Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Username", null);
            TempShpData.UserID = 0;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                HttpContext.Session.SetString("Username", user.username);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult RegisterUser(UserVM uservm)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Id = uservm.Id,
                    Name = uservm.Name,
                    Email = uservm.Email,
                    username = uservm.username,
                    password = uservm.password,
                    PhoneNumber = uservm.PhoneNumber
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return PartialView("_Error");
        }
    }
}
