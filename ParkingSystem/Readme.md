# Parking System Simulation in C#
A simple object-oriented parking lot simulation developed in C# for practicing system design, asynchronous programming, and concurrency control.

## Features
- Supports multiple vehicle types: Car, Motorcycle, Truck
- Each vehicle type requires a specific number of parking spots (e.g., Truck needs 2 adjacent spots)
- Manages available parking spots dynamically
- Allows multiple kiosks (entry points) to process vehicles concurrently
- Ensures thread-safe access using fine-grained SemaphoreSlim locks at the parking spot level
- Vehicles retry parking if spots are not immediately available (with configurable max retries and backoff)
- Simulates arrival time, parking duration, and departure using asynchronous operations (async/await)
- Includes unit tests using xUnit

## Concepts Covered
- Object-oriented principles: abstraction, inheritance, encapsulation
- Asynchronous programming with Task, async/await, and Task.Delay
- Fine-grained concurrency control using SemaphoreSlim
- Retry logic with configurable limits and randomized delays

## Tech Stack
- C# (.NET)
- Unit for unit testing

## Future improvements
- Levels/multiple floors 
- Billing support