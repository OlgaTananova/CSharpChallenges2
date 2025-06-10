using System;
using EnumParserConsole;

namespace EnumParser.Tests;

public class EnumParserTests
{
    [Theory]
    [InlineData("info", false, LogLevel.Info)]
    [InlineData("verbose", false, LogLevel.Verbose)]
    [InlineData("unknown", false, LogLevel.Debug)]
    [InlineData("", false, LogLevel.Debug)]
    [InlineData("   ", false, LogLevel.Debug)]
    [InlineData(null, false, LogLevel.Debug)]
    public void ParseEnum_ShouldReturnCorrectResult(string input, bool exceptionFlag, LogLevel expected)
    {
        // Arrange 

        var result = EnumParserClass.ParseEnum<LogLevel>(input, exceptionFlag);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", true)]
    [InlineData("unknown", true)]
    [InlineData(" ", true)]
    [InlineData(null, true)]
    public void ParseEnum_ShouldThrowArgumentExeption(string input, bool exceptionFlag)
    {
        Assert.Throws<ArgumentException>(() =>
            EnumParserClass.ParseEnum<LogLevel>(input, exceptionFlag)
        );
    }

}
