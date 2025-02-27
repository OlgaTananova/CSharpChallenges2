using System;

namespace Practice.Core;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Division by 0 is prohibited.");
        }
        return a / b;
    }

    public int AddWithMultipleParams(params int[] nums)
    {
        return nums.Sum();
    }

    public int SubtractWithMultipleParams(params int[] nums)
    {
        if (nums.Length < 2)
        {
            throw new ArgumentException("There should be at least 2 numbers.");
        }

        int result = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            result -= nums[i];
        }
        return result;
    }
}
