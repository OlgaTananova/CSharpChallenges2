
namespace OrderProcessing.Core.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public decimal Total { get; set; }

    public string PreferredCurrency { get; set; } = "USD";
}

public enum OrderStatus
{
    Pending = 1,
    Processing = 2,
    Completed = 3,
}
