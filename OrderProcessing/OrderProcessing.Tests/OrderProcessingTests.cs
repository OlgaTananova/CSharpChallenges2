using System;
using OrderProcessing.Core.Models;
using OrderProcessing.Core.Services;

namespace OrderProcessing.Tests;

public class OrderProcessingTests
{
    private readonly OrderProcessingService _service;
    private readonly List<Customer> _customers;

    public OrderProcessingTests()
    {
        _service = new OrderProcessingService();
        _customers = SeedDataToService();
    }

    private List<Customer> SeedDataToService()
    {
        var customers = new List<Customer>
        {
            new Customer
            {
                Id = 1, Name = "Alice",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Id = 101, CustomerId = 1, OrderDate = DateTime.Now.AddDays(-5), IsPaid = true,
                        Items = new List<OrderItem>
                        {
                            new OrderItem { Id = 1, ProductName = "Laptop", Quantity = 1, Price = 1000 },
                            new OrderItem { Id = 2, ProductName = "Mouse", Quantity = 2, Price = 25 }
                        }
                    }
                }
            },
            new Customer { Id = 2, Name = "Bob", Orders = new List<Order>() } // No orders
        };
        return customers;
    }

    [Fact]
    public void GetCustomersWithNoOrders_ShouldReturnEmptyList()
    {
        //Arrange

        //Act 
        var result = _service.GetCustomersWithNoOrders(_customers);

        //Assert
        Assert.Single(result);
        Assert.Equal("Alice", result[0].Name);
    }

    [Fact]
    public void GetMostPopularProducts_ShouldReturnOne()
    {
        // Arrange

        //Act 
        var result = _service.GetMostPopularProducts(_customers, 1);

        //Assert
        Assert.Single(result);
        Assert.Equal("Mouse", result[0]);

    }
}
