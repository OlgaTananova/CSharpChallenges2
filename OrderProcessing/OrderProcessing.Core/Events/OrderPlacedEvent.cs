
namespace OrderProcessing.Core.Events;

public class OrderPlacedEvent : EventArgs
{

    public OrderPlacedEvent(int id, int customerId, decimal totalAmount)
    {
        OrderId = id;
        CustomerId = customerId;
        TotalAmount = totalAmount;
    }

    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
}
