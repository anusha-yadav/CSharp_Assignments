using E_Commerce_WebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly ECommerceContext _context;

        public OrderController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(p=>p.Product)
                .Where(o => o.UserId == (HttpContext.Session.GetInt32("userid"))).ToList();
            return View(orders);
        }
    }
}
