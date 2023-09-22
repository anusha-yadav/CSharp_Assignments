using E_Commerce_WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebApplication.Controllers
{
    [TypeFilter(typeof(AdminAuthorizeAttribute))]
    public class AdminController : Controller
    {
        // GET: Admin
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
