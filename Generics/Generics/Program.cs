using CustomCache;

internal class Program
{
    private static void Main(string[] args)
    {
        new CacheProgram(new ConsoleUI()).Run();
    }
}