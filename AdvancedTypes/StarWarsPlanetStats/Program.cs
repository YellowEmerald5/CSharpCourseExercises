using StarWarsPlanetStats;
using StarWarsPlanetStats.APIInteraction;
using StarWarsPlanetStats.UserInterface;

internal class Program
{
    private static void Main(string[] args)
    {
        var apiRepo = new StarWarsAPIRepository(new APIReader());
        while (!apiRepo.RepositoryReady)
        {

        }
        var application = new StarWarsPlanetStatsApplication(apiRepo, new ConsoleUI());
        application.Run();
    }
}