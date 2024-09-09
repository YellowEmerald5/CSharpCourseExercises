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
        private string stringRepresentationOfRepo = "";
        public bool RepositoryReady { get; init; }

        private const string BaseAddress = "https://swapi.dev";
        private const string RequestUri = "api/planets";
        private Dictionary<string, Func<StarWarsPlanet, Tuple<long?, string>>> PossibleActions = new Dictionary<string, Func<StarWarsPlanet, Tuple<long?, string>>>();

        public StarWarsAPIRepository(IApiDataReader reader)
        {
            var json = "";
            try
            {
                json = reader.Read(BaseAddress, RequestUri).Result;
            }
            catch (AggregateException ex)
            {
                json = new MockStarWarsApiDataReader().Read(BaseAddress, RequestUri).Result;
            }
            Planets = StarWarsPlanetConverter.Convert(json);
            RepositoryReady = true;
            Func<StarWarsPlanet, Tuple<long?, string>> populationSelector = planet => new Tuple<long?, string>(planet.Population, planet.Name);
            Func<StarWarsPlanet, Tuple<long?, string>> diameterSelector = planet => new Tuple<long?, string>(planet.Diameter, planet.Name);
            Func<StarWarsPlanet, Tuple<long?, string>> surfaceWaterSelector = planet => new Tuple<long?, string>(planet.SurfaceWater, planet.Name);
            PossibleActions.Add("population", populationSelector);
            PossibleActions.Add("diameter", diameterSelector);
            PossibleActions.Add("surface water", surfaceWaterSelector);
        }

        public bool IsEmpty()
        {
            if (Planets.Count == 0) return true;
            return false;
        }

        public string SearchFor(string searchString)
        {
            long maxNumber = 0;
            long minNumber = 0;
            string maxPlanetName = string.Empty;
            string minPlanetName = string.Empty;
            bool firstCheck = true;
            string searchStringLower = searchString.ToLower();
            if (PossibleActions.ContainsKey(searchStringLower))
            {
                var function = PossibleActions[searchStringLower];
                foreach (var item in Planets)
                {
                    var values = function(item);
                    var number = values.Item1;
                    var name = values.Item2;
                    if (number != null)
                    {
                        if (firstCheck)
                        {
                            maxNumber = number.Value;
                            minNumber = number.Value;
                            maxPlanetName = name;
                            minPlanetName = name;
                            firstCheck = false;
                        }

                        if (number.Value > maxNumber)
                        {
                            maxNumber = number.Value;
                            maxPlanetName = name;
                        }
                        if (number.Value < minNumber)
                        {
                            minNumber = number.Value;
                            minPlanetName = name;
                        }
                    }
                }
            }
            else return "";

            string max = $"Max {searchString} is {maxNumber} (planet : {maxPlanetName})";
            string min = $"Min {searchString} is {minNumber} (planet : {minPlanetName})";
            return max + "\n" + min;
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
