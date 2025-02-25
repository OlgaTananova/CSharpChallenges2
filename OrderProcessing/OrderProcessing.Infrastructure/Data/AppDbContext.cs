using Microsoft.EntityFrameworkCore;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

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

        modelBuilder.Entity<Customer>().HasData(
                   new Customer { Id = 1, Name = "Alice" },
                   new Customer { Id = 2, Name = "Bob" },
                   new Customer { Id = 3, Name = "Jack" }
               );
        modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-5), IsPaid = true },
                new Order { Id = 2, CustomerId = 2, OrderDate = DateTime.Now.AddDays(-10), IsPaid = true },
                new Order { Id = 3, CustomerId = 3, OrderDate = DateTime.Now.AddDays(-1), IsPaid = false }
            );

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = 1, OrderId = 1, ProductName = "Laptop", Quantity = 1, Price = 1200 },
            new OrderItem { Id = 2, OrderId = 2, ProductName = "Tablet", Quantity = 1, Price = 700 },
            new OrderItem { Id = 3, OrderId = 2, ProductName = "Display", Quantity = 1, Price = 800 },
            new OrderItem { Id = 4, OrderId = 3, ProductName = "Laptop", Quantity = 3, Price = 1200 }
        );
    }
}
