using System.ComponentModel.DataAnnotations;

namespace Web_App.Models
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsID { get; set; }
        public int OrderID {  get; set; }
        public int ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }  
        public Nullable<decimal> TotalAmount { get;set; }
    }
}
