using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderCraftPro.Models;
using OrderCraftPro.Enums;

namespace OrderCraftPro.Data
{
    public class OrderCraftProDbContext : IdentityDbContext<ApplicationUser>
    {
        public OrderCraftProDbContext(DbContextOptions<OrderCraftProDbContext> options) : base(options)
        {
        }

        // DbSet for Identity related entities if needed
        // DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Remove the AspNet prefix from the table names
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Product)
                .WithMany()
                .HasForeignKey(ol => ol.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderLines)
                .WithOne(ol => ol.Order)
                .HasForeignKey(ol => ol.OrderId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderType)
                .WithMany()
                .HasForeignKey(o => o.TypeId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany()
                .HasForeignKey(o => o.StatusId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // Seed data
            SeedData(modelBuilder);
            //SeedCustomers(modelBuilder);
            //SeedOrders(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedProducts(modelBuilder);
        }

        private void SeedProducts(ModelBuilder modelBuilder)
        {
            var productTypes = new[]
            {
                new ProductType { Id = Guid.NewGuid(), TypeName = ProductType.Apparel },
                new ProductType { Id = Guid.NewGuid(), TypeName = ProductType.Parts },
                new ProductType { Id = Guid.NewGuid(), TypeName = ProductType.Equipment },
                new ProductType { Id = Guid.NewGuid(), TypeName = ProductType.Motor }
            };

            modelBuilder.Entity<ProductType>().HasData(productTypes);

            var products = new[]
            {
                new { Id = Guid.NewGuid(), ProductName = "Laptop", Price = 999.99m, ProductCode = "LP001", ProductTypeId = productTypes[0].Id },
                new { Id = Guid.NewGuid(), ProductName = "Smartphone", Price = 599.99m, ProductCode = "SP002", ProductTypeId = productTypes[2].Id },
                new { Id = Guid.NewGuid(), ProductName = "Headphones", Price = 99.99m, ProductCode = "HP003", ProductTypeId = productTypes[2].Id },
                new { Id = Guid.NewGuid(), ProductName = "Wireless Mouse", Price = 29.99m, ProductCode = "WM004", ProductTypeId = productTypes[1].Id },
                new { Id = Guid.NewGuid(), ProductName = "External Hard Drive", Price = 149.99m, ProductCode = "EHD005", ProductTypeId = productTypes[2].Id },
                new { Id = Guid.NewGuid(), ProductName = "Bluetooth Speaker", Price = 79.99m, ProductCode = "BS006", ProductTypeId = productTypes[3].Id }
            };

            modelBuilder.Entity<Product>().HasData(products);

            var productIds = products.Select(p => p.Id).ToList();
            SeedCustomersAndOrders(modelBuilder, productIds);
        }

        private void SeedCustomersAndOrders(ModelBuilder modelBuilder, List<Guid> productIds)
        {
            var customers = new[]
            {
                new Customer { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john@example.com", Phone = "1234567890", Address = "123 Main St" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Phone = "9876543210", Address = "456 Oak St" },
                new Customer { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Johnson", Email = "michael@example.com", Phone = "5551234567", Address = "789 Elm St" }
            };

            modelBuilder.Entity<Customer>().HasData(customers);

            var orderStatuses = new[]
            {
                new OrderStatus { Id = Guid.NewGuid(), StatusName = OrderStatus.New },
                new OrderStatus { Id = Guid.NewGuid(), StatusName = OrderStatus.Processing },
                new OrderStatus { Id = Guid.NewGuid(), StatusName = OrderStatus.Completed }
            };

            modelBuilder.Entity<OrderStatus>().HasData(orderStatuses);

            var orderTypes = new[]
            {
                new OrderType { Id = Guid.NewGuid(), TypeName = OrderType.Normal },
                new OrderType { Id = Guid.NewGuid(), TypeName = OrderType.Staff },
                new OrderType { Id = Guid.NewGuid(), TypeName = OrderType.Mechanical },
                new OrderType { Id = Guid.NewGuid(), TypeName = OrderType.Perishable }
            };

            modelBuilder.Entity<OrderType>().HasData(orderTypes);

            var orders = new[]
            {
                new
                {
                    Id = Guid.NewGuid(),
                    OrderNumber = "ORD001",
                    OrderPlaced = DateTime.UtcNow,
                    TypeId = orderTypes[0].Id,
                    StatusId = orderStatuses[0].Id,
                    CustomerId = customers[0].Id
                },
                new
                {
                    Id = Guid.NewGuid(),
                    OrderNumber = "ORD002",
                    OrderPlaced = DateTime.UtcNow,
                    TypeId = orderTypes[1].Id,
                    StatusId = orderStatuses[2].Id,
                    CustomerId = customers[1].Id
                },
                new
                {
                    Id = Guid.NewGuid(),
                    OrderNumber = "ORD003",
                    OrderPlaced = DateTime.UtcNow,
                    TypeId = orderTypes[1].Id,
                    StatusId = orderStatuses[2].Id,
                    CustomerId = customers[2].Id
                }
            };

            modelBuilder.Entity<Order>().HasData(orders);

            // Retrieve the existing OrderIds
            var orderIds = orders.Select(o => o.Id).ToList();

            var orderLines = new[]
            {
                new OrderLine
                {
                    LineNumber = 1,
                    Quantity = 2,
                    ProductId = productIds[0],
                    OrderId = orderIds[0],
                    CostPrice = 10.00m,
                    SalesPrice = 15.00m,
                    OrderDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                },
                new OrderLine
                {
                    LineNumber = 2,
                    Quantity = 3,
                    ProductId = productIds[1],
                    OrderId = orderIds[1],
                    CostPrice = 8.00m,
                    SalesPrice = 12.00m,
                    OrderDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                },
                new OrderLine
                {
                    LineNumber = 3,
                    Quantity = 1,
                    ProductId = productIds[3],
                    OrderId = orderIds[2],
                    CostPrice = 15.00m,
                    SalesPrice = 20.00m,
                    OrderDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                }
            };

            modelBuilder.Entity<OrderLine>().HasData(orderLines);
        }
    }
}
