namespace EnumParserConsole;

public class Program
{
    public static void Main()
    {
        Console.WriteLine();
        Console.WriteLine(EnumParserClass.ParseEnum<LogLevel>("info"));
        Console.WriteLine(EnumParserClass.ParseEnum<LogLevel>("verbose"));
        Console.WriteLine(EnumParserClass.ParseEnum<LogLevel>("unknown", throwIfInvalid: false));
        Console.WriteLine(EnumParserClass.ParseEnum<LogLevel>("unknown", throwIfInvalid: true));

    }
}
public enum LogLevel
{
    Debug,
    Info,
    Warning,
    Error,
    Critical,
    Verbose
}

public static class EnumParserClass
{
    public static TEnum ParseEnum<TEnum>(string input, bool throwIfInvalid = false) where TEnum : struct, Enum
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            if (throwIfInvalid)
                throw new ArgumentException($"Input string cannot be null or whitespace, {nameof(input)}");
            return default;
        }


        if (Enum.TryParse<TEnum>(input.Trim(), true, out var result))
        {
            return result;
        }
        if (throwIfInvalid)
        {
            throw new ArgumentException($"Invalid value '{input}' for enum type {typeof(TEnum).Name}.");
        }
        return default;
    }
}



