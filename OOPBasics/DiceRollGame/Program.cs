using DiceRollGame;
public class Program
{
    private const int AmountOfTries = 3;
    private static void Main(string[] args)
    {
        Dice dice = new Dice(6);
        UserInterface.InitialPrint(AmountOfTries);
        Console.WriteLine();
        int i = 0;
        string input;
        do
        {
            UserInterface.EnterNumber();
            input = Console.ReadLine();
            if (input == null || !input.All(char.IsDigit))
            {
                UserInterface.IncorrectInput();
                continue;
            } else {
                if (long.Parse(input) == dice.Roll)
                {
                    UserInterface.ResultOfGuess(true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    UserInterface.ResultOfGuess(false);
                }
            }
            i++;
        } while (i < AmountOfTries);
        
        UserInterface.LostGame();
        Console.ReadLine();
    }
} 