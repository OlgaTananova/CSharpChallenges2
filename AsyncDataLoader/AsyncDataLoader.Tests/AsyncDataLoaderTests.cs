using System;
using AsyncDataLoader.Console;

namespace AsyncDataLoader.Tests;

public class AsyncDataLoaderTests
{
    [Fact]
    public async Task Loader_ComputesCorrectSum()
    {
        // Arrange
        var urls = new List<(string url, int delayMs, int value)>
    {
        ("url1", 10, 1),
        ("url2", 10, 2),
        ("url3", 10, 3)
    };
        var loader = new Loader(urls, maxConcurrency: 2);

        // Act
        int result = await loader.RunUrlLoadAsync();

        // Assert
        Assert.Equal(6, result);
    }

}
