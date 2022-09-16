using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using PizzaHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace PizzaHub.Repositories
{
    public class AppDbContext : IdentityDbContext<User,Role,int>
    {
        //needed for migration
        public AppDbContext()
        {

        }
        //Configuration from Setting
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"data source=DESKTOP-GAFGV3S\\SQLEXPRESS01; initial catalog=PizzaHubSite;integrated security=True;");
                optionsBuilder.UseSqlServer(@"data source=DESKTOP-GAFGV3S\SQLEXPRESS01; initial catalog=PizzaHubSite;persist security info=True;user id=virendrapanpatil;password=Viren@1998;");

            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
