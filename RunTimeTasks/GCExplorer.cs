using System;

namespace RunTimeTasks;

public static class GCExplorer
{
    public static void GCCollectorInvoker()
    {
        object obj = new object();
        Console.WriteLine($"Generation of the small object {GC.GetGeneration(obj)}");

        // Large object 
        byte[] largeArray = new byte[100000];
        Console.WriteLine($"Generation of the large object {GC.GetGeneration(largeArray)}");

        GC.Collect(0);

        Console.WriteLine($"Generation of the small object after garbage collection {GC.GetGeneration(obj)}");
        Console.WriteLine($"Generation of the large object after garbage collection {GC.GetGeneration(largeArray)}");
    }

}
