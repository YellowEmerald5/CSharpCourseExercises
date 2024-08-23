using GameDataParserApp;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameDataParser = new GameDataParser(new ConsoleUI());
        gameDataParser.Run();
    }
}