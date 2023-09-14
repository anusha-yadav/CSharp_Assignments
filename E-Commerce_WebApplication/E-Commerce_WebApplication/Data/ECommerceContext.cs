﻿using E_Commerce_WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebApplication.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions options) : base(options) { }
        public DbSet<Users>Users { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<SubCategory>SubCategories { get; set; }
        public DbSet<Products>Products { get; set; }
        public DbSet<Cart>Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem>OrderItems { get; set; }
    }
}
