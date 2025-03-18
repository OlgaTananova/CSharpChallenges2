using Microsoft.EntityFrameworkCore;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Server=localhost:5432;Database=orderprocessing;Username=user;Password=user123");
        }

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Guid customer1 = Guid.NewGuid();
        Guid customer2 = Guid.NewGuid();
        Guid customer3 = Guid.NewGuid();
        Guid customer4 = Guid.NewGuid();
        Guid customer5 = Guid.NewGuid();

        modelBuilder.Entity<Customer>()
        .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(i => i.Order)
            .WithMany(o => o.Items)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
            .HasIndex(i => i.ProductName)
            .IsUnique();


        modelBuilder.Entity<Customer>().HasData(
                   new Customer { Id = customer1, Name = "Alice" },
                   new Customer { Id = customer2, Name = "Bob" },
                   new Customer { Id = customer3, Name = "Jack" },
                   new Customer { Id = customer4, Name = "Natalie" },
                   new Customer { Id = customer5, Name = "John" }
               );

        Guid order1 = Guid.NewGuid();
        Guid order2 = Guid.NewGuid();
        Guid order3 = Guid.NewGuid();
        Guid order4 = Guid.NewGuid();
        Guid order5 = Guid.NewGuid();
        Guid order6 = Guid.NewGuid();

        modelBuilder.Entity<Order>().HasData(
                new Order { Id = order1, CustomerId = customer1, OrderDate = DateTime.UtcNow.AddDays(-5), IsPaid = true },
                new Order { Id = order2, CustomerId = customer2, OrderDate = DateTime.UtcNow.AddDays(-10), IsPaid = true },
                new Order { Id = order3, CustomerId = customer3, OrderDate = DateTime.UtcNow.AddDays(-1), IsPaid = false },
                new Order { Id = order4, CustomerId = customer4, OrderDate = DateTime.UtcNow.AddDays(-3), IsPaid = false },
                new Order { Id = order5, CustomerId = customer5, OrderDate = DateTime.UtcNow.AddDays(0), IsPaid = false }
            );

        Guid product1 = Guid.NewGuid();
        Guid product2 = Guid.NewGuid();
        Guid product3 = Guid.NewGuid();
        Guid product4 = Guid.NewGuid();
        Guid product5 = Guid.NewGuid();

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = product1, ProductName = "Laptop", BasePrice = 1200, Stock = 100 },
            new Product { Id = product2, ProductName = "Tablet", BasePrice = 700, Stock = 80 },
            new Product { Id = product3, ProductName = "Display", BasePrice = 800, Stock = 50 },
            new Product { Id = product4, ProductName = "Mouse", BasePrice = 50, Stock = 40 }
        );

        Guid orderItem1 = Guid.NewGuid();
        Guid orderItem2 = Guid.NewGuid();
        Guid orderItem3 = Guid.NewGuid();
        Guid orderItem4 = Guid.NewGuid();
        Guid orderItem5 = Guid.NewGuid();
        Guid orderItem6 = Guid.NewGuid();

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = orderItem1, OrderId = order1, ProductId = product1, Quantity = 20, Price = 1200 },
            new OrderItem { Id = orderItem2, OrderId = order2, ProductId = product2, Quantity = 10, Price = 700 },
            new OrderItem { Id = orderItem3, OrderId = order2, ProductId = product3, Quantity = 2, Price = 800 },
            new OrderItem { Id = orderItem4, OrderId = order3, ProductId = product1, Quantity = 3, Price = 1200 },
            new OrderItem { Id = orderItem5, OrderId = order4, ProductId = product4, Quantity = 10, Price = 50 },
            new OrderItem { Id = orderItem6, OrderId = order5, ProductId = product3, Quantity = 5, Price = 800 }
        );
    }
}
