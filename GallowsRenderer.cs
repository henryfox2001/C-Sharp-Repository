using System;

public class GallowsRenderer
{
    // Attributes
    // Constructors
    // Methods
    public void ShowGallows(int wrongGuessCount)
    {
        if (wrongGuessCount == 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine("===");
            Console.ResetColor();
        }
        else if (wrongGuessCount == 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |   O");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |    ");
            Console.WriteLine("===   ");
            Console.ResetColor();
        }
        else if (wrongGuessCount == 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |   O");
            Console.WriteLine(" |   |");
            Console.WriteLine(" |    ");
            Console.WriteLine("===   ");
            Console.ResetColor();
        }
        else if (wrongGuessCount == 4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |   O");
            Console.WriteLine(" |  /| ");
            Console.WriteLine(" |    ");
            Console.WriteLine("===   ");
            Console.ResetColor();
        }
        else if (wrongGuessCount == 5)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |   O");
            Console.WriteLine(" |  /|\\");
            Console.WriteLine(" |    ");
            Console.WriteLine("===   "); ;
            Console.ResetColor();
        }
        else if (wrongGuessCount == 6)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |   O");
            Console.WriteLine(" |  /|\\");
            Console.WriteLine(" |  / ");
            Console.WriteLine("===   ");
            Console.ResetColor();
        }
        else if (wrongGuessCount == 7)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n +---+");
            Console.WriteLine(" |   O");
            Console.WriteLine(" |  /|\\");
            Console.WriteLine(" |  / \\");
            Console.WriteLine("===   ");
            Console.ResetColor();
        }
    }
}