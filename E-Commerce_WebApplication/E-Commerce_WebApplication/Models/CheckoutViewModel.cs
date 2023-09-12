namespace E_Commerce_WebApplication.Models
{
    public class CheckoutViewModel
    {
        public Cart Cart { get; set; }
        public decimal TotalPrice { get; set; }

        // Shipping information
        public Address Address { get; set; }

        // Payment method
        public PaymentMethod PaymentMethod { get; set; }
    }
}
