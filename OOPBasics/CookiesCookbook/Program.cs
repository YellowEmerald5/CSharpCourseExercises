using CookiesCookbook;
using CookiesCookbook.Ingredients;
internal class Program
{
    private static void Main(string[] args)
    {
        var i = new CookieRecipiebook(new ConsoleUI(new AvailableIngredients()));
        i.Run();
        Console.ReadLine();
    }
}