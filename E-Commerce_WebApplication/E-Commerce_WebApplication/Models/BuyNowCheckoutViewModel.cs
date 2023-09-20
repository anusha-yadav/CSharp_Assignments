namespace E_Commerce_WebApplication.Models
{
    public class BuyNowCheckoutViewModel
    {
        public int Id { get; set; }
        public Address ShippingAddress { get; set; }
        public BuyNowViewModel BuyNowItem { get; set; }
    }
}
