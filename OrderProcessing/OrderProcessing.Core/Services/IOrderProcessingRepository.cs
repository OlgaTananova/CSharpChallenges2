

using OrderProcessing.Core.Models;

namespace OrderProcessing.Services;

public interface IOrderProcessingRepository
{
    List<string> GetMostPopularProducts(int topN);

    void CreateOrder(Order order);

    Task ProcessOrderAsync(Guid orderId);

    Task<List<Product>> GetProductsAsync();
    Task<Customer?> GetCustomerAsync(string name);
    Task<Order?> GetOrderAsync(Guid orderId);
    void PayOrder(Order order);

    Task SaveChangesAsync();

}
