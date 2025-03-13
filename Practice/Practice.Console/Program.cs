
// CoffeeMaker

using Practice.Core.Async;

//CoffeeMaker coffeeMaker = new();
//await coffeeMaker.CallMakeCoffeeAsync();

//Breakfastmaker

BreakfastMaker breakfastMaker = new();
await breakfastMaker.CookBreakfastRunInParallelAsync();
await breakfastMaker.CookBreakfastSequentiallyAsync();

//Task 4: Cancellation
//Goal: Cancel a long-running task.

//Create an async method DownloadFileAsync(CancellationToken token) that:
// Loops and simulates downloading chunks with delays.
// Checks token.ThrowIfCancellationRequested() on each iteration.
// Start the download and cancel it after 2 seconds using CancellationTokenSource.
// Catch and handle the OperationCanceledException.

// Task 5: Error Handling
// Goal: Handle exceptions from an async method.

// Create an async method GetDataFromApiAsync() that throws an exception after a delay.
// In Main(), await the method inside a try/catch.
// Print the exception message.

// Task 6: ConfigureAwait Usage
// Goal: Observe thread usage with and without ConfigureAwait(false).

// Create an async method with a delay.
// After the delay, print the current thread ID.
// using System;
// using System.Threading;
// using System.Threading.Tasks;


// Task 7: Chained Async Calls
// Goal: Build dependent async calls.

// Create three async methods:
// GetUserIdAsync()
// GetUserProfileAsync(userId)
// GetUserPreferencesAsync(profile)
// Each depends on the result of the previous.
// Call them in sequence with await.

// Task 8: Async Streams
// Goal: Yield multiple results asynchronously.

// Create an async IAsyncEnumerable<int> GenerateNumbersAsync() that:
// Yields numbers from 1 to 5 with a delay.
// Consume the stream with await foreach and print each number.

// Task 10: TaskCompletionSource
// Goal: Wrap an event into a task.

// Simulate an event-based operation (like a timer).
// Use TaskCompletionSource<T> to convert the event into a Task<T>.
// Await the task to get the result when the event fires.