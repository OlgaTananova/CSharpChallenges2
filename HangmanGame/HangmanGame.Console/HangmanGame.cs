using System;
using System.Threading.Tasks.Dataflow;

namespace HangmanGame.App;

public class HangmanGameClass
{
    // predefined list of words 
    private static List<string> words = ["wheel", "cart", "horse", "bridal", "saddle", "hoof", "harness"];

    const int maxAttempts = 6;

    // choose a random word from a list to guess

    private string PickAWord()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, words.Count);
        return words[randomIndex];
    }

    public void PlayGame()
    {
        string wordToGuess = PickAWord().ToLower();
        int numberOfAttempts = 0;
        bool hasWinner = false;
        List<char> board = Enumerable.Repeat('_', wordToGuess.Count()).ToList();
        HashSet<char> guessedLetters = new();

        while (numberOfAttempts < maxAttempts)
        {
            // Print a word with hidden letters
            PrintBoard(board, guessedLetters, numberOfAttempts);

            // the player guesses
            Console.Write("Guess a letter: ");
            char guessedLetter = char.ToLower((char)Console.Read());
            Console.WriteLine();

            if (!char.IsLetter(guessedLetter))
            {
                Console.WriteLine("You have typed incorrect character. Please type only letters.");
                continue;
            }

            if (guessedLetters.Contains(guessedLetter))
            {
                Console.WriteLine($"You have already guessed '{guessedLetter}'. Try another letter.");
                continue;
            }

            bool correctGuess = UpdateBoard(guessedLetter, wordToGuess, board);
            if (!correctGuess)
            {
                numberOfAttempts++;
                Console.WriteLine($"Incorrect guess! Attempts left is {maxAttempts - numberOfAttempts}");
            }

            if (board.All(c => c != '_'))
            {
                hasWinner = true;
                break;
            }
        }
        PrintBoard(board, guessedLetters, numberOfAttempts);
        PrintFinalResult(hasWinner, wordToGuess);
    }

    private void PrintBoard(List<char> board, HashSet<char> guessedLetters, int attempts)
    {
        Console.Clear();
        Console.WriteLine("Word: " + string.Join(" ", board));
        Console.WriteLine($"Guessed Letters: {string.Join(", ", guessedLetters)}");
        Console.WriteLine($"Remaining Attempts: {maxAttempts - attempts}");
    }

    private bool UpdateBoard(char input, string wordToGuess, List<char> board)
    {
        bool guessedCorrectly = false;
        for (int i = 0; i < wordToGuess.Count(); i++)
        {
            char c = char.ToLower(wordToGuess[i]);
            if (c == input)
            {
                board[i] = input;
                guessedCorrectly = true;
            }
        }
        return guessedCorrectly;
    }

    private void PrintFinalResult(bool hasWinner, string wordToGuess)
    {
        if (hasWinner)
        {
            Console.WriteLine("\n🎉 Congratulations! You guessed the word!");
        }
        else
        {
            Console.WriteLine($"\n😞 Sorry, you lost! The correct word was: {wordToGuess}");
        }
    }

}
