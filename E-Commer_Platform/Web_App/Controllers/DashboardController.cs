using Microsoft.AspNetCore.Mvc;
using Web_App.Data;

namespace Web_App.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ECommerceContext _context;

        public DashboardController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.latestOrders = _context.Orders.OrderByDescending(x=>x.OrderID).Take(10).ToList();
            return View();
        }
    }
}
