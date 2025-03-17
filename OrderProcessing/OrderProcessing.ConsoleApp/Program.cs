
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderProcessing.Core.Data;


// Set up dependency injection
var serviceProvider = new ServiceCollection()
    .AddDbContext<AppDbContext>(options => options.UseNpgsql("Server=localhost:5432;Database=orderprocessing;Username=user;Password=user123"))
    .AddScoped<OrderProcessing.Services.OrderProcessingRepository>()
    .BuildServiceProvider();


// Use a service scope to avoid multiple instantiations of DbContext
using (var scope = serviceProvider.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;

    // Get DbContext and apply migrations
    var context = scopedProvider.GetRequiredService<AppDbContext>();
}


