using System.ComponentModel.DataAnnotations;

namespace Web_App.Models
{
    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.Reviews = new HashSet<Review>();    
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Username")]
        public string username { get; set; }
        [Required]
        [Display(Name="Password")]
        public string password { get; set; }
        [Required]
        [Display(Name="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name="PhoneNumber")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
