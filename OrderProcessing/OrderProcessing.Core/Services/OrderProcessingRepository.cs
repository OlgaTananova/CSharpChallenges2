
using Microsoft.EntityFrameworkCore;
using OrderProcessing.Core.Data;
using OrderProcessing.Core.Models;

namespace OrderProcessing.Services;

public class OrderProcessingRepository : IOrderProcessingRepository
{
    private readonly AppDbContext _appDbContext;
    public OrderProcessingRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void CreateOrder(Order order)
    {
        _appDbContext.Orders.Add(order);
    }

    public async Task ProcessOrderAsync(Guid orderId)
    {
        var order = await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

        if (order != null)
        {
            order.Status = OrderStatus.Processing;
        }
    }


    public List<string> GetMostPopularProducts(int topN)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        var query = _appDbContext.Products.Take(2);
        Console.WriteLine(query.ToQueryString());
        return await query.ToListAsync();
    }

    public async Task<Customer?> GetCustomerAsync(string name)
    {
        return await _appDbContext.Customers.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }

    public async Task<Order?> GetOrderAsync(Guid orderId)
    {
        return await _appDbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public void PayOrder(Order order)
    {
        order.IsPaid = true;
        _appDbContext.Orders.Update(order);
    }

}
