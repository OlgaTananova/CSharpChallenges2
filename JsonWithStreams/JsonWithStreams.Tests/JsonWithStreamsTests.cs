using System;
using System.Threading.Tasks;
using JsonWithStreamsConsole;

namespace JsonWithStreams.Tests;

public class JsonWithStreamsTests
{

    [Fact]

    public async Task RoundTripJsonAsync_WhenValidObject_ReturnsSameValues()
    {
        //Arrange
        JsonToStreamAndBackConverter converter = new();

        Person person = new Person { Name = "John", Age = 25 };

        // Act
        Person? result = await converter.RoundTripJsonAsync(person);
        // Assert

        Assert.NotNull(result);
        Assert.Equal(person.Name, result.Name);
        Assert.Equal(person.Age, result.Age);

    }

    [Fact]

    public async Task RoundTripJsonAsync_WhenNull_ThrowsNullException()
    {
        //Arrange
        JsonToStreamAndBackConverter converter = new();

        // Act
        await Assert.ThrowsAsync<NullReferenceException>(async () => await converter.RoundTripJsonAsync(null));

    }

}
