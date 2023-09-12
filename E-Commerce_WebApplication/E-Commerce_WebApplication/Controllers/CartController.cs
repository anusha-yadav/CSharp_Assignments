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
            int? userId = HttpContext.Session.GetInt32("userid");

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
            int? userId = HttpContext.Session.GetInt32("userid"); 

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

        public IActionResult UpdateCartItem(int cartId, int quantity,int productid)
        {
            int? userId = HttpContext.Session.GetInt32("userid");

            Debug.WriteLine("Cart id is " + cartId + " " + productid);
            if (userId == null)
            {
                // Handle the case where the user is not logged in
                return Json(new { success = false, message = "User not logged in" });
            }

            Cart cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                // Handle the case where the user's cart is not found
                return Json(new { success = false, message = "Cart not found" });
            }

            CartItem cartItemToUpdate = cart.CartItems.FirstOrDefault(item => item.CartID == cartId && item.ProductsId == productid);


            if (cartItemToUpdate == null)
            {
                // Handle the case where the cart item is not found
                return Json(new { success = false, message = "Cart item not found" });
            }

            // Update the cart item's quantity
            cartItemToUpdate.Quantity = quantity;

            // Save changes to the database
            _context.SaveChanges();

            return Json(new { success = true, message = "Quantity updated successfully" });
        }


    }
}
