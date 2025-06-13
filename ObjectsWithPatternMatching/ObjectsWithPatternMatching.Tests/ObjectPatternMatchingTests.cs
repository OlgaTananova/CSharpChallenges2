using System;

namespace ObjectsWithPatternMatching.Tests;

public class ObjectPatternMatchingTests
{

    [Theory]
    [InlineData("Dog", "Lucky", 5, false, false, "Normal barking dog named Lucky")]
    [InlineData("Dog", "Lucky", 2, false, false, "Quiet dog named Lucky")]
    [InlineData("Dog", "Lucky", 8, false, false, "Loud dog named Lucky")]
    [InlineData("Cat", "Lucky", 0, false, false, "Cat named Lucky who is not grumpy")]
    [InlineData("Cat", "Lucky", 0, true, false, "Cat named Lucky who is grumpy")]
    [InlineData("Bird", "Lucky", 0, false, false, "Bird named Lucky who cannot talk")]
    [InlineData("Bird", "Lucky", 0, false, true, "Bird named Lucky who can talk")]
    public void DescribeAnimal_WhenValidObjectDog_ReturnsCorrectResult(string animalType, string name, int barkVolume, bool isGrumpy, bool canTalk, string expected)
    {
        // Arrange
        AnimalDescriber describer = new();

        Animal? animal = animalType switch
        {
            "Dog" => new Dog { Name = name, BarkVolume = barkVolume },
            "Cat" => new Cat { Name = name, IsGrumpy = isGrumpy },
            "Bird" => new Bird { Name = name, CanTalk = canTalk },
            _ => default
        };

        // Act
        var result = describer.DescribeAnimal(animal);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]

    public void DescribeAnimal_WhenObjectIsNull_ReturnWarning()
    {
        // Arrange
        AnimalDescriber describer = new();
        var result = describer.DescribeAnimal(null);

        // Assert
        Assert.Equal("No animal provided", result);
    }

    [Fact]

    public void DescribeAnimal_WhenObjectTypeIsUnknown_ReturnWarning()
    {
        // Arrange
        AnimalDescriber describer = new();
        Goat goat = new Goat { Name = "Lucy" };
        var result = describer.DescribeAnimal(goat);

        // Assert
        Assert.Equal("Unknown animal", result);
    }

}

