namespace E_Commerce_WebApplication.Models
{
    public class Order
    {
        public int OrderId { get; set; }    
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; } 
        public OrderStatus Status { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal TaxFee { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentTransactionID { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
