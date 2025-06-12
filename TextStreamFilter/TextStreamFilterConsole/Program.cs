using System.Text;

public class Program
{
    public static async Task Main()
    {
        TextStreamFilterClass textFilter = new();

        string stringWithComments =
        @"# This is a comment
        name=Olga
        age=30
        # another comment
        location=USA";

        byte[] sourceBytes = Encoding.UTF8.GetBytes(stringWithComments);

        using MemoryStream sourceStream = new(sourceBytes);

        using MemoryStream destinationStream = new();

        await textFilter.FilterCommentsAsync(sourceStream, destinationStream);

        using var reader = new StreamReader(destinationStream);
        Console.WriteLine("=== Filtered Output ===");
        Console.WriteLine(await reader.ReadToEndAsync());

    }
}

public class TextStreamFilterClass
{
    public async Task FilterCommentsAsync(Stream source, Stream destination)
    {
        using var reader = new StreamReader(source, Encoding.UTF8, detectEncodingFromByteOrderMarks: true, bufferSize: 1024, leaveOpen: true);
        using var writer = new StreamWriter(destination, Encoding.UTF8, bufferSize: 1024, leaveOpen: true);

        string? line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            if (!line.TrimStart().StartsWith("#"))
            {
                await writer.WriteLineAsync(line);
            }

        }
        destination.Position = 0;
        await writer.FlushAsync();
    }
}
