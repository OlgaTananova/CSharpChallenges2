using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ClassifyCoordinatesConsole;

class Program
{
    static void Main(string[] args)
    {
        Point point1 = new(1, 1);
        Point point2 = new(0, 0);
        Point point3 = new(0, 1);
        Point point4 = new(-5, -1);

        Console.WriteLine(Point.Classify(point1));
        Console.WriteLine(Point.Classify(point2));
        Console.WriteLine(Point.Classify(point3));
        Console.WriteLine(Point.Classify(point4));
    }
}

public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y) => (X, Y) = (x, y);

    public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);

    public static string Classify(Point? point)
    {
        return point switch
        {
            (0, 0) => "Origin",
            ( > 0, 0) or ( < 0, 0) => "X-axis",
            (0, > 0) or (0, < 0) => "Y-axis",
            ( > 0, > 0) => "Quadrant I",
            ( < 0, < 0) => "Quadrant III",
            ( > 0, < 0) => "Quadrant IV",
            ( < 0, > 0) => "Quadrant II",
            null => throw new NullReferenceException("The input object is null."),
        };
    }
}
