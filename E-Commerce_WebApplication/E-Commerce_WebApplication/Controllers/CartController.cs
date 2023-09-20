using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;
using E_Commerce_WebApplication.Repositories;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace E_Commerce_WebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ECommerceContext _context;

        /// <summary>
        /// Constructor of Cart controller
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cartRepository"></param>
        public CartController(ICartRepository cartRepository,ECommerceContext context)
        {
            _cartRepository = cartRepository;
            _context = context;
        }


        /// <summary>
        /// Index method of the controller
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("userid");

            if (userId.HasValue)
            {
                var userCart = _cartRepository.GetCartFromCurrentUser(userId.Value);
                return View(userCart);
            }
            return PartialView("Error");
        }

        /// <summary>
        /// Add to cart method to add the cart items
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public IActionResult AddToCart(int productId, int quantity)
        {
            int? userId = HttpContext.Session.GetInt32("userid");

            if (!userId.HasValue)
            {
                RedirectToAction("Login", "Account");
            }

            if (userId.HasValue)
            {
                _cartRepository.AddOrUpdateCartItem(userId.Value, productId, quantity);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removing cart items
        /// </summary>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
        public IActionResult RemoveCartItem(int cartItemId)
        {
            int? userId = HttpContext.Session.GetInt32("userid");

            if (userId.HasValue)
            {
                _cartRepository.RemoveCartItem(userId.Value, cartItemId);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        ///  Getting cart items count
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCartItemsCount()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            int cartItemsCount = _cartRepository.GetCartItemsCountByUserId(userid.Value);
            return Json(cartItemsCount);
        }

        /// <summary>
        /// Updating the cart items 
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="quantity"></param>
        /// <param name="productid"></param>
        /// <returns></returns>
        public IActionResult UpdateCartItem(int cartId, int quantity, int productid)
        {
            int? userId = HttpContext.Session.GetInt32("userid");

            Debug.WriteLine("Cart id is " + cartId + " " + productid + " "+quantity);
            if (userId == null)
            {
                // Handle the case where the user is not logged in
                return Json(new { success = false, message = "User not logged in" });
            }

            Cart cart = _cartRepository.GetCartByUserId(userId.Value);

            if (cart == null)
            {
                return Json(new { success = false, message = "Cart not found" });
            }

            bool updateSuccess = _cartRepository.UpdateCartItemQuantity(cart,cartId, quantity, productid);
            if (!updateSuccess)
            {
                return Json(new { success = false, message = "Update failed" });
            }

            return Json(new { success = true, message = "Quantity updated successfully" });
        }

        /// <summary>
        /// Buy Now method implements particular item order
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        public IActionResult BuyNow(int productid)
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            if (!userid.HasValue)
            {
                RedirectToAction("Login", "Account");
            }
            if (userid.HasValue)
            {
                Products product = _context.Products.FirstOrDefault(p => p.Id == productid);
                var viewModel = new BuyNowViewModel
                {
                    Quantity = 1,
                    ProductID = productid,
                    UserID = userid.Value,
                    Product = product
                };
                _context.BuyNowItems.Add(viewModel);
                _context.SaveChanges();
                return View(viewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantity)
        {
            // Retrieve the product from the database by productId
            var product = _context.BuyNowItems.Where(p=>p.ProductID==productId).FirstOrDefault();
            Debug.WriteLine($"{product.Quantity}");

            if (product != null)
            {
                try
                {
                    product.Quantity = quantity;
                    _context.SaveChanges();
                    return Ok(); // Return a success status code
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(500, "Internal Server Error");
                }
            }

            return NotFound(); // Return a not found status code if the product is not found
        }

    }
}
