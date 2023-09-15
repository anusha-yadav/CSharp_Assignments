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

        /// <summary>
        /// Getting cart from current user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Cart GetCartFromCurrentUser(int userId)
        {
            Cart userCart = _context.Carts.FirstOrDefault(c => c.UserId == userId);
            return userCart;
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
                var userCart = _context.Carts
                    .Include(c => c.CartItems)
                    .ThenInclude(ci=>ci.Products)
                    .FirstOrDefault(c => c.UserId == userId.Value);
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
        public IActionResult AddToCart(int productId,int quantity)
        {
            int? userId = HttpContext.Session.GetInt32("userid");

            if (!userId.HasValue)
            {
                RedirectToAction("Login", "Account");
            }

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

        /// <summary>
        /// Removing cart items
        /// </summary>
        /// <param name="cartItemId"></param>
        /// <returns></returns>
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

        /// <summary>
        ///  Getting cart items count
        /// </summary>
        /// <returns></returns>
        public IActionResult GetCartItemsCount()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            int cartItemsCount = _context.Carts
                .Where(user => user.UserId == userid)
                .SelectMany(cart => cart.CartItems).Count(); 
            return Json(cartItemsCount); 
        }

        /// <summary>
        /// Updating the cart items 
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="quantity"></param>
        /// <param name="productid"></param>
        /// <returns></returns>
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
            if(userid.HasValue)
            {
                var item = _context.Products.FirstOrDefault(product => productid == product.Id);
                var viewModel = new BuyNowViewModel
                {
                    Quantity = 1,
                    ProductID = productid,
                    UserID = userid.Value,
                    ProductPrice = item.Price,
                    ProductName = item.ProductName
                };

                _context.BuyNowItems.Add(viewModel);
/*                var viewModel = _context.BuyNowItems.Include(product=>product.Product).FirstOrDefault(user=>user.UserID == userid);
*/                //viewModel = (BuyNowViewModel)_context.BuyNowItems.Include(products => products.Product);
                return View(viewModel);
            }
            return RedirectToAction("Login", "Account");
        }


    }
}
