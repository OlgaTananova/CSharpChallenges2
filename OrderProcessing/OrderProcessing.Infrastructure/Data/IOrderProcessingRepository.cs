

namespace OrderProcessing.Infrastructure.Data;

public interface IOrderProcessingRepository
{
    List<string> GetMostPopularProducts(int topN);

}
