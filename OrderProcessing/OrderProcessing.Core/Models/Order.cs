using System;

namespace OrderProcessing.Core.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public DateTime OrderDate { get; set; }
    public bool IsPaid { get; set; }
}
