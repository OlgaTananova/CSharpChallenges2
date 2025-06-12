using System.Text;
namespace StreamCopierConsole;

public class Program
{
    public static async Task Main()
    {
        var copier = new StreamCopier();
        copier.ProgressChanged += (s, bytesCopied) =>
        Console.WriteLine($"Copied {bytesCopied} bytes");

        string sourceStreamContent = "This is a random string. ..............................................";
        await File.WriteAllTextAsync("input.txt", sourceStreamContent);
        using var input = new FileStream("input.txt", FileMode.Open, FileAccess.Read);
        using var output = new FileStream("output.txt", FileMode.Create);
        await copier.CopyAsync(input, output);


    }
}

public class StreamCopier
{
    public event EventHandler<long>? ProgressChanged;

    public async Task CopyAsync(Stream source, Stream destination, int bufferSize = 4096, long progressStep = 1024)
    {
        // Buffer to temporarily hold the data
        byte[] buffer = new byte[bufferSize];
        // number of bytes processed
        int byteCount = 0;
        long totalBytesCopied = 0;
        long nextProgressMark = progressStep;
        while ((byteCount = await source.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            // write to the dest stream 
            await destination.WriteAsync(buffer, 0, byteCount);

            string content = Encoding.UTF8.GetString(buffer, 0, byteCount);
            Console.WriteLine(content);

            totalBytesCopied += byteCount;

            if (totalBytesCopied >= nextProgressMark)
            {
                ProgressChanged?.Invoke(this, totalBytesCopied);
                nextProgressMark += progressStep;
            }
        }
    }
}