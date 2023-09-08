using Microsoft.AspNetCore.Mvc;
using Web_App.Data;
using Web_App.Models;

namespace ECommerceWebApplication.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ECommerceContext _context;
        public CheckoutController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var order = new Order();
            return View();
        }

        /*public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            try
            {
                var order = new Order
                {
                    UserID = (int)TempData["userid"],
                    TotalAmount = order.TotalAmount,
                    Taxes = ,
                    AddressID = address.AddressId
                };

                var cartItems = _context.CartItems.Where(cartItem => cartItem.;
            }*/

    }
}
