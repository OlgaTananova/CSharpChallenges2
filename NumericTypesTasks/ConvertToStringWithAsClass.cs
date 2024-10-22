using System;

namespace NumericTypesTasks;

public static class ConvertToStringWithAsClass
{
    public static int ConvertToStringWithAs(object obj)
    {

        string? result = obj as string;
        if (result == null)
        {
            return -1;
        }
        else
        {
            return result.Length;
        }
    }
}
