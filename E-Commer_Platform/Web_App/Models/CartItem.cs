using Web_App.Models;

namespace ECommerceWebApplication.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public int CartID { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
