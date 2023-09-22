using E_Commerce_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using E_Commerce_WebApplication.Data;
using System.Diagnostics;
using E_Commerce_WebApplication.Repositories;

namespace E_Commerce_WebApplication.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ECommerceContext _context;
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IOrderRepository _orderRepository;


        public CheckoutController(ICheckoutRepository checkoutRepository,IOrderRepository orderRepository)
        {
            _checkoutRepository = checkoutRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Checkout
        public IActionResult Checkout()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
         
            Cart cart = _checkoutRepository.GetCart(userid.Value);

            var viewModel = new CheckoutViewModel
            {
                Cart = cart,
                TotalPrice = (decimal)cart.CartItems.Sum(item => item.Products.Price * item.Quantity),
                ShippingAddress = new Address()
            };
            return View(viewModel);
        }

        public IActionResult BuyNowCheckout(int productId,int userid)
        {
            int? userId = HttpContext.Session.GetInt32("userid");
            if (userId.Value == userid)
            {       
                BuyNowViewModel buyNowItem = _checkoutRepository.GetBuyNowItemForCheckout(productId, userId.Value);
                var model = new BuyNowCheckoutViewModel
                {
                    ShippingAddress = new Address(),
                    BuyNowItem = buyNowItem,
                };

                //_context.SaveChanges();
                return View(model);
            }
            return NotFound();
        }

        public IActionResult BuyNowPayment(Payment model)
        {
            return View(model);
        }

        public IActionResult BuyNowOrderConfirmation()
        {
            int? userid = HttpContext.Session.GetInt32("userid");
            if(userid.HasValue)
            {

                BuyNowViewModel buyNowItem = _checkoutRepository.GetItemOfUser(userid.Value);

                if (buyNowItem != null)
                {
                    Order order = _orderRepository.CreateOrder(buyNowItem);
                    return View(@"Views/Checkout/BuyNowOrderConfirmation.cshtml",order);
                }
            }
            return NotFound();
        }

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
          
            Cart userCart = _checkoutRepository.GetCart(userId);

            // Example: Use a payment service to process the payment
            var paymentservice = new PaymentService();
            var paymentResult = paymentservice.ProcessPayment(viewModel.CardNumber, viewModel.ExpirationDate, viewModel.CVV);

            if (paymentResult.Success)
            {
                Order order = _orderRepository.CreateOrderForAddCart(viewModel,userId,userCart);
                return View("PaymentConfirmation", order);
            }
            else
            {
                // Payment failed, handle the error and display a message to the user
                ModelState.AddModelError(string.Empty, "Payment failed. Please check your payment information and try again.");
                return View("Checkout", viewModel);
            }
        }
    }
}
