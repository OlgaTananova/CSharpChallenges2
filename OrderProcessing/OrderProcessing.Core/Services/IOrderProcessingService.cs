using System;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Services;

public interface IOrderProcessingService
{
    public List<Customer> GetTopCustomersBySpending(List<Customer> customers, int topN);
    public List<string> GetMostPopularProducts(List<Customer> customers, int topN);

    public List<Order> GetRecentOrders(List<Customer> customers, int days);
    public List<Customer> GetCustomersWithNoOrders(List<Customer> customers);
    public List<(string, decimal)> GetCustomersBySpendingWithTotalSum(List<Customer> customers, int topN);
    public List<(string, decimal)> GetCustomersBySpendingWithTotalSum(List<Customer> customers, int topN, DateTime startDate, DateTime endDate);

    public List<(string CustomerName, decimal TotalSpending, decimal DiscountedTotal)> GetCustomersWithDiscount(List<Customer> customers);

    public Dictionary<string, List<(string CustomerName, decimal TotalSpending)>> GroupCustomersBySpendingBrackets(List<Customer> customers);

    public List<(string CustomerName, decimal TotalSpending, int OrderCount)> GetCustomersWithTotalSpendingAndOrderCounts(List<Customer> customers);

    public List<(string, decimal, int)> GetCustomersWithTotalSpendingByPages(List<Customer> customers, int pageNumber, int pageSize);
}
