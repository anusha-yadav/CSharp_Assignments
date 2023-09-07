using ECommerceWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Web_App.Models;

namespace Web_App.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options) { }

        public DbSet<User>Users { get; set; }
        public DbSet<Address>Addresses { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get;set; }  
        public DbSet<SubCategory>SubCategories { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<OrderItems>OrdersItems { get; set; }
        public DbSet<Payment>Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }  
        public DbSet<Cart>Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
