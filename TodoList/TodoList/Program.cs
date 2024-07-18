using System;
internal class Program
{
    private static List<string> todoList = new List<string>();
    private static void Main(string[] args)
    {
        PrintScreen();
        var keyInput = Console.ReadKey();
        while (!keyInput.KeyChar.Equals('E')) {
            if (keyInput.KeyChar == 'S')
            {
                PrintTODOs();
                BackLoop();
            }
            else if (keyInput.KeyChar == 'A')
            {
                AddTODO();
            }
            else if (keyInput.KeyChar == 'R') {
                RemoveTODO();
            }
            PrintScreen();
            keyInput = Console.ReadKey();
        }
    }

    private static void PrintScreen()
    {
        Console.Clear();
        Console.WriteLine("Hello!");
        Console.WriteLine();
        PrintTODOs();
        Console.WriteLine();
        Console.WriteLine("[S]ee all TODOs");
        Console.WriteLine("[A]dd TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit");
    }

    private static void PrintTODOs()
    {
        Console.Clear();
        for (var i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine("[" + (i+1) + "] " + todoList[i]);
        }
    }

    private static void BackLoop() {
        Console.WriteLine();
        Console.WriteLine("[B]ack");
        var keyInput = Console.ReadKey();
        while (keyInput.KeyChar != 'B')
        {
            keyInput = Console.ReadKey();
        }
    }

    private static void AddTODO()
    {
        Console.Clear();
        var entry = Console.ReadLine();
        todoList.Add(entry);
    }

    private static void RemoveTODO()
    {
        Console.Clear();
        PrintTODOs();
        var index = Console.ReadLine();
        if (index == null) return;
        var indexInt = int.Parse(index);
        todoList.RemoveAt(indexInt-1);
    }

}