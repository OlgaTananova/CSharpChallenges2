using System;

namespace NumericTypesTasks;

public static class CheckWithIsClass
{
    public static void CheckWithIs(object obj)
    {
        if (obj is string str)
        {
            Console.WriteLine(str.ToUpper());
        }
        else if (obj is int number)
        {
            Console.WriteLine(Math.Pow(number, 2));
        }
        else if (obj is double dbl)
        {
            Console.WriteLine(dbl / 2);
        }
        else
        {
            Console.WriteLine("Unknown type");
        }
    }
}
