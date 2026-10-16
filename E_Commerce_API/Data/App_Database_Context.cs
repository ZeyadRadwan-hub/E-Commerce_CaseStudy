using E_Commerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Data
{
    public class App_Database_Context:DbContext
    {
        public App_Database_Context(DbContextOptions<App_Database_Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().
                HasOne(x=>x.Category)
                .WithMany(x=>x.Products)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(x=>x.User)
                .WithMany(x=>x.Orders)
                .HasForeignKey(x=>x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
               .HasOne(x => x.Product)
               .WithMany(x => x.OrderItems)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Ahmed Hassan", Email = "ahmed@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 2, Name = "Mona Ali", Email = "mona@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 3, Name = "Omar Khaled", Email = "omar@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 4, Name = "Sara Mohamed", Email = "sara@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 5, Name = "Youssef Ali", Email = "youssef@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 6, Name = "Nour Ahmed", Email = "nour@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 7, Name = "Karim Samir", Email = "karim@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 8, Name = "Malak Hany", Email = "malak@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 9, Name = "Adam Tarek", Email = "adam@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 10, Name = "Jana Mostafa", Email = "jana@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 11, Name = "Ali Hassan", Email = "ali@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 12, Name = "Farida Amr", Email = "farida@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 13, Name = "Seif Ashraf", Email = "seif@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 14, Name = "Laila Adel", Email = "laila@example.com", Password = "Test123!", Role = "Customer" },
                new User { Id = 15, Name = "Store Admin", Email = "admin@example.com", Password = "Test123!", Role = "Admin" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices" },
                new Category { Id = 2, Name = "Books", Description = "Programming and technical books" },
                new Category { Id = 3, Name = "Accessories", Description = "Computer accessories" },
                new Category { Id = 4, Name = "Gaming", Description = "Gaming devices and accessories" },
                new Category { Id = 5, Name = "Computer Components", Description = "Internal computer components" },
                new Category { Id = 6, Name = "Office Supplies", Description = "Office and desk products" },
                new Category { Id = 7, Name = "Home Appliances", Description = "Appliances for home use" },
                new Category { Id = 8, Name = "Mobile Accessories", Description = "Mobile phone accessories" },
                new Category { Id = 9, Name = "Networking", Description = "Networking devices" },
                new Category { Id = 10, Name = "Storage", Description = "Storage devices" },
                new Category { Id = 11, Name = "Audio", Description = "Audio equipment" },
                new Category { Id = 12, Name = "Photography", Description = "Photography equipment" },
                new Category { Id = 13, Name = "Software", Description = "Software products" },
                new Category { Id = 14, Name = "Smart Home", Description = "Smart home devices" },
                new Category { Id = 15, Name = "Wearables", Description = "Wearable technology" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Wireless Mouse", Description = "Wireless computer mouse", Price = 450m, StockQuantity = 25, CategoryId = 1 },
                new Product { Id = 2, Name = "Headphones", Description = "Over-ear headphones", Price = 1200m, StockQuantity = 12, CategoryId = 1 },
                new Product { Id = 3, Name = "C++ Fundamentals", Description = "Introduction to C++ programming", Price = 350m, StockQuantity = 30, CategoryId = 2 },
                new Product { Id = 4, Name = "ASP.NET Core Guide", Description = "Guide to ASP.NET Core development", Price = 650m, StockQuantity = 18, CategoryId = 2 },
                new Product { Id = 5, Name = "Mechanical Keyboard", Description = "Mechanical USB keyboard", Price = 1800m, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 6, Name = "USB-C Hub", Description = "Multiport USB-C hub", Price = 750m, StockQuantity = 20, CategoryId = 3 },
                new Product { Id = 7, Name = "Monitor 24 inch", Description = "24-inch computer monitor", Price = 4200m, StockQuantity = 8, CategoryId = 1 },
                new Product { Id = 8, Name = "Phone Charger", Description = "Fast mobile phone charger", Price = 250m, StockQuantity = 40, CategoryId = 8 },
                new Product { Id = 9, Name = "SQL Server Guide", Description = "Database programming guide", Price = 800m, StockQuantity = 15, CategoryId = 2 },
                new Product { Id = 10, Name = "Gaming Controller", Description = "Wireless gaming controller", Price = 1600m, StockQuantity = 14, CategoryId = 4 },
                new Product { Id = 11, Name = "Laptop Stand", Description = "Adjustable laptop stand", Price = 550m, StockQuantity = 22, CategoryId = 6 },
                new Product { Id = 12, Name = "Microphone", Description = "USB recording microphone", Price = 2300m, StockQuantity = 9, CategoryId = 11 },
                new Product { Id = 13, Name = "SSD 1TB", Description = "One terabyte solid state drive", Price = 3200m, StockQuantity = 11, CategoryId = 10 },
                new Product { Id = 14, Name = "Bluetooth Speaker", Description = "Portable Bluetooth speaker", Price = 1100m, StockQuantity = 16, CategoryId = 11 },
                new Product { Id = 15, Name = "Ethernet Adapter", Description = "USB Ethernet network adapter", Price = 300m, StockQuantity = 28, CategoryId = 9 }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = new DateTime(2026, 10, 1), OrderStatus = "Completed", ToatalAmount = 900m, UserId = 1 },
                new Order { Id = 2, OrderDate = new DateTime(2026, 10, 2), OrderStatus = "Pending", ToatalAmount = 1200m, UserId = 2 },
                new Order { Id = 3, OrderDate = new DateTime(2026, 10, 3), OrderStatus = "Completed", ToatalAmount = 1050m, UserId = 3 },
                new Order { Id = 4, OrderDate = new DateTime(2026, 10, 4), OrderStatus = "Cancelled", ToatalAmount = 650m, UserId = 4 },
                new Order { Id = 5, OrderDate = new DateTime(2026, 10, 5), OrderStatus = "Completed", ToatalAmount = 1800m, UserId = 5 },
                new Order { Id = 6, OrderDate = new DateTime(2026, 10, 6), OrderStatus = "Pending", ToatalAmount = 1500m, UserId = 6 },
                new Order { Id = 7, OrderDate = new DateTime(2026, 10, 7), OrderStatus = "Completed", ToatalAmount = 4200m, UserId = 7 },
                new Order { Id = 8, OrderDate = new DateTime(2026, 10, 8), OrderStatus = "Completed", ToatalAmount = 250m, UserId = 8 },
                new Order { Id = 9, OrderDate = new DateTime(2026, 10, 9), OrderStatus = "Cancelled", ToatalAmount = 1600m, UserId = 9 },
                new Order { Id = 10, OrderDate = new DateTime(2026, 10, 10), OrderStatus = "Pending", ToatalAmount = 1600m, UserId = 10 },
                new Order { Id = 11, OrderDate = new DateTime(2026, 10, 11), OrderStatus = "Completed", ToatalAmount = 1650m, UserId = 11 },
                new Order { Id = 12, OrderDate = new DateTime(2026, 10, 12), OrderStatus = "Completed", ToatalAmount = 2300m, UserId = 12 },
                new Order { Id = 13, OrderDate = new DateTime(2026, 10, 13), OrderStatus = "Pending", ToatalAmount = 3200m, UserId = 13 },
                new Order { Id = 14, OrderDate = new DateTime(2026, 10, 14), OrderStatus = "Completed", ToatalAmount = 2200m, UserId = 14 },
                new Order { Id = 15, OrderDate = new DateTime(2026, 10, 15), OrderStatus = "Cancelled", ToatalAmount = 1200m, UserId = 1 }
            );

            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, Quantity = 2, UnitPrice = 450m, OrderId = 1, ProductId = 1 },
                new OrderItem { Id = 2, Quantity = 1, UnitPrice = 1200m, OrderId = 2, ProductId = 2 },
                new OrderItem { Id = 3, Quantity = 3, UnitPrice = 350m, OrderId = 3, ProductId = 3 },
                new OrderItem { Id = 4, Quantity = 1, UnitPrice = 650m, OrderId = 4, ProductId = 4 },
                new OrderItem { Id = 5, Quantity = 1, UnitPrice = 1800m, OrderId = 5, ProductId = 5 },
                new OrderItem { Id = 6, Quantity = 2, UnitPrice = 750m, OrderId = 6, ProductId = 6 },
                new OrderItem { Id = 7, Quantity = 1, UnitPrice = 4200m, OrderId = 7, ProductId = 7 },
                new OrderItem { Id = 8, Quantity = 1, UnitPrice = 250m, OrderId = 8, ProductId = 8 },
                new OrderItem { Id = 9, Quantity = 2, UnitPrice = 800m, OrderId = 9, ProductId = 9 },
                new OrderItem { Id = 10, Quantity = 1, UnitPrice = 1600m, OrderId = 10, ProductId = 10 },
                new OrderItem { Id = 11, Quantity = 3, UnitPrice = 550m, OrderId = 11, ProductId = 11 },
                new OrderItem { Id = 12, Quantity = 1, UnitPrice = 2300m, OrderId = 12, ProductId = 12 },
                new OrderItem { Id = 13, Quantity = 1, UnitPrice = 3200m, OrderId = 13, ProductId = 13 },
                new OrderItem { Id = 14, Quantity = 2, UnitPrice = 1100m, OrderId = 14, ProductId = 14 },
                new OrderItem { Id = 15, Quantity = 4, UnitPrice = 300m, OrderId = 15, ProductId = 15 }
            );

        }
    }
}
