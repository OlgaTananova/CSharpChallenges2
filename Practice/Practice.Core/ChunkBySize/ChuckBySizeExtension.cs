// Extension method to split an input IEnumerable collection into chunks of a fixed size. 

namespace Practice.Core.ChunkBySize;

public static class ChuckBySizeExtension
{
    public static IEnumerable<List<T>> ChunkBySize<T>(this IEnumerable<T> source, int size)
    {
        if (source == null)
        {
            throw new ArgumentNullException("The source cannot be null.");
        }
        else if (size <= 0)
        {
            throw new ArgumentException("The size cannot be 0");
        }

        List<T> buffer = new List<T>();

        foreach (var el in source)
        {
            buffer.Add(el);
            if (buffer.Count == size)
            {
                yield return buffer;
                buffer = new List<T>();
            }
        }
        if (buffer.Count > 0) yield return buffer;

    }
}
