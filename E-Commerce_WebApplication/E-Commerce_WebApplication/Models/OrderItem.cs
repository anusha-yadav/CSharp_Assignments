namespace E_Commerce_WebApplication.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal SubTotal { get; set; }   
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }    
        public virtual Products Product { get; set; }
    }
}
