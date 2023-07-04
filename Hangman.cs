using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;
using System.ComponentModel.DataAnnotations;

public class Hangman
{
    // Attributes
    private string _letterGuessed;
    private Player player;
    private GallowsRenderer gallowsRenderer;
    private WordGenerator randomWord;
    private ScoreBoard simpleScore = new ScoreBoard(new ScoreSimple());
    private ScoreBoard complexScore = new ScoreBoard(new ScoreComplex());

    // Constructors
    public Hangman()
    {
        player = new Player();
        gallowsRenderer = new GallowsRenderer();
        randomWord = new WordGenerator();
    }
    // Methods

    private void DisplayRandomWord()
    {
        Console.WriteLine("\n{0}", player.randomWord);
    }

    public void StartGame(string fileName)
    {
        Console.Clear(); // This will clear the console
        SelectRandomWord(fileName);
        player.ShowRandomWord();
        do
        {
            Console.Clear(); // This will clear the console
            ShowTitle();
            ShowGallows();
            DisplayRandomWord();
            ShowLettersGuessesRight();
            Console.WriteLine($"The word has {player.randomWord.Length} letters.\n");
            ShowLettersGuessedWrong();
            ShowNumberOfGuesses();
            PromptPlayerForLetter();
            CheckPlayerGuess();
        } while (!player.GameOver());

        GameOver();
        PlayAgain();
    }

    private void SelectRandomWord(string fileName)
    {
        player.randomWord = randomWord.GetRandomWord(fileName);
    }

    private static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }


    /*
    private void PromptPlayerForLetter()
    {
        do
        {
            Console.Write("Guess a letter >> ");
            string input = Console.ReadLine();
            // Check if the input is valid
            if (!string.IsNullOrEmpty(input) && !ContainsNumber(input) && !string.Equals(input, Environment.NewLine))
            {
                char letterGuessed = input[0];
                player.lettersGuessed.Add(_letterGuessed);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a letter (A-Z) without using the Enter key or numbers.");
            }
        } while (true);
    }
    private bool ContainsNumber(string input)
    {
        return input.Any(char.IsDigit);
    }
    */

    private void PromptPlayerForLetter()
    {
        do
        {
            Console.Write("Guess a letter >>  ");
            string g = Console.ReadLine();
            _letterGuessed = g.Substring(0, 1);
        }
        while (player.CheckIfGuessed(player, _letterGuessed));

        player.lettersGuessed.Add(_letterGuessed);
    }

    private void CheckPlayerGuess()
    {
        player.CheckLatestGuess(_letterGuessed);
        player.ShowRandomWord();
    }

    private void PlayAgain()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"\nPress <ENTER> to continue.");
        Console.ResetColor();

        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            ClearCurrentConsoleLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Press <ENTER> to continue.");
            Console.ResetColor();
        }

        Console.Clear(); // This will clear the console
    }

    private void ShowNumberOfGuesses()
    {
        Console.WriteLine($"\nGuesses Left = {player.wrongGuessCount}/7\n");
    }

    private void ShowGallows()
    {
        gallowsRenderer.ShowGallows(player.wrongGuessCount);
    }

    private void ShowLettersGuessesRight()
    {
        Console.WriteLine($"\n{player.showRandomWord}\n");
    }

    private void ShowLettersGuessedWrong()
    {
        Console.WriteLine($"\n{player.wrongGuesses}\n");
    }

    private void ShowTitle()
    {
        Console.WriteLine($">>> Lets Play Hangman <<<\n");
    }

    private void ShowPlayerScore()
    {
        if (!player.PlayerLost())
        {
            simpleScore.DisplayScore(player.correctGuessCount, player.rightGuessList, player.randomWord);
            complexScore.DisplayScore(player.correctGuessCount, player.rightGuessList, player.randomWord);
        }
        else
        {
            simpleScore.DisplayScore(0, player.emptyList, player.randomWord);
            complexScore.DisplayScore(0, player.emptyList, player.randomWord);
        }
    }

    private void GameOver()
    {
        Console.Clear(); // This will clear the console
        if (player.GameOver() && player.PlayerWon())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(">>> Congratulations You Won! <<<");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(">>> Sorry, you lost! <<<");
            Console.ResetColor();
        }
        ShowGallows();
        ShowNumberOfGuesses();
        Console.WriteLine($"\nThe word was - {player.randomWord}\n");
        ShowPlayerScore();
    }
}