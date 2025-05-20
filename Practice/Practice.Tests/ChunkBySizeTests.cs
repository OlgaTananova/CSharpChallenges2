using System;
using Practice.Core.ChunkBySize;

namespace Practice.Tests;

public class ChunkBySizeTests
{
    [Fact]
    public void ChunkBySize_WhenPerfectChunks_ReturnsCorrectChunks()
    {
        var input = new List<int> { 1, 2, 3, 4, 5, 6 };
        var size = 3;

        var result = input?.ChunkBySize(size)?.ToList();

        Assert.Equal(2, result?.Count);
        Assert.Equal(new List<int> { 1, 2, 3 }, result?[0]);
        Assert.Equal(new List<int> { 4, 5, 6 }, result?[1]);
    }

    [Fact]
    public void ChunkBySize_WithIncompleteFinalChunk_ReturnsCorrectChunks()
    {
        var input = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        var size = 3;

        var result = input?.ChunkBySize(size)?.ToList();

        Assert.Equal(3, result?.Count);
        Assert.Equal(new List<int> { 1, 2, 3 }, result?[0]);
        Assert.Equal(new List<int> { 4, 5, 6 }, result?[1]);
        Assert.Equal(new List<int> { 7 }, result?[2]);
    }

    [Fact]
    public void ChunkBySize_WithEmptySource_ReturnsEmpty()
    {
        var input = new List<int>();
        var size = 3;

        var result = input?.ChunkBySize(size)?.ToList();

        Assert.Empty(result);
    }

    [Fact]
    public void ChunkBySize_WithInvalidSize_ReturnsArgumentException()
    {
        var input = new List<int> { 1, 3, 5, 4 };
        var size = -3;

        Assert.Throws<ArgumentException>(() => input?.ChunkBySize(size)?.ToList());
    }

    [Fact]
    public void ChunkBySize_WithNullSource_ReturnsArgumentNullException()
    {
        List<int> input = null!;
        var size = 3;

        Assert.Throws<ArgumentNullException>(() => input.ChunkBySize(size).ToList());
    }
}
