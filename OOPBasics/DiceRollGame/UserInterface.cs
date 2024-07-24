using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame
{
    internal static class UserInterface
    {
        public static void InitialPrint(int amountOfTries) {
            Console.WriteLine($"Dice rolled. Guess what number it shows in {amountOfTries} tries.");
        }

        public static void EnterNumber()
        {
            Console.WriteLine("Enter a number:");
        }

        public static void IncorrectInput()
        {
            Console.WriteLine("Incorrect input");
        }

        public static void ResultOfGuess(bool correctness)
        {
            if (correctness) Console.WriteLine("You win!");
            else Console.WriteLine("Wrong number");
        }

        public static void LostGame()
        {
            Console.WriteLine("You lose :(");
        }
    }
}
