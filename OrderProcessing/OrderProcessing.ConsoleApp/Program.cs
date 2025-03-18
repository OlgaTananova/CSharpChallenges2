
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Core.Data;
using OrderProcessing.Core.Services;
using OrderProcessing.Services;


// Set up dependency injection
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>(options => options.UseNpgsql("Server=localhost:5432;Database=orderprocessing;Username=user;Password=user123"))
    .AddScoped<IOrderProcessingRepository, OrderProcessingRepository>()
    .AddSingleton<IOrderProcessor, OrderProcessor>()
    .AddSingleton<IOrderService, OrderService>()
    .BuildServiceProvider();


// Use a service scope to avoid multiple instantiations of DbContext
using (var scope = serviceProvider.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    var orderService = scopedProvider.GetRequiredService<IOrderService>();
    var orderProcessor = scopedProvider.GetRequiredService<IOrderProcessor>();
    var repository = scopedProvider.GetRequiredService<IOrderProcessingRepository>();

    orderProcessor.SubscribeToOrderEvents();

    var products = await repository.GetProductsAsync();
    var customer = await repository.GetCustomerAsync("John");
    Guid orderId;
    if (customer != null && products != null)
    {
        orderId = await orderService.OrderPlacedAsync(customer.Id, products);
        Console.WriteLine("Order is sucessfully placed!");
        await orderService.OrderPaidAsync(orderId);
    }
}


