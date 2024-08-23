using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDataParserApp
{
    public class ConsoleUI : UserInteractionI
    {
        public void ErrorsInFileInteraction()
        {
            Console.WriteLine("The file does not exist or is not present in the folder.");
        }

        public void IncorrectFormat(JsonException jsonException)
        {
            Console.WriteLine("Errors are present in the following JSON body: " + jsonException.Message);
            Console.ReadLine();
        }

        public string InputLoop(string inputInformation)
        {
            Console.WriteLine(inputInformation + ". Please input a file name: ");
            var input = Console.ReadLine();
            while (input == null || input == "")
            {
                Console.WriteLine("The input cannot be empty. Please enter a new input: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public void PrintGameInfo(List<Game> games)
        {
            foreach (var game in games) {
                Console.WriteLine(game.ToString());
            }
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        public string UserInput()
        {
            Console.WriteLine("Please select the file you want to read from: ");
            var input = Console.ReadLine();
            while (input == null || input == "") {
                Console.WriteLine("The input cannot be empty. Please enter a new input: ");
                input = Console.ReadLine();
            }
            return input;
        }


    }
}
