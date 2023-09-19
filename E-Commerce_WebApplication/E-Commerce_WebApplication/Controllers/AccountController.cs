using Microsoft.AspNetCore.Mvc;
using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;
using E_Commerce_WebApplication.Repositories;
using SQLitePCL;

namespace E_Commerce_WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// POST: /Account/Register
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                var existingUser = _userRepository.GetUserByUsernameAndEmail(model.Username,model.Email);
                if (existingUser!=null)
                {
                    ModelState.AddModelError("Username", "Email is already in use and User alerady exists");
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
                user.Password = _userRepository.Encrypt(model.Password);
                _userRepository.AddUser(user);

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

        /// <summary>
        /// POST: /Account/Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserByUsername(model.Username);

                if (user!=null && _userRepository.AuthenticateUser(user.Username,model.Password))
                {
                    HttpContext.Session.SetString("user", model.Username);
                    HttpContext.Session.SetInt32("userid", user.Id);
                    return RedirectToAction("Index", "Home"); 
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        /// <summary>
        /// Session logout of particular user
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Get profile of a particular user
        /// </summary>
        /// <returns></returns>
        public IActionResult Profile()
        {
            int userid = (int)HttpContext.Session.GetInt32("userid");
            var user = _userRepository.GetUserById(userid);
            return View(user);
        }
    }
}
