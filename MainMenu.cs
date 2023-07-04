using System;

public class MainMenu : Menu
{
    // Attributes
    private string _menu = $@"
             Main Menu Options
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
Please select one of the following options:
1. Play Game
2. How to Play
3. Quit
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
Select an option from the menu:  ";

    private string _welcome = @"
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
>>>          Welcome to Hangman         <<<
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
>>>                                     <<<
>>>               +-----+               <<<
>>>               |     O               <<<
>>>               |    /|\              <<<
>>>               |    / \              <<<
>>>               |                     <<<
>>>             =====                   <<<
>>>                                     <<<
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<";

    private string _goodbye = @"
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
>>>    Thank you for playing Hangman!   <<<
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<
>>>                                     <<<
>>>               +-----+               <<<
>>>               |     O               <<<
>>>               |    /|\              <<<
>>>               |    / \              <<<
>>>               |                     <<<
>>>             =====                   <<<
>>>                                     <<<
>>>>>>>>>>>>>>>>>>>>>*<<<<<<<<<<<<<<<<<<<<<";

    // Constructors

    // Methods
    public override void DisplayMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(_menu);
    }

    public override void MenuChoice()
    {
        // Call GameMenu
        Menu gameMenu = new GameMenu();

        // Print welcome message
        PrintWelcome();

        while (_action != 3)
        // switch case for main menu
        {
            // Ask for user input (1-6)
            _action = UserChoice();
            Console.ResetColor();
            switch (_action)
            {
                case 1: // Play Game
                    Console.Clear();  // This will clear the console
                    gameMenu.MenuChoice();
                    break;
                
                case 2: // How to Play
                    HowToPlay info = new HowToPlay();
                    info.GetInstructions();
                    break;
                case 3: // Quite
                    PrintGoodbye();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nSorry the option you entered is not valid!");
                    Console.ResetColor();
                    Thread.Sleep(2000);
                    Console.Clear(); // This will clear the console
                    break;
            }
        }
    }

    private void PrintWelcome()
    {
        Console.Clear(); // This will clear the console
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{_welcome}\n");
        Console.ResetColor();
    }

    private void PrintGoodbye()
    {
        Console.Clear(); // This will clear the console
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{_goodbye}\n\n");
        Console.ResetColor();
    }
}
