using System;

namespace NumericTypesTasks;

public static class ConvertToInt
{
    public static int ConvertToIntFromDoubleMethod(double number){
        
        int resultFromExplicitCasting = (int)number;
        Console.WriteLine("This is a result from an explicit casting" + " "+ resultFromExplicitCasting);
        
        int resultFromConvertClass = Convert.ToInt32(number);
        Console.WriteLine("This is a result from casting using ConvertClass" + " " + resultFromConvertClass);
        return (int) number;
    }
}
