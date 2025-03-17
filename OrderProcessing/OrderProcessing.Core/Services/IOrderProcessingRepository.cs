

namespace OrderProcessing.Services;

public interface IOrderProcessingRepository
{
    List<string> GetMostPopularProducts(int topN);

}
