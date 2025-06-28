using ClassifyCoordinatesConsole;

namespace ClassifyCoordinates.Tests;

public class ClassifyTests
{

    [Theory]
    [InlineData(1, 1, "Quadrant I")]
    [InlineData(0, 0, "Origin")]
    [InlineData(1, 0, "X-axis")]
    [InlineData(0, 1, "Y-axis")]
    [InlineData(-1, 1, "Quadrant II")]
    [InlineData(-1, -1, "Quadrant III")]
    [InlineData(1, -1, "Quadrant IV")]

    public void Classify_ShouldReturnCorrectResult(int x, int y, string expected)

    {
        var point = new Point(x, y);
        var result = Point.Classify(point);
        Assert.Equal(expected, result);
    }

    [Fact]

    public void Classify_WhenInputIsNull_ThrowsNullReferenceException()
    {
        Assert.Throws<NullReferenceException>(() => Point.Classify(null));
    }

}
