using OrderProcessing.Core.Events;
using OrderProcessing.Core.Models;
using OrderProcessing.Services;

namespace OrderProcessing.Core.Services;

public class OrderService : IOrderService
{
    private readonly IOrderProcessingRepository _repo;
    public event EventHandler<OrderPlacedEvent> OrderPlaced;

    public OrderService(IOrderProcessingRepository repository)
    {
        _repo = repository;
    }

    public Task<int> OrderPlacedAsync(int customerId, List<Product> products)
    {
        //OrderPlaced?.Invoke(this, new OrderPlacedEvent(order.Id, customerId, order.Items.Sum(i => i.Quantity * i.Price)))
        throw new NotImplementedException();

    }

}
