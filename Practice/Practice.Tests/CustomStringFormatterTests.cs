using System;
using Practice.Core.CustomStringFormatter;

namespace Practice.Tests;

public class CustomStringFormatterTests
{
    [Theory]
    [InlineData("the quick brown fox", "The Quick Brown Fox")]
    public void FormatStringToCapitalizeFirstLetters_ShouldReturnCorrectResult(string s, string expected)
    {
        var result = CustomStringFormatter.FormatStringToCapitalizeFirstLetters(s);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("the quick brown fox", "The Quick Brown Fox")]
    public void FormatStringToTitleCase_ShouldReturnCorrectResult(string s, string expected)
    {
        var result = CustomStringFormatter.FormatStringToTitleCase(s);

        Assert.Equal(expected, result);
    }
}
