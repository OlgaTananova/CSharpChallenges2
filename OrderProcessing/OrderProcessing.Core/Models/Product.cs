
namespace OrderProcessing.Core.Models;

public class Product
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public int Stock { get; set; }
}
