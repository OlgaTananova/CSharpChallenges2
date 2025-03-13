using System;
using System.Reflection.Metadata.Ecma335;

namespace TicTacToeConsole;

public class TicTacToeGame
{
    public char[,] Board { get; private set; }
    public char CurrentPlayer { get; private set; }

    public TicTacToeGame()
    {
        Board = new char[,]
           {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
           };
        CurrentPlayer = 'X';

    }

    public void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine($" {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} ");
    }

    public void PlayGame()
    {
        int moves = 0;
        bool gameRunning = true;

        while (gameRunning && moves < 9)
        {
            PrintBoard();
            Console.WriteLine($"Player {CurrentPlayer}, it's your turn. Enter a number (1-9): ");

            string? input = Console.ReadLine();
            int position = ParseAndValidateInput(input);
            if (position != 0)
            {
                if (MakeMove(position))
                {
                    moves++;

                    if (CheckWin())
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"The winner is {CurrentPlayer}.");
                        gameRunning = false;
                    }
                    else if (moves == 9)
                    {
                        Console.Clear();
                        PrintBoard();
                        Console.WriteLine($"It is a draw!");
                        gameRunning = false;
                    }
                    else
                    {
                        CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
                    }


                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }

            }
            else
            {
                Console.WriteLine("Invalid input, please type in valid board position.");
            }

        }
    }


    private int ParseAndValidateInput(string? input)
    {
        if (input == null) return 0;

        if (int.TryParse(input, out int position) && position >= 1 && position <= 9)
        {
            return position;
        }
        else
        {
            return 0;
        }
    }

    private bool MakeMove(int position)
    {
        int row = (position - 1) / 3;
        int col = (position - 1) % 3;

        if (Board[row, col] != 'X' && Board[row, col] != 'O')
        {
            Board[row, col] = CurrentPlayer;
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            bool result = CheckHorizontalAndVerticalGrid(i);
            if (result) return true;
        }

        return CheckDiagonalGrid();
    }

    private bool CheckHorizontalAndVerticalGrid(int i)
    {
        if ((Board[i, 0] == CurrentPlayer && Board[i, 1] == CurrentPlayer && Board[i, 2] == CurrentPlayer) ||
            (Board[0, i] == CurrentPlayer && Board[1, i] == CurrentPlayer && Board[2, i] == CurrentPlayer))
        {
            return true;
        }
        return false;
    }

    private bool CheckDiagonalGrid()
    {
        if ((Board[0, 0] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 2] == CurrentPlayer) ||
            (Board[0, 2] == CurrentPlayer && Board[1, 1] == CurrentPlayer && Board[2, 0] == CurrentPlayer))
        {
            return true;
        }
        return false;
    }

}
