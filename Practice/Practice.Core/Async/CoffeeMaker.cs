using System;

namespace Practice.Core.Async;

public class CoffeeMaker
{

    public async Task MakeCoffeeAsync()
    {
        Console.WriteLine("Start making coffee...");
        await Task.Delay(3000);
        Console.WriteLine("Coffee is ready!");
    }

    public async Task CallMakeCoffeeAsync()
    {
        Task result = MakeCoffeeAsync();

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
        }
        await result;
    }
}
