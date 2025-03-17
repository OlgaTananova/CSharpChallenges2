using System;
using TicTacToeConsole;

namespace TicTacToe.Tests;

public class TicTacToeGameTests
{


    [Fact]
    public void MakeMove_WhenValidMove_ReturnsTrue()
    {

        // Arrange 
        TicTacToeGame game = new TicTacToeGame();

        // Act
        bool result = game.MakeMove(1);

        //Assert
        Assert.True(result);

    }

    [Fact]
    public void MakeMove_WhenInvalidMove_ReturnsFalse()
    {

        // Arrange 
        TicTacToeGame game = new TicTacToeGame();

        // Act
        bool result = game.MakeMove(11);

        //Assert
        Assert.False(result);

    }

    [Fact]
    public void MakeMove_WhenSameMove_ReturnsFalse()
    {
        var game = new TicTacToeGame();
        game.MakeMove(5);
        bool result = game.MakeMove(5); // Same spot
        Assert.False(result);
    }

    [Fact]
    public void CheckWin_WhenThreeXInColumn_ReturnsTrue()
    {
        var game = new TicTacToeGame();

        game.MakeMove(1);
        game.MakeMove(2);
        game.MakeMove(4);
        game.MakeMove(5);
        game.MakeMove(7);
        bool result = game.CheckWin();

        Assert.True(result);

    }

    [Fact]
    public void CheckWin_WhenThreeXInDiagonal_ReturnsTrue()
    {
        var game = new TicTacToeGame();

        game.MakeMove(1);
        game.MakeMove(2);
        game.MakeMove(5);
        game.MakeMove(4);
        game.MakeMove(9);
        bool result = game.CheckWin();

        Assert.True(result);

    }

    [Fact]
    public void CheckWin_WhenNo3SignsInRow_ReturnsFalse()
    {
        var game = new TicTacToeGame();

        game.MakeMove(1);
        game.MakeMove(2);
        game.MakeMove(5);
        bool result = game.CheckWin();

        Assert.False(result);

    }

}
