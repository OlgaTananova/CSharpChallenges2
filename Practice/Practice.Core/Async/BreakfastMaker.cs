using System;
using System.Diagnostics;

namespace Practice.Core.Async;

public class BreakfastMaker
{
    public async Task MakeTeaAsync()
    {
        Console.WriteLine("Start making tea...");
        await Task.Delay(2000);
        Console.WriteLine("Tea is ready!");
    }

    public async Task MakeEggsAsync()
    {
        Console.WriteLine("Start frying eggs...");
        await Task.Delay(3000);
        Console.WriteLine("Eggs are ready!");
    }

    public async Task MakeToastAsync()
    {
        Console.WriteLine("Start making toast...");
        await Task.Delay(1000);
        Console.WriteLine("Toast is ready!");
    }

    public async Task CookBreakfastRunInParallelAsync()
    {
        Console.WriteLine("Start cooking breakfast in parallel.");
        Stopwatch sw = Stopwatch.StartNew();
        Task eggs = MakeEggsAsync();
        Task toast = MakeToastAsync();
        Task tea = MakeTeaAsync();
        await Task.WhenAll(eggs, toast, tea);
        sw.Stop();
        Console.WriteLine($"Breakfast is ready in {sw.ElapsedMilliseconds / 1000} seconds!");
    }

    public async Task CookBreakfastSequentiallyAsync()
    {
        Console.WriteLine("Start cooking breakfast sequentially");
        Stopwatch sw = Stopwatch.StartNew();
        await MakeEggsAsync();
        await MakeToastAsync();
        await MakeTeaAsync();
        sw.Stop();
        Console.WriteLine($"Breakfast is ready in {sw.ElapsedMilliseconds / 1000} seconds!");
    }

}
