using System;
using System.Text;

namespace StreamCopierTests;

public class StreamCopierTests
{

    [Fact]
    public async Task CopyAsync_CopiesDataAndRaisesEvent()
    {
        // Arrange 
        string testString = "This is a string longe than 32 bytes.";
        byte[] bytes = Encoding.UTF8.GetBytes(testString);

        MemoryStream source = new MemoryStream(bytes);
        MemoryStream destination = new MemoryStream();

        var copier = new StreamCopierConsole.StreamCopier();

        long progress = 0;

        copier.ProgressChanged += (sender, copiedBytes) => progress += copiedBytes;

        //Act 

        await copier.CopyAsync(source, destination, bufferSize: 16, progressStep: 32);

        string result = Encoding.UTF8.GetString(destination.ToArray());

        Assert.Equal(testString, result);

        Assert.True(progress >= 32);
    }
}
