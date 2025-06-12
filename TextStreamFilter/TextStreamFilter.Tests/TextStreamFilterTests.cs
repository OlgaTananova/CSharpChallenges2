using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextStreamFilter.Tests;

public class TextStreamFilterTests
{


    [Fact]
    public async Task FilterCommentsAsync_ShouldDeleteComments()
    {

        //Arrange

        string stringWithComments = "# This is a comment\n name=Alex\n age=20\n # comment";

        MemoryStream source = new(Encoding.UTF8.GetBytes(stringWithComments));
        MemoryStream destination = new MemoryStream();

        TextStreamFilterClass textFilter = new();

        await textFilter.FilterCommentsAsync(source, destination);

        destination.Position = 0;
        using var reader = new StreamReader(destination);

        string outputString = await reader.ReadToEndAsync();

        Assert.DoesNotContain("#", outputString);

    }
}
