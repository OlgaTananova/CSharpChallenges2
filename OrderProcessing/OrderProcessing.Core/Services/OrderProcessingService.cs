using System;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Services;

public class OrderProcessingService: IOrderProcessingService
{
    public List<Customer> GetCustomersWithNoOrders(List<Customer> customers)
    {
        return customers.Where(c => c.Orders.Count == 0).ToList();
    }

    public List<string> GetMostPopularProducts(List<Customer> customers, int topN)
    {
        return customers
            .SelectMany(c => c.Orders)
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName)
            .OrderByDescending(p => p.Sum(p => p.Quantity))
            .Take(topN)
            .Select(g=> g.Key)
            .ToList();

    }

    public List<Order> GetRecentOrders(List<Customer> customers, int days)
    {
        throw new NotImplementedException();
    }

    public List<Customer> GetTopCustomersBySpending(List<Customer> customers, int topN)
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, decimal> GetTotalSalesPerCustomer(List<Customer> customers) {
        throw new NotImplementedException();
    }
}
