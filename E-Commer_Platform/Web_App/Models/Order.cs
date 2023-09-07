using System.ComponentModel.DataAnnotations;

namespace Web_App.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItems>();
        }

        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<int>Taxes { get; set; }
        public Nullable<int> AddressID { get; set; }
        public virtual User User { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
