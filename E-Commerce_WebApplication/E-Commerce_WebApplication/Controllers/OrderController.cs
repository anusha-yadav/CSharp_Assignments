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

            foreach(var order in orders)
            {
                foreach(var orderItem in order.OrderItems)
                {
                    orderItem.HasRated = _context.Ratings.Any(r=>r.UserId== (HttpContext.Session.GetInt32("userid")) && r.ProductId== orderItem.ProductId);
                }
            }

            return View(orders);
        }

        public bool HasRated(int productId)
        {
            int userid = (int)HttpContext.Session.GetInt32("userid");
            return _context.Ratings.Any(r=>r.UserId==userid && r.ProductId==productId);
        }
    }
}
