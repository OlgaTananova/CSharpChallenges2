using System;
using System.Net;

namespace Practice.Core.Singleton;

public class Logger
{
    private static Logger _instance = new Logger();
    private readonly static object _lock = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }

        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"Logged message: {message}");
    }
}

public class LazyLogger
{
    private static readonly Lazy<LazyLogger> _instance = new(() => new LazyLogger());

    private LazyLogger() { }
    public static LazyLogger Instance => _instance.Value;

    public void Log(string message)
    {
        Console.WriteLine($"Logged message: {message}");
    }
}
