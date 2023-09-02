using System.ComponentModel.DataAnnotations;

namespace Web_App.Models
{
    public class Payment
    {
        public Payment()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int PaymentID { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
    }
}
