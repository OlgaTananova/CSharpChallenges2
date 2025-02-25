
namespace OrderProcessing.Infrastructure.Data;

public class OrderProcessingRepository : IOrderProcessingRepository
{
    private readonly AppDbContext _appDbContext;
    public OrderProcessingRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<string> GetMostPopularProducts(int topN)
    {
        return _appDbContext.OrderItems
                .GroupBy(i => i.ProductName)
                .OrderByDescending(g => g.Sum(i => i.Quantity))
                .Take(topN)
                .Select(p => p.Key)
                .ToList();
    }
}
