using System;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello!");
        Console.WriteLine("Input the first number:");
        var input1 = Console.ReadLine();
        Console.WriteLine("Input the second number:");
        var input2 = Console.ReadLine();
        var firstNumber = int.Parse(input1);
        var secondNumber = int.Parse(input2);
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("[A]dd numbers");
        Console.WriteLine("[S]ubtract numbers");
        Console.WriteLine("[M]ultiply numbers");
        var calculationType = Console.ReadKey();
        Console.WriteLine();
        if (Char.ToLower(calculationType.KeyChar) == 'a')
        {
            WriteResult(firstNumber, secondNumber, firstNumber + secondNumber, '+');
        }
        else if (Char.ToLower(calculationType.KeyChar) == 's')
        {
            WriteResult(firstNumber, secondNumber, firstNumber - secondNumber, '-');
        }
        else if (Char.ToLower(calculationType.KeyChar) == 'm')
        {
            WriteResult(firstNumber, secondNumber, firstNumber * secondNumber, '*');
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    static void WriteResult(int a,int b, int result,char type)
    {
        Console.WriteLine($"{a} {type} {b} = {result}");
    }
}