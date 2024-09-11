using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetStats.PlanetObjects;

namespace StarWarsPlanetStats.APIInteraction
{
    public class StarWarsAPIRepository : IAPIRepoInteraction
    {
        private List<StarWarsPlanet> Planets { get; init; }
        private readonly string stringRepresentationOfRepo = "";
        public bool RepositoryReady { get; init; }

        private const string BaseAddress = "https://swapi.dev";
        private const string RequestUri = "api/planets";
        private readonly Dictionary<string, Func<StarWarsPlanet, long?>> PossibleActions = [];

        public StarWarsAPIRepository(IApiDataReader reader)
        {
            var json = "";
            try
            {
                json = reader.Read(BaseAddress, RequestUri).Result;
            }
            catch (AggregateException)
            {
                json = new MockStarWarsApiDataReader().Read(BaseAddress, RequestUri).Result;
            }
            Planets = StarWarsPlanetConverter.Convert(json);
            RepositoryReady = true;
            static long? populationSelector(StarWarsPlanet planet) => planet.Population;
            static long? diameterSelector(StarWarsPlanet planet) => planet.Diameter;
            static long? surfaceWaterSelector(StarWarsPlanet planet) => planet.SurfaceWater;
            PossibleActions.Add("population", populationSelector);
            PossibleActions.Add("diameter", diameterSelector);
            PossibleActions.Add("surface water", surfaceWaterSelector);
        }

        public bool IsEmpty()
        {
            if (Planets.Count == 0) return true;
            return false;
        }

        public void SearchFor(string searchString)
        {
            string searchStringLower = searchString.ToLower();
            var action = PossibleActions.TryGetValue(searchStringLower, out Func<StarWarsPlanet, long?>? selectorFunction);
            if (action && selectorFunction != null)
            {
                var planetMaxValue = Planets.MaxBy(selectorFunction);
                var planetMinValue = Planets.MinBy(selectorFunction);
                ShowStatistics("max", planetMaxValue, searchString, selectorFunction);
                ShowStatistics("min", planetMinValue, searchString, selectorFunction);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid action");
                Console.ReadKey();
            }
        }

        public static void ShowStatistics(string descriptor, StarWarsPlanet selectedPlanet, string propertyName, Func<StarWarsPlanet,long?> propertySelector)
        {    
            string result = $"{descriptor} {propertyName} is {propertySelector(selectedPlanet)} (planet: {selectedPlanet.Name})";
            Console.WriteLine(result);
        }

        public string GetRepositoryAsString()
        {
            if (stringRepresentationOfRepo == "")
            {
                string result = "Name".PadRight(15) + "|" + "Diameter".PadRight(15) + "|" + "Surface Water".PadRight(15) + "|" + "Population".PadRight(15);
                result += "\n";
                for (var i = 0; i < 15 * 4 + 4; i++)
                {
                    result += "-";
                }
                result += "\n";
                foreach (var item in Planets)
                {
                    result += item.ToString() + "\n";
                }
                return result;
            }
            else
            {
                return stringRepresentationOfRepo;
            }


        }
    }
}
