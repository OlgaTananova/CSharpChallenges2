using System;
using OrderProcessing.Core.Models;
using OrderProcessing.Core.Services;
using Xunit.Sdk;

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
            new Customer { Id = 2, Name = "Bob", Orders = new List<Order>() }, // No ordersnew 
            new Customer
            {
                Id = 3, Name = "Jack",
                Orders = new List<Order>
                {
                    new Order
                    {
                        Id=102, CustomerId = 3, OrderDate = DateTime.Now.AddDays(-3), IsPaid = true,
                        Items = new List<OrderItem>
                        {
                            new OrderItem { Id = 3, ProductName = "Computer", Quantity = 1, Price = 800}
                        }
                    }
                }
            },
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
        Assert.Equal("Bob", result[0].Name);
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

    [Fact]
    public void GetRecentOrders_ShouldReturnTwo()
    {
        // Arrange

        //Act 
        var result = _service.GetRecentOrders(_customers, 7);

        Assert.Equal(2, result.Count);
        Assert.Equal(101, result[0].Id);
    }

    [Fact]
    public void GetRecentOrders_ShouldReturnEmpty()
    {
        // Arrange

        //Act 
        var result = _service.GetRecentOrders(_customers, 2);

        Assert.Empty(result);
    }

    [Fact]
    public void GetTopCustomersBySpending_ShouldReturnOne()
    {
        //Act
        var result = _service.GetTopCustomersBySpending(_customers, 1);

        Assert.Single(result);
        Assert.Equal("Alice", result[0].Name);
    }

    [Fact]

    public void GetTotalSalesPerCustomer_ShouldReturnNotEmpty()
    {
        //Act
        var result = _service.GetTotalSalesPerCustomer(_customers);

        Assert.NotEmpty(result);
        Assert.Equal(1050, result.GetValueOrDefault("Alice"));
    }

    [Fact]
    public void GetCustomersBySpendingWithTotalSum_ShouldReturnNotEmpty()
    {
        var result = _service.GetCustomersBySpendingWithTotalSum(_customers, 1);

        Assert.NotEmpty(result);
        Assert.Equal("Alice", result[0].Item1);
        Assert.Equal(1050, result[0].Item2);
    }

    [Fact]
    public void GetCustomersBySpendingWithTotalSum_ShouldReturnOne()
    {
        //Arrange 
        DateTime startDate = DateTime.Now.AddDays(-4);
        DateTime endDate = DateTime.Now;

        // Act

        var result = _service.GetCustomersBySpendingWithTotalSum(_customers, 2, startDate, endDate);

        // Assert 

        Assert.Single(result);
        Assert.Equal("Jack", result[0].Item1);
        Assert.Equal(800, result[0].Item2);

    }

    [Fact]
    public void GetCustomersWithDiscount_ShouldReturnTwo()
    {
        var result = _service.GetCustomersWithDiscount(_customers);

        // Assert 

        Assert.Equal(945, result[0].DiscountedTotal);
        Assert.Equal(760, result[1].DiscountedTotal);
    }


}
