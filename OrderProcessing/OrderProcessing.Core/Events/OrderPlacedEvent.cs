
namespace OrderProcessing.Core.Events;

public class OrderPlacedEvent : EventArgs
{

    public OrderPlacedEvent(Guid id, Guid customerId, decimal totalAmount)
    {
        OrderId = id;
        CustomerId = customerId;
        TotalAmount = totalAmount;
    }

    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
}
