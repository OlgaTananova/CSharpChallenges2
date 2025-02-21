

using OrderProcessing.Core.Models;
using OrderProcessing.Core.Services;

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

var service = new OrderProcessingService();