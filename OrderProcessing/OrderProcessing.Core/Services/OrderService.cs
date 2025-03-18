using OrderProcessing.Core.Events;
using OrderProcessing.Core.Models;
using OrderProcessing.Services;

namespace OrderProcessing.Core.Services;

public class OrderService : IOrderService
{
    private readonly IOrderProcessingRepository _repo;
    public event EventHandler<OrderPlacedEvent> OrderPlaced;
    public event EventHandler<OrderPaidEvent> OrderPaid;

    public OrderService(IOrderProcessingRepository repository)
    {
        _repo = repository;
    }

    public async Task<Guid> OrderPlacedAsync(Guid customerId, List<Product> products)
    {
        Guid orderId = Guid.NewGuid();

        Order newOrder = new Order
        {
            Id = orderId,
            CustomerId = customerId,
            OrderDate = DateTime.UtcNow,
            Items = products.Select(p => new OrderItem { Id = Guid.NewGuid(), OrderId = orderId, ProductId = p.Id, Price = p.BasePrice, Quantity = 1 }).ToList(),
        };

        _repo.CreateOrder(newOrder);
        await _repo.SaveChangesAsync();
        if (OrderPlaced != null)
        {
            OrderPlaced.Invoke(this, new OrderPlacedEvent(orderId, customerId, newOrder.Items.Sum(i => i.Quantity * i.Price)));
        }
        else
        {
            Console.WriteLine("WARNING: No event subscribers for OrderPlaced!");
        }
        return orderId;
    }

    public async Task<Guid?> OrderPaidAsync(Guid orderId)
    {
        var order = await _repo.GetOrderAsync(orderId);

        if (order == null)
        {
            Console.WriteLine($"Order with id # {orderId} was not found.");
            return null;
        }

        _repo.PayOrder(order);
        await _repo.SaveChangesAsync();

        if (OrderPaid != null)
        {
            Console.WriteLine($"Order #{orderId} is paid. Raising event...");

            OrderPaid.Invoke(this, new OrderPaidEvent(orderId, order.CustomerId, order.Items.Sum(i => i.Quantity * i.Price)));
        }
        else
        {
            Console.WriteLine("No event subcribers for order paid!");
        }
        return orderId;
    }

}
