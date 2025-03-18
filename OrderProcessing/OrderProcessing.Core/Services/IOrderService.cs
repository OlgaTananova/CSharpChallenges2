using OrderProcessing.Core.Events;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Core.Services;

public interface IOrderService
{
    event EventHandler<OrderPlacedEvent> OrderPlaced;
    event EventHandler<OrderPaidEvent> OrderPaid;

    Task<Guid> OrderPlacedAsync(Guid customerId, List<Product> products);
    Task<Guid?> OrderPaidAsync(Guid orderId);
}
