using System;
using Practice.Core.PasswordValidator;

namespace Practice.Tests;

public class PasswordValidatorTests
{


    [Theory]
    [InlineData("YellowOrange1$", true)]
    [InlineData("YelJfhgaffage1#", true)]
    [InlineData("Yellow", false)]
    [InlineData("TestPassword", false)]
    [InlineData(null, false)]
    [InlineData("1234567909", false)]
    public void IsValidPassword_ReturnsCorrectResult(string password, bool expectedResult)
    {
        // Arrange
        PasswordValidator passwordValidator = new();

        // Act
        bool factResult = passwordValidator.IsValidPassword(password);

        // Assert
        Assert.Equal(expectedResult, factResult);

    }

    [Theory]
    [InlineData("YellowOrange1$", true)]
    [InlineData("YelJfhgaffage1#", true)]
    [InlineData("Yellow", false)]
    [InlineData("TestPassword", false)]
    [InlineData(null, false)]
    [InlineData("1234567909", false)]
    public void IsValidPasswordWithSingleLoop_ReturnsCorrectResult(string password, bool expectedResult)
    {
        // Arrange
        PasswordValidator passwordValidator = new();

        // Act
        bool factResult = passwordValidator.IsValidPasswordWithSingleLoop(password);

        // Assert
        Assert.Equal(expectedResult, factResult);

    }
}
