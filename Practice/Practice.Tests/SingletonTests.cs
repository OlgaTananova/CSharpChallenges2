using System;
using Practice.Core.Singleton;

namespace Practice.Tests;

public class SingletonTests
{
    [Fact]
    public void Singleton_ShouldReturnSameInstance()
    {
        // Arrange 
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        Assert.Same(logger1, logger2);

    }

    [Fact]
    public void LazySingleton_ShouldReturnSameInstance()
    {
        LazyLogger logger1 = LazyLogger.Instance;
        LazyLogger logger2 = LazyLogger.Instance;

        Assert.Same(logger1, logger2);
    }

}
