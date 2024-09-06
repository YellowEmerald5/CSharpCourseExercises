using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarWarsPlanetStats
{
    public class StarWarsAPIRepository : IAPIRepoInteraction<StarWarsPlanet>
    { 
        private List<StarWarsPlanet> Planets {get;init;}

        private const string BaseAddress = "https://swapi.dev";
        private const string RequestUri = "api/planets";
        private Dictionary<string, Func<StarWarsPlanet, Tuple<int?,string>>> PossibleActions = new Dictionary<string, Func<StarWarsPlanet, Tuple<int?, string>>>();

        public StarWarsAPIRepository()
        {
            var json = APIReader.ReadFromAPI(BaseAddress, RequestUri).Result;
            Planets = StarWarsPlanetConverter.Convert(json);
            Func<StarWarsPlanet, Tuple<int?, string>> populationSelector = planet => new Tuple<int?,string>(planet.Population, planet.Name);
            Func<StarWarsPlanet, Tuple<int?, string>> diameterSelector = planet => new Tuple<int?, string>(planet.Diameter, planet.Name);
            Func<StarWarsPlanet, Tuple<int?, string>> surfaceWaterSelector = planet => new Tuple<int?, string>(planet.SurfaceWater,planet.Name);
            PossibleActions.Add("population", populationSelector);
            PossibleActions.Add("diameter", diameterSelector);
            PossibleActions.Add("surface water", surfaceWaterSelector);
        }

        public StarWarsPlanet? GetItem(string nameOfItem)
        {
            StarWarsPlanet? result = null;
            foreach(var planet in Planets)
            {
                if(planet.Name.Equals(nameOfItem)) result = planet;
            }
            return result;
        }

        public bool IsEmpty()
        {
            if (Planets.Count == 0) return true;
            return false;
        }

        public string SearchFor(string searchString)
        {
            int maxNumber = 0;
            int minNumber = 0;
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
                    if(number != null) {
                        if (firstCheck)
                        {
                            maxNumber = number.Value;
                            minNumber = number.Value;
                            maxPlanetName = name;
                            minPlanetName = name;
                        }

                        if (number > maxNumber)
                        {
                            maxNumber = number.Value;
                            maxPlanetName = name;
                        }
                        if (number < minNumber)
                        {
                            minNumber = number.Value;
                            minPlanetName = name;
                        }
                    }
                }
            } else return "";
            
            string max = $"Max {searchString} is {maxNumber} (planet : {maxPlanetName})";
            string min = $"Min {searchString} is {minNumber} (planet : {minPlanetName})";
            return max + "\n" + min;
        }
    }
}
