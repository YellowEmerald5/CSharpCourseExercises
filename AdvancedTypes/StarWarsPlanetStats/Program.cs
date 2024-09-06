using StarWarsPlanetStats;

var json = APIReader.ReadFromAPI("https://swapi.dev", "api/planets").Result;
Console.WriteLine(json);
Console.ReadKey();
