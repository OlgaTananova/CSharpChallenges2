namespace AsyncDataLoader.Console;

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

class Program
{
    private static List<(string url, int delayMs, int value)> _urls = [
        ("https://example.com/data/1", 500, 1),
         ("https://example.com/data/2", 300, 2),
          ("https://example.com/data/3", 450, 7),
           ("https://example.com/data/4", 400, 8),
            ("https://example.com/data/5", 350, 5),
             ("https://example.com/data/6", 250, 0),
              ("https://example.com/data/7", 600, 3),
              ("https://example.com/data/8", 550, 8),
              ("https://example.com/data/9", 600, 9),
              ("https://example.com/data/10", 200, 1)
         ];


    static async Task Main(string[] args)
    {
        Console.WriteLine($"Allocated Memory: {GC.GetAllocatedBytesForCurrentThread()}");
        Loader loader = new(_urls, 3);
        int result = await loader.RunUrlLoadAsync();
        Console.WriteLine($"Total computed value is {result}");
        Console.WriteLine($"Memory after release: {GC.GetAllocatedBytesForCurrentThread()}");
    }
}

public class Loader
{
    private readonly List<(string url, int delayMs, int value)> _urls;
    private readonly SemaphoreSlim _semaphoreSlim;

    public Loader(List<(string url, int delayMs, int value)> urls, int maxConcurrency)
    {
        _urls = urls;
        _semaphoreSlim = new SemaphoreSlim(maxConcurrency);
    }

    private async Task<int> LoadUrlAsync(string url, int delayMs, int value)
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            Console.WriteLine($"Start loading {url}...");
            await Task.Delay(delayMs);
            Console.WriteLine($"Finished loading {url} ({delayMs}ms), value = {value}");
            return value;
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }

    public async Task<int> RunUrlLoadAsync()
    {
        var tasks = _urls.Select(u => LoadUrlAsync(u.url, u.delayMs, u.value)).ToList();
        int[] result = await Task.WhenAll(tasks);
        return result.Sum();
    }
}

