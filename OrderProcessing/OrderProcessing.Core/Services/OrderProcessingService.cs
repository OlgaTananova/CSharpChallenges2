using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Services;

public class OrderProcessingService : IOrderProcessingService
{
    public List<(string CustomerName, decimal TotalSpending, decimal DiscountedTotal)> GetCustomersWithDiscount(List<Customer> customers)
    {
        return customers
                .Select(c =>
                {

                    decimal totalSpending = c.Orders
                        .Where(o => o.IsPaid)
                        .SelectMany(o => o.Items)
                        .Sum(i => i.Price * i.Quantity);

                    decimal discount = totalSpending >= 1000 ? 0.10m :
                                       totalSpending >= 500 ? 0.05m :
                                       0.00m;
                    decimal discountedTotal = totalSpending * (1 - discount);

                    return (c.Name, totalSpending, discountedTotal);

                })
                .Where(c => c.totalSpending > 0)
                .OrderByDescending(c => c.totalSpending)
                .ToList();
    }

    public List<(string, decimal)> GetCustomersBySpendingWithTotalSum(List<Customer> customers, int topN)
    {
        return customers
                  .Where(c => c.Orders.Any(o => o.IsPaid)) // selects only paid orders
                  .Select(c => ( // project customers to a tuple with its name and total sum of its orders
                      c.Name, // name
                      c.Orders
                          .SelectMany(o => o.Items)
                          .Sum(i => i.Quantity * i.Price) // returns a sum of all orders
                  ))
                  .OrderByDescending(c => c.Item2) // order by the sum
                  .Take(topN) // take topN
                  .ToList();
    }

    public List<(string, decimal)> GetCustomersBySpendingWithTotalSum(List<Customer> customers, int topN, DateTime startDate, DateTime endDate)
    {
        return customers
                 .Where(c => c.Orders.Any(o => o.IsPaid)) // selects only paid orders
                 .Select(c => ( // project customers to a tuple with its name and total sum of its orders
                     c.Name, // name
                     c.Orders
                         .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate) // select order within the certain period
                         .SelectMany(o => o.Items)
                         .Sum(i => i.Quantity * i.Price) // returns a sum of all orders
                 ))
                 .Where(c => c.Item2 > 0) // Filter out customers with 0 sum
                 .OrderByDescending(c => c.Item2) // order by the sum
                 .Take(topN) // take topN
                 .ToList();
    }

    public List<Customer> GetCustomersWithNoOrders(List<Customer> customers)
    {
        return customers.Where(c => c.Orders.Count == 0).ToList();
    }

    public List<Guid> GetMostPopularProducts(List<Customer> customers, int topN)
    {
        return customers
            .SelectMany(c => c.Orders)
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductId)
            .OrderByDescending(p => p.Sum(p => p.Quantity))
            .Take(topN)
            .Select(g => g.Key)
            .ToList();

    }

    public List<Order> GetRecentOrders(List<Customer> customers, int days)
    {
        DateTime thresholdDate = DateTime.Now.AddDays(-days);

        return customers.SelectMany(o => o.Orders.Where(or => or.OrderDate > thresholdDate)).ToList();
    }

    public List<Customer> GetTopCustomersBySpending(List<Customer> customers, int topN)
    {
        return customers
                .Where(c => c.Orders.Any(o => o.IsPaid))
                .OrderByDescending(c => c.Orders
                    .Where(o => o.IsPaid)
                    .SelectMany(o => o.Items)
                    .Sum(i => i.Price * i.Quantity))
                .Take(topN)
                .ToList();
    }

    public Dictionary<string, decimal> GetTotalSalesPerCustomer(List<Customer> customers)
    {
        return customers
            .Where(c => c.Orders.Any(o => o.IsPaid))
            .ToDictionary
            (c => c.Name,
                c => c.Orders
                .Where(o => o.IsPaid)
                .SelectMany(o => o.Items)
                .Sum(i => i.Quantity * i.Price));

    }

    public Dictionary<string, List<(string CustomerName, decimal TotalSpending)>> GroupCustomersBySpendingBrackets(List<Customer> customers)
    {
        return customers
                 .Select(c =>
                 {
                     var totalSpending = c.Orders
                                             .Where(o => o.IsPaid)
                                             .SelectMany(o => o.Items)
                                             .Sum(i => i.Quantity * i.Price);
                     var bracket = totalSpending >= 1000 ? "Premium" :
                                     totalSpending >= 500 ? "Gold" :
                                     totalSpending > 0 ? "Regular" : "None";
                     return new
                     {
                         Bracket = bracket,
                         Customer = (c.Name, totalSpending)

                     };
                 })
                 .Where(c => c.Bracket != "None")
                 .GroupBy(c => c.Bracket)
                 .ToDictionary(g => g.Key, g => g.Select(c => c.Customer).ToList());
    }

    public List<(string CustomerName, decimal TotalSpending, int OrderCount)> GetCustomersWithTotalSpendingAndOrderCounts(List<Customer> customers)
    {
        return customers
                    .Select(c =>
                    {
                        var totalSpending = c.Orders
                                                .Where(o => o.IsPaid)
                                                .SelectMany(o => o.Items)
                                                .Sum(i => i.Quantity * i.Price);
                        var orderCount = c.Orders
                                                .Where(o => o.IsPaid)
                                                .Count();
                        return (c.Name, totalSpending, orderCount);
                    }).ToList();
    }

    public List<(string CustomerName, decimal TotalSpending, int OrderCount)> GetCustomersWithTotalSpendingByPages(List<Customer> customers, int pageNumber, int pageSize)
    {
        return customers
                    .Select(c =>
                    {
                        var totalSpending = c.Orders
                                                .Where(o => o.IsPaid)
                                                .SelectMany(o => o.Items)
                                                .Sum(i => i.Quantity * i.Price);
                        var orderCount = c.Orders
                                                .Where(o => o.IsPaid)
                                                .Count();
                        return (c.Name, totalSpending, orderCount);
                    })
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

    }

}
