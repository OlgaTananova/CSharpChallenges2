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
                   new Customer { Id = 1, Name = "Alice" },
                   new Customer { Id = 2, Name = "Bob" },
                   new Customer { Id = 3, Name = "Jack" },
                   new Customer { Id = 4, Name = "Natalie" },
                   new Customer { Id = 5, Name = "John" }
               );
        modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.UtcNow.AddDays(-5), IsPaid = true },
                new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.UtcNow.AddDays(-10), IsPaid = true },
                new Order { Id = 3, CustomerId = 3, OrderDate = DateTime.UtcNow.AddDays(-1), IsPaid = false },
                new Order { Id = 4, CustomerId = 4, OrderDate = DateTime.UtcNow.AddDays(-3), IsPaid = false },
                new Order { Id = 5, CustomerId = 5, OrderDate = DateTime.UtcNow.AddDays(0), IsPaid = false }
            );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, ProductName = "Laptop", BasePrice = 1200, Stock = 100 },
            new Product { Id = 2, ProductName = "Tablet", BasePrice = 700, Stock = 80 },
            new Product { Id = 3, ProductName = "Display", BasePrice = 800, Stock = 50 },
            new Product { Id = 4, ProductName = "Mouse", BasePrice = 50, Stock = 40 }
        );

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 20, Price = 1200 },
            new OrderItem { Id = 2, OrderId = 2, ProductId = 2, Quantity = 10, Price = 700 },
            new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Quantity = 2, Price = 800 },
            new OrderItem { Id = 4, OrderId = 3, ProductId = 1, Quantity = 3, Price = 1200 },
            new OrderItem { Id = 5, OrderId = 4, ProductId = 4, Quantity = 10, Price = 50 },
            new OrderItem { Id = 6, OrderId = 5, ProductId = 3, Quantity = 5, Price = 800 }
        );
    }
}
