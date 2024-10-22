using System;

namespace NumericTypesTasks;

public static class ConversionBtwNumericTypes
{
    public static List<decimal> ToDecimal(List<object> numbers)
    {
        List<decimal> result = new List<decimal>();
        for (int i = 0; i < numbers.Count; i++)
        {
            result.Add(Convert.ToDecimal(numbers[i]));
        }
        return result;
    }
}
