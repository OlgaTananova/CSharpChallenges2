//Task 1: Basic Garbage Collection Demonstration
// Create a console application that demonstrates when the Garbage Collector runs.
// Allocate a large number of objects in a loop, and manually trigger garbage collection using GC.Collect() after printing out memory usage.

using RunTimeTasks;

Console.WriteLine("Task no 1");

BasicGC.BasicGCInvokation();

// Task 2: IDisposable Interface Implementation
// Create a class that implements the IDisposable interface. Use it to manage an unmanaged resource 
//(e.g., simulating a file handle or a database connection). Demonstrate how to use the Dispose() method in 
//a using block to ensure proper cleanup of resources.

Console.WriteLine("Task no 2");
using ResourceHandler resourceHandler = new ResourceHandler();
resourceHandler.OpenResource();

//Task 3: Exploring GC.Collect() and Generations
//Write a program that:
// Creates objects of different sizes in multiple generations (small objects that will likely be in Generation 0 and larger objects that will move to Generation 1 or 2).
//Monitor the GC behavior using GC.GetGeneration() to print which generation an object belongs to.
//Force garbage collection in specific generations using GC.Collect() and observe the behavior.

Console.WriteLine("Task no 3");

GCExplorer.GCCollectorInvoker();