using E_Commerce_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Commerce_WebApplication.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ECommerceContext _context;

        public CheckoutController(ECommerceContext context)
        {
            _context = context;
        }

        // Index method of the checkout controller
        public IActionResult Index()
        {
            return View();
        }

        // GET: Checkout
        public IActionResult Checkout()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            var cart = _context.Carts
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Products)
                    .FirstOrDefault(c => c.UserId == userid.Value);

            var viewModel = new CheckoutViewModel
            {
                Cart = cart,
                TotalPrice = (decimal)cart.CartItems.Sum(item => item.Products.Price * item.Quantity),
                ShippingAddress = new Address()
            };
            return View(viewModel);
        }

        /*     // POST : Checkout/ProcessOrder
             [HttpPost]
             [ValidateAntiForgeryToken]
             public IActionResult ProcessOrder(CheckoutViewModel viewModel)
             {
                 if (!ModelState.IsValid)
                 {
                     return View("Checkout", viewModel);
                 }
                 var order = new Order
                 {
                     UserId = (int)HttpContext.Session.GetInt32("userid"),
                     OrderDate = DateTime.Now,
                     ShippingAddress = viewModel.ShippingAddress
                 };
                 _context.Orders.Add(order);
                 _context.SaveChanges();


                 foreach(var cartItem in viewModel.Cart.CartItems)
                 {
                     var orderItem = new OrderItem
                     {
                         OrderID = order.OrderId,
                         ProductId = cartItem.Products.Id,
                         Quantity = (int)cartItem.Quantity,
                     };
                     _context.OrderItems.Add(orderItem);
                 }

                 _context.SaveChanges();

                 int userid = (int)HttpContext.Session.GetInt32("userid");
                 var cartItems = _context.Carts.Include(c=>c.CartItems)
                     .SingleOrDefault(c=>c.UserId== userid);
                 if (cartItems != null)
                 {
                     var userCartItems = cartItems.CartItems.ToList();
                     _context.CartItems.RemoveRange(userCartItems);
                     _context.SaveChanges();
                 }
                 return RedirectToAction("ProcessPayment",viewModel);
             }*/

        /// <summary>
        /// Process Payment handles payment and orders of the cart
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ProcessPayment(CheckoutViewModel viewModel)
        {
            // Process payment and update order status
            int userId = (int)HttpContext.Session.GetInt32("userid");
            Debug.WriteLine(userId);
            var userCart = _context.Carts
                    .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Products)
                    .FirstOrDefault(c => c.UserId == userId);
            Debug.WriteLine(userCart);

            // Example: Use a payment service to process the payment
            var paymentservice = new PaymentService();
            var paymentResult = paymentservice.ProcessPayment(viewModel.CardNumber, viewModel.ExpirationDate, viewModel.CVV);

            if (paymentResult.Success)
            {
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    ShippingAddress = viewModel.ShippingAddress,
                    OrderItems = new List<OrderItem>()
                };

                _context.Orders.Add(order);

                foreach (var cartItem in userCart.CartItems)
                {
                    Debug.WriteLine(cartItem);
                    var orderItem = new OrderItem
                    {
                        ProductId = cartItem.ProductsId,
                        Quantity = (int)cartItem.Quantity,
                        OrderID = order.OrderId

                    };
                    order.OrderItems.Add(orderItem);
                }

                _context.Orders.Add(order);
                _context.SaveChanges();
                
                return View("PaymentConfirmation", order);
            }
            else
            {
                // Payment failed, handle the error and display a message to the user
                ModelState.AddModelError(string.Empty, "Payment failed. Please check your payment information and try again.");
                return View("Checkout", viewModel);
            }
        }

       /* public IActionResult CreateOrder()
        {
            int userId = (int)HttpContext.Session.GetInt32("userid");
            // Fetch the BuyNow items for the current user
            var buyNowItems = _context.BuyNowItems
                .Include(buyNowItem => buyNowItem.Product)
                .Where(buyNowItem => buyNowItem.UserID == userId)
                .ToList();

            // Calculate the total price for the items in the BuyNow list
            decimal totalPrice = buyNowItems.Sum(buyNowItem => buyNowItem.Quantity * buyNowItem.ProductPrice);

            // Create an order record in the database
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                Total = totalPrice,
                ShippingAddress = new Address()
            };

            // Save the order to the database
            _context.Orders.Add(order);
            _context.BuyNowItems.RemoveRange(buyNowItems);
            _context.SaveChanges();
            return View("ProcessPayment",new {orderId = order.OrderId});
        }

        public IActionResult ProcessPaymentForBuyNow(int OrderId)
        {
            Payment payment = new Payment();
            var paymentservice = new PaymentService();
            var paymentResult = paymentservice.ProcessPayment(payment.CardNumber, payment.ExpiryYear, payment.CVV);
            if (paymentResult.Success)
            {
                // Update the order status to "Paid" or handle payment success as needed
                var order = _context.Orders.Find(OrderId);
                _context.SaveChanges();
                return RedirectToAction("OrderConfirmation", new { orderId = order.OrderId });
            }
            else
            {
                // Handle payment failure (e.g., display an error message)
                return RedirectToAction("PaymentFailure");
            }
        }*/
    }
}
