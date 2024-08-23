using CookiesCookbookRefactored;
public class Program
{
    private static void Main(string[] args)
    {
        var i = new CookieRecipiebook(new ConsoleUI(new AvailableIngredients()));
        i.Run();
    }
}