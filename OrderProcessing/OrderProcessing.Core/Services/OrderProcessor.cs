using OrderProcessing.Core.Events;
using OrderProcessing.Services;

namespace OrderProcessing.Core.Services;

public class OrderProcessor : IOrderProcessor
{
    private readonly IOrderService _orderService;
    private readonly IOrderProcessingRepository _repo;

    public OrderProcessor(IOrderProcessingRepository repo, IOrderService orderService)
    {
        _repo = repo;
        _orderService = orderService;
    }
    public async Task ProcessOrderAsync(OrderPlacedEvent orderPlacedEvent)
    {
        Console.WriteLine($"Processing order # {orderPlacedEvent.OrderId} for Customer # {orderPlacedEvent.CustomerId}");

        await Task.Delay(3000);

        await _repo.ProcessOrderAsync(orderPlacedEvent.OrderId);
        await _repo.SaveChangesAsync();
        Console.WriteLine($"Order #{orderPlacedEvent.OrderId} is in processing!");
    }

    public void SubscribeToOrderEvents()
    {
        Console.WriteLine("OrderProcessor subscribed to OrderPlaced event.");

        _orderService.OrderPlaced += OnOrderPlaced;

        Console.WriteLine("OrderProcessor subscribed to OrderPaid event.");

        _orderService.OrderPaid += OnOrderPaid;
    }

    public async void OnOrderPlaced(object? sender, OrderPlacedEvent orderEvent)
    {
        Console.WriteLine($"Order event received: Processing Order {orderEvent.OrderId}");
        await ProcessOrderAsync(orderEvent);
    }

    private async void OnOrderPaid(object? sender, OrderPaidEvent orderPaidEvent)
    {
        Console.WriteLine($"Order Paid event received: Order # {orderPaidEvent.OrderId} is paid!");
        await Task.Delay(1000);
    }
}
