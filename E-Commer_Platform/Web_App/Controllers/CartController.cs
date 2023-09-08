using Microsoft.AspNetCore.Mvc;
using Web_App.Data;
using ECommerceWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web_App.Models;
using Web_App.Migrations;
using Cart = ECommerceWebApplication.Models.Cart;

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
/*            var userCart = (from id in _context.Carts
                            where id.UserId == userId
                            select id).SingleOrDefault();
*/
            var userCart = _context.Carts.Include("CartItems.Product").FirstOrDefault(c => c.UserId == userId);
            return userCart;
        }

        public IActionResult Index()
        {
            int userid = (int)TempData["userid"];
            //int userid = 1;
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
            ViewBag.CartItemCount = userCart.CartItems.Count;
            return View(userCart);
        }

        // POST : Cart/AddToCart
        //[HttpPost]
        public IActionResult AddToCart(int productId)
        {
            Debug.WriteLine("In Add to Cart Action");
            int userid = (int)TempData["userid"];
            //int userid = 1;
            Cart cart = _context.Carts.Include(item => item.CartItems).FirstOrDefault(user => user.UserId == userid);
            if (cart == null)
            {
                Debug.WriteLine("Cart is null");
                cart = new Cart { UserId = userid, CartItems = new List<CartItem>() };
                _context.Carts.Add(cart);
            }
            CartItem existingCartItem = cart.CartItems.FirstOrDefault(item => item.ProductID == productId);
            if (existingCartItem == null)
            {
                Debug.WriteLine("existing cart item is null");
                existingCartItem = new CartItem
                {
                    ProductID = productId
                };
                cart.CartItems.Add(existingCartItem);
            }
            _context.SaveChanges();
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

        public IActionResult GetCartItemCount(int userid)
        {
            int cartID = _context.Carts.Where(obj=>obj.UserId  == userid).Select(obj => obj.Id).FirstOrDefault();
            int itemsCount = _context.CartItems.Where(obj=>obj.CartID==cartID).Count();
            return Json(new { count = itemsCount });
        }

/*        public IActionResult BuyNow(int productID)
        {
            int userid = (int)TempData["userid"];
            Order order = _context.Orders.Include(item=>item.OrderItems).FirstOrDefault(o=>o.UserID==userid);
            if (order == null)
            {
                order = new Order
                {
                    UserID = userid,
                    OrderItems = IList<OrderItems>()
                };
            }
        }
*/
    }
}

        
