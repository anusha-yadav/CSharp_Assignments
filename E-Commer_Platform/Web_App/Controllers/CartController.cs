using Microsoft.AspNetCore.Mvc;
using Web_App.Data;
using ECommerceWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ECommerceWebApplication.Controllers
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
            var userCart = _context.Carts.FirstOrDefault(obj => obj.UserId == userId);
            return userCart;
        }
        public IActionResult Index()
        {
            int userid = (int)TempData["userid"];
            Debug.WriteLine("In Index Action" + userid);
            Cart userCart = GetCartFromCurrentUser(userid);
            if (userCart == null)
            {
                userCart = new Cart
                {
                    UserId = userid,
                    CartItems = new List<CartItem>()
                };
                _context.Carts.Add(userCart);
                _context.SaveChanges();
            }
            return View(userCart);
        }

        // POST : Cart/AddToCart
        //[HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            Debug.WriteLine("In Add to Cart Action");
            //int userid = (int)TempData["userid"];
            int userid = 1;
            Cart cart = _context.Carts.Include(item => item.CartItems).FirstOrDefault(user => user.UserId == userid);
            if (cart == null)
            {
                Debug.WriteLine("Cart is null");
                cart = new Cart { UserId = userid, CartItems = new List<CartItem>() };
                _context.Carts.Add(cart);
                return View(@"\Views\Home\Index.cshtml");
            }
            CartItem existingCartItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
            if (existingCartItem == null)
            {
                Debug.WriteLine("existing cart item is null");
                existingCartItem.Quantity += quantity;
                return View(@"\Views\Home\Index.cshtml");
            }
            else
            {
                CartItem newCartItem = new CartItem
                {
                    ProductID = productId,
                    Quantity = quantity,
                };
                cart.CartItems.Add(newCartItem);
            }
            //_context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Cart/RemoveCartItem
        [HttpPost]
        public ActionResult RemoveCartItem(int cartItemId)
        {
            // Get the currently logged-in user's ID
            int userid = (int)TempData["userid"];

            // Retrieve the user's cart from the database
            Cart cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.Id == userid);

            if (cart != null)
            {
                // Find the cart item by its CartItemId and remove it
                CartItem cartItemToRemove = cart.CartItems.FirstOrDefault(item => item.CartItemID == cartItemId);

                if (cartItemToRemove != null)
                {
                    cart.CartItems.Remove(cartItemToRemove);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpdateCartItem(int cartItemId, int quantity)
        {
            // Get the currently logged-in user's ID
            int userid = (int)TempData["userid"];


            // Retrieve the user's cart from the database
            Cart cart = _context.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.Id == userid);

            if (cart != null)
            {
                // Find the cart item by its CartItemId
                CartItem cartItemToUpdate = cart.CartItems.FirstOrDefault(item => item.CartItemID == cartItemId);

                if (cartItemToUpdate != null)
                {
                    cartItemToUpdate.Quantity = quantity;
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}

        
