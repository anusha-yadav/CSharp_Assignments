using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_App.Models
{
    public class Product
    {
        public Product()
        {
            this.OrderItems = new HashSet<OrderItems>();
            this.Reviews = new HashSet<Review>();
        }

        public int ProductID { get; set; }
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string PicturePath { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual Category Category { get; set; }
        public virtual SubCategory SubCategory { get; set; } 
        public virtual ICollection<Review> Reviews { get; set;}
        public virtual ICollection<OrderItems> OrderItems { get; set;}
    }
}
