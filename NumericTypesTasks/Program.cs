// Task 1
// Write a method that takes the radius of a circle as a float, calculates the area using double precision, 
// and returns the result as a decimal. Ensure you handle the type conversions properly.

using NumericTypesTasks;

decimal result = CalculateRadius.CalculateRadiusMethod(23.00F);
Console.WriteLine(result);


// Task 2 
//Task 2: Sum of Digits from a String
// Write a method that takes a string as input (e.g., "123abc456"), extracts all numeric characters, 
//converts them to an int, and calculates the sum of the digits. Use int.Parse or Convert.ToInt32 for the conversion.

int result2 = SumOfDigitsFromString.SumOfDigitsFromStringMethod("abc123xyz");
Console.WriteLine(result2);

// Task 3: Safe Conversion
//Write a program that reads a floating-point number (as a double) from the user and converts it to an int. 
// Use both casting and Convert.ToInt32, and compare the results, noting the difference between truncation and rounding.

ConvertToInt.ConvertToIntFromDoubleMethod(8.78);

//Task 5: Conversion Between Numeric Types
//Write a method that takes a list of mixed numeric types (int, float, double) and converts all elements to decimal. 
//Print the result before and after the conversion. Handle the conversion explicitly.

List<decimal> result5 = ConversionBtwNumericTypes.ToDecimal(new List<object> { "12", 3.14, 2.718 });

Console.WriteLine("Here is the result of task 5");
foreach(decimal r in result5){
    Console.Write(r + " ");
}

 Console.WriteLine("");
//Task 6: Safe Type Casting with as
//Create a method that accepts an object and attempts to cast it to a string using the as operator. 
//If the cast is successful, return the length of the string. If the cast fails, return -1.

object input1 = "Hello";
int result6 = ConvertToStringWithAsClass.ConvertToStringWithAs(input1);
Console.WriteLine(result6);
object input2 = 34;
int result6_1 = ConvertToStringWithAsClass.ConvertToStringWithAs(input2);
Console.WriteLine(result6_1);

//Task 7: Type Checking with is
//Write a method that accepts an object and checks whether it is of type int, double, or string using the is operator. 
//Depending on the type, perform a different action:

//If it’s an int, return the square of the number.
//If it’s a double, return half of the number.
//If it’s a string, return the string in uppercase.
//If the object is none of these types, return "Unknown type".

object inpt1 = 5;
object inpt2 = "Hello";
object inpt3 = 8.78;
object inpt4 = true;

CheckWithIsClass.CheckWithIs(inpt1);
CheckWithIsClass.CheckWithIs(inpt2);
CheckWithIsClass.CheckWithIs(inpt3);
CheckWithIsClass.CheckWithIs(inpt4);

// Task 8
// Given two floats how do you determine which is larger and when this is determined how would you pass the 
//value out as a string
Console.WriteLine("Task 8");
Console.WriteLine(SumOfTwoFloats.GetLargerToString(2.9F, 3.9F));