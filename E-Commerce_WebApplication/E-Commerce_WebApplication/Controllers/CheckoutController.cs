using E_Commerce_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_WebApplication.Data;

namespace E_Commerce_WebApplication.Controllers
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
            return View();
        }

        public IActionResult CreateAdress(Address model)
        {
            var newAdress = new Address
            {
                UserId = (int)HttpContext.Session.GetInt32("userid"),
                RecipientName = model.RecipientName,
                ShippingAddress = model.ShippingAddress,    
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
            };
            _context.Addresses.Add(newAdress);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
