using System;
using Practice.Core.LINQ;
using Xunit.Sdk;

namespace Practice.Tests;

public class LinqQueryTests
{

    [Fact]
    public void SelectTopScoredStudents_ShouldReturCorrectResult()
    {
        // Arrange
        List<Student> students = new List<Student>{
            new Student {Name = "John Smith", Id = 1, Score = 85},
            new Student {Name = "Bob Baker", Id = 2, Score = 60},
            new Student {Name = "Alice Mason", Id = 3, Score = 90},
            new Student {Name = "Marsha Lynn", Id = 4, Score = 79},
        };

        // Act
        var result = LinqQueries.SelectTopScoredStudents(students);

        // Assert

        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count);
        Assert.Contains("Alice", result.First().Name);
        Assert.Equal(90, result[0].Score);
        Assert.Contains("John", result[1].Name);

    }

    [Fact]
    public void SelectTopScoredStudents_ShouldReturnEmptyList_WhenNoStudentsAbove80()
    {

        // Arrange
        List<Student> students = new List<Student>{
            new Student {Name = "Bob Baker", Id = 2, Score = 60},
            new Student {Name = "Marsha Lynn", Id = 4, Score = 79},
        };

        // Act 
        var result = LinqQueries.SelectTopScoredStudents(students);

        // Assert 
        Assert.Empty(result);
    }

    [Fact]
    public void SelectTopScoredStudents_ShouldThrowNullArgumentException_WhenInputIsNull()
    {
        List<Student>? students = null;

        Assert.Throws<ArgumentNullException>(() => LinqQueries.SelectTopScoredStudents(students));
    }


}
