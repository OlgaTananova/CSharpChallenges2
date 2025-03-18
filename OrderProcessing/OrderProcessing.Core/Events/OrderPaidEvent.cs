
namespace OrderProcessing.Core.Events;

public class OrderPaidEvent
{
    public OrderPaidEvent(Guid id, Guid customerId, decimal totalAmount)
    {
        OrderId = id;
        CustomerId = customerId;
        TotalAmount = totalAmount;
    }

    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }

}
