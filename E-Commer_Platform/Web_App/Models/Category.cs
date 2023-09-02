using System.ComponentModel.DataAnnotations;

namespace Web_App.Models
{
    public class Category
    {
        public Category() 
        {
            this.Subcategories = new HashSet<SubCategory>();
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int CategoryId { get; set; } 
        public string Name { get; set; }
        public Nullable<bool>isActive { get; set; }
        public virtual ICollection<SubCategory> Subcategories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
