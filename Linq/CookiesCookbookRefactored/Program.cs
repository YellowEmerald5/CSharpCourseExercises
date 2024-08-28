using CookiesCookbookRefactored;
using static System.Runtime.InteropServices.JavaScript.JSType;
public class Program
{
    private static void Main(string[] args)
    {
        var i = new CookieRecipiebook(new ConsoleUI(new AvailableIngredients()));
        i.Run();
    }

}