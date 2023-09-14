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

        [HttpPost]
        public IActionResult PaymentDetails()
        {
            // Display the payment details form
            return View("PaymentDetails");
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


/*        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessPayment(CheckoutViewModel viewModel)
        {
            PaymentService _paymentService = new PaymentService();
            switch(viewModel.SelectedPaymentOption) 
            {
                case PaymentMethod.CreditCard:
                    bool creditCardPaymentSuccess = _paymentService.ProcessCreditPayment(viewModel.CardNumber, viewModel.ExpirationDate, viewModel.CVV);
                    if (!creditCardPaymentSuccess)
                    {
                        ModelState.AddModelError(string.Empty, "Credit card payment failed.");
                        return View("Index", viewModel);
                    }
                    break;
                case PaymentMethod.PayPal:
                    bool paypalPaymentSuccess = _paymentService.ProcessPayPalPayment(viewModel.PayPalEmail);
                    if (!paypalPaymentSuccess)
                    {
                        ModelState.AddModelError(string.Empty, "PayPal payment failed.");
                        return View("Index", viewModel);
                    }
                    break;
                case PaymentMethod.CashOnDelivery:

                    break;
                default:
                    ModelState.AddModelError(string.Empty, "Invalid payment option selected.");
                    return View("Index", viewModel);
            }
            return RedirectToAction("OrderConfirmed");
        }*/
    }
}
