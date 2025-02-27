using System;
using System.Reflection;
using Practice.Core;

namespace Practice.Tests;

public class CalculatorTests
{
    private Calculator _calculator;
    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Theory]
    [InlineData(10, 10, 20)]
    [InlineData(5, 5, 10)]
    [InlineData(100, 10, 110)]

    public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
    {
        int result = _calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, 0)]
    [InlineData(10, 5, 5)]
    [InlineData(20, 3, 17)]
    public void Subtract_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        int result = _calculator.Subtract(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 10, 100)]
    [InlineData(10, 5, 50)]
    [InlineData(20, 3, 60)]
    public void Multiply_ShouldReturnCorrectProduct(int a, int b, int expected)
    {
        int result = _calculator.Multiply(a, b);
        Assert.Equal(expected, result);
    }



    [Theory]
    [InlineData(10, 10, 1)]
    [InlineData(5, 2, 2)]
    public void Divide_ShouldReturnCorrectResult(int a, int b, int expected)
    {

        int? result = _calculator.Divide(a, b);

        //Asssert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Divide_ShouldReturnDivideByZeroException()
    {

        //Asssert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
    }

    [Theory]
    [InlineData(new int[] { 1, 3, 4 }, 8)]
    public void AddWithMultipleParams_ShouldReturnCorrectResult(int[] nums, int expected)
    {
        var result = _calculator.AddWithMultipleParams(nums);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 4, 2, 1 }, 1)]
    public void SubtractWithMultipleParams_ShouldReturnCorrectResult(int[] nums, int expected)
    {
        var result = _calculator.SubtractWithMultipleParams(nums);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SubtractWithMultipleParams_ShouldThrowArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.SubtractWithMultipleParams([1]));
    }
}
