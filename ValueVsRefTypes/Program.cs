//Task 1: Deep vs Shallow Copy in Reference Types
//Create a class that has a reference type field (such as an array or another class). 
//Implement a method that performs a shallow copy and a deep copy of the object, demonstrating the difference between the two.

using ValueVsRefTypes;

Console.WriteLine("Task no 1");

DeepAndShallowCopy.DeepAndShallowCopyDemonstration();

//Task 2: Nullable Structs with Complex Logic
//Create a struct that holds a nullable DateTime and implements custom logic to calculate the difference between two 
//nullable DateTimes, handling cases where one or both values might be null.


//Task 3: Custom Nullable Type Implementation
//Implement your own nullable type for a custom value type. This will help you understand how Nullable<T> works under the hood. Create a NullableTemperature type that can handle null values for temperature readings and provides methods for getting values and default fallbacks.
//Steps:
//Create a custom struct NullableTemperature that holds a temperature and a boolean flag indicating whether it has a value.
//Implement methods for HasValue, GetValueOrDefault(), and a custom null-check method.