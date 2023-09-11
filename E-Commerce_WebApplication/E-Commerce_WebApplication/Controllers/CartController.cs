using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace E_Commerce_WebApplication.Controllers
{
    public class CartController : Controller
    {
        private readonly ECommerceContext _context;

        public CartController(ECommerceContext context)
        {
            _context = context;
        }

        public Cart GetCartFromCurrentUser(int userId)
        {
            Cart userCart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            return userCart;
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("userid"); // Replace with your actual user identification logic

            if (userId.HasValue)
            {
                // Retrieve the user's cart with CartItems
                var userCart = _context.Carts
                    .Include(c => c.CartItems)
                    .ThenInclude(ci=>ci.Products)
                    .FirstOrDefault(c => c.UserId == userId.Value);
                return View(userCart);
            }
            return PartialView("Error");
        }

        public IActionResult AddToCart(int productId,int quantity)
        {
            int? userId = HttpContext.Session.GetInt32("userid"); // Replace with your actual user identification logic

            if (userId.HasValue)
            {
                var userCart = _context.Carts
                    .Include(c => c.CartItems)
                    .FirstOrDefault(c => c.UserId == userId.Value);

                if (userCart == null)
                {
                    userCart = new Cart
                    {
                        UserId = userId.Value,
                        CartItems = new List<CartItem>()
                    };
                    _context.Carts.Add(userCart);
                }

                var existingCartItem = userCart.CartItems.FirstOrDefault(ci => ci.ProductsId == productId);

                if (existingCartItem != null)
                {
                    // If the product is already in the cart, update its quantity
                    existingCartItem.Quantity += quantity;
                    _context.SaveChanges();
                }
                else
                {
                    // If the product is not in the cart, create a new CartItem
                    var newCartItem = new CartItem
                    {
                        ProductsId = productId,
                        Quantity = quantity
                    };
                    userCart.CartItems.Add(newCartItem);
                    _context.SaveChanges();
                }

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCartItem(int cartItemId)
        {
            // Get the currently logged-in user's ID
            int? userid = HttpContext.Session.GetInt32("userid");

            // Retrieve the user's cart from the database
            Cart cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userid);

            if (cart != null)
            {
                // Find the cart item by its CartItemId and remove it
                CartItem cartItemToRemove = cart.CartItems.FirstOrDefault(item => item.CartItemId == cartItemId);

                if (cartItemToRemove != null)
                {
                    cart.CartItems.Remove(cartItemToRemove);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            int cartItemsCount = _context.Carts
                .Where(user => user.UserId == userid)
                .SelectMany(cart => cart.CartItems).Count(); // Implement this method to fetch the count from your database or shopping cart data
            return cartItemsCount;
        }

        /*
        public IActionResult UpdateCartItem(int cartItemId, int quantity)
        {
            // Get the currently logged-in user's ID
            int userid = (int)TempData["userid"];


            // Retrieve the user's cart from the database
            Cart cart = _context.Carts.Include(c => c.Items).FirstOrDefault(c => c.Id == userid);

            if (cart != null)
            {
                // Find the cart item by its CartItemId
                CartItem cartItemToUpdate = cart.Items.FirstOrDefault(item => item.Id == cartItemId);

                if (cartItemToUpdate != null)
                {
                    cartItemToUpdate.Quantity = quantity;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        */

    }
}
