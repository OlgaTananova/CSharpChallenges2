

using OrderProcessing.Core.Events;

namespace OrderProcessing.Core.Services;

public interface IOrderProcessor
{
    void SubscribeToOrderEvents();
    Task ProcessOrderAsync(OrderPlacedEvent orderPlacedEvent);
    void OnOrderPlaced(object? sender, OrderPlacedEvent orderEvent);
}
