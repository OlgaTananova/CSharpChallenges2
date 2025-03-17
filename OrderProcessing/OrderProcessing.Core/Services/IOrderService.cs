using OrderProcessing.Core.Events;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Services;

public interface IOrderService
{
    event EventHandler<OrderPlacedEvent> OrderPlaced;

    Task<int> OrderPlacedAsync(int customerId, List<Product> products);
}
