using System;

namespace RunTimeTasks;

public class ResourceHandler : IDisposable
{
    public void OpenResource()
    {
        Console.WriteLine("Resouce is opened.");
    }
    public void Dispose()
    {
        Console.WriteLine("Resource is released.");
    }
}
