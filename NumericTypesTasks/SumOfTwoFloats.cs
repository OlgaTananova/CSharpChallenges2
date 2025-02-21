using System;

namespace NumericTypesTasks;

public static class SumOfTwoFloats
{
    public static string GetLargerToString(float num1, float num2)
    {
        float result = Math.Max(num1, num2);
        return result.ToString();
    }
}
