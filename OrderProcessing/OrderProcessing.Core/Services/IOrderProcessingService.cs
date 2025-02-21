using System;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Services;

public interface IOrderProcessingService
{
    public List<Customer> GetTopCustomersBySpending(List<Customer> customers, int topN);
    public List<string> GetMostPopularProducts(List<Customer> customers, int topN);

    public List<Order> GetRecentOrders(List<Customer> customers, int days);
    public List<Customer> GetCustomersWithNoOrders(List<Customer> customers);

}
