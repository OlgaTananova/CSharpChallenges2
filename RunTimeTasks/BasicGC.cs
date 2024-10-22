using System;

namespace RunTimeTasks;

public static class BasicGC
{
    public static void BasicGCInvokation()
    {
        Console.WriteLine($"Memory before allocation: {GC.GetTotalMemory(false)}");

        for (int i = 0; i < 100000; i++){
            object obj = new object();
        }
        Console.WriteLine($"Memory after allocation: {GC.GetTotalMemory(false)}");

        GC.Collect();

        Console.WriteLine($"Memory after GC invokation: {GC.GetTotalMemory(false)}");
    }
}
