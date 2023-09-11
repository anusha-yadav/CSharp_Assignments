using E_Commerce_WebApplication.Data;
using E_Commerce_WebApplication.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            //int userid = (int)HttpContext.Session.GetInt32("userid");
            int userid = 1;
            Debug.WriteLine("In Index Action" + userid);
            Cart userCart = _context.Carts.Include("CartItems.Products").FirstOrDefault(c=>c.UserId == userid);

            if(userCart == null)
            {
                userCart = new Cart
                {
                    UserId = userid,
                    CartItems =  new List<CartItem>()
                };
                _context.Carts.Add(_context.Carts.Where(c => c.UserId == 1).FirstOrDefault());
                _context.SaveChanges();
            }
            return View(_context.Carts.Where(c => c.UserId == 1).FirstOrDefault());
        }

        // POST : Cart/AddToCart
       
        public IActionResult AddToCart(int productId)
        {
            Debug.WriteLine("Hi");
            //int userid = (int)HttpContext.Session.GetInt32("userid");
            int userid = 1;
            var cart = _context.Carts.Include(item=>item.CartItems).FirstOrDefault(user => user.UserId == userid);
            if (cart == null)
            {
                Debug.WriteLine("Cart is null");
                cart = new Cart { UserId = userid, CartItems = new List<CartItem>() };
                _context.Carts.Add(cart);
            }
            
            CartItem existingCartItem = cart.CartItems.FirstOrDefault(item => item.ProductsId == productId);
            if (existingCartItem == null)
            {
                Debug.WriteLine("existing cart item is null");
                existingCartItem = new CartItem
                {
                    ProductsId = productId
                };
                cart.CartItems.Add(existingCartItem);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Cart/RemoveCartItem
        [HttpPost]
        public IActionResult RemoveCartItem(int cartItemId)
        {
            // Get the currently logged-in user's ID
            int userid = (int)TempData["userid"];

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
