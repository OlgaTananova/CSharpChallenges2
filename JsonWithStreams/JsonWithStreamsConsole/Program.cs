using System.Text.Json;
using System.Threading.Tasks;

namespace JsonWithStreamsConsole;

class Program
{
    static async Task Main(string[] args)
    {
        JsonToStreamAndBackConverter converter = new();
        Person person = new Person { Name = "Olga", Age = 39 };

        var result = await converter.RoundTripJsonAsync(person);

        Console.WriteLine(result?.ToString());
    }
}

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Person, Name: {Name}, Age {Age}";
    }
}

public class JsonToStreamAndBackConverter
{

    public async Task<Person?> RoundTripJsonAsync(Person? input)
    {
        if (input is null) throw new NullReferenceException("The input object cannot be null");

        using MemoryStream stream = new();

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        await JsonSerializer.SerializeAsync(stream, input, options);

        stream.Seek(0, SeekOrigin.Begin);

        Person? outputJson = await JsonSerializer.DeserializeAsync<Person>(stream, options);

        return outputJson;

    }
}