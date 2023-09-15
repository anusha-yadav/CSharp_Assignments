using Microsoft.AspNetCore.Mvc;
using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;

namespace E_Commerce_WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ECommerceContext _context;

        public AccountController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                if (_context.Users.Any(user => user.Email == model.Email && user.Username == model.Username))
                {
                    ModelState.AddModelError("Email", "Email is already in use.");
                    return View(model);
                }

                // Create a new user
                var user = new Users
                {
                    Name = model.Name,
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    PhoneNumber = model.PhoneNumber,
                };

                // Hash the password and save the user to the database
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                _context.Users.Add(user);
                _context.SaveChanges();

                // You may want to implement email confirmation here

                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == model.Username);

                var id = (from userObj in _context.Users
                          where userObj.Username == model.Username
                          select userObj.Id).FirstOrDefault();

                if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    HttpContext.Session.SetString("user", model.Username);
                    HttpContext.Session.SetInt32("userid", id);
                    return RedirectToAction("Index", "Home"); // Redirect to a secure page
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        // Profile
        public IActionResult Profile()
        {
            int userid = (int)HttpContext.Session.GetInt32("userid");
            var user = _context.Users.FirstOrDefault(user => user.Id == userid);
            return View(user);
        }
    }
}
