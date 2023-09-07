using Web_App.Models;

namespace ECommerceWebApplication.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<CartItem>CartItems { get; set;} 
    }
}
