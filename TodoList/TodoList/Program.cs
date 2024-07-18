using System;
internal class Program
{
    private static List<string> todoList = new List<string>();
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        PrintScreen();
        string keyInput;
        do
        {
            keyInput = Console.ReadLine();
        }
        while (keyInput == null || keyInput.Length > 1);

        while (!keyInput.ToUpper().Equals("E")) {
            switch (keyInput)
            {
                case "s":
                case "S":
                    Console.Clear();
                    PrintTODOs();
                    BackLoop();
                    break;
                case "a":
                case "A":
                    Console.Clear();
                    AddTODO();
                    break;
                case "r":
                case "R":
                    Console.Clear();
                    RemoveTODO();
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            PrintScreen();
            keyInput = Console.ReadLine();
        }
    }

    private static void PrintScreen()
    {
        PrintTODOs();
        Console.WriteLine();
        Console.WriteLine("[S]ee all TODOs");
        Console.WriteLine("[A]dd TODO");
        Console.WriteLine("[R]emove a TODO");
        Console.WriteLine("[E]xit");
    }

    private static void PrintTODOs()
    {
        for (var i = 0; i < todoList.Count; i++)
        {
            Console.WriteLine("[" + (i+1) + "] " + todoList[i]);
        }
    }

    private static void BackLoop() {
        Console.WriteLine();
        Console.WriteLine("[B]ack");
        var keyInput = Console.ReadLine();
        while (keyInput.ToUpper() !="B")
        {
            keyInput = Console.ReadLine();
        }
    }

    private static void AddTODO()
    {
        Console.WriteLine("Enter the todo description.");
        var entry = Console.ReadLine();
        if (entry == "")
        {
            Console.WriteLine("Description can not be empty");
            while (entry == "")
            {
                entry = Console.ReadLine();
                if (todoList.Contains(entry))
                {
                    Console.WriteLine("Entries must be unique");
                    continue;
                }
            }
        }
        
        todoList.Add(entry);
    }

    private static void RemoveTODO()
    {
        if(todoList.Count == 0) return;
        Console.Clear();
        Console.WriteLine("Select the index of the Todo you wish to remove");
        Console.WriteLine("Enter any letter to return");
        PrintTODOs();

        string index;
        int indexInt = -1;
        do
        {
            index = Console.ReadLine();
            if(int.TryParse(index,out indexInt))
            {
                if(indexInt > todoList.Count || indexInt < 1)
                {
                    Console.WriteLine("Invalid input.");
                    index = "";
                    continue;
                }
            }
            else
            {
                indexInt = -1;
            }
        } while (index == "");

        if (indexInt == -1) return;

        todoList.RemoveAt(indexInt - 1);
    }

}