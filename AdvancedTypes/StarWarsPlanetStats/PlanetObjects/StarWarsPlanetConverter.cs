using System.Text.Json;

namespace StarWarsPlanetStats.PlanetObjects
{
    public static class StarWarsPlanetConverter
    {
        public static List<StarWarsPlanet> Convert(string jsonRepresentation)
        {
            var listOfRawPlanets = JsonSerializer.Deserialize<Root>(jsonRepresentation);
            List<StarWarsPlanet> planets = new();
            if (listOfRawPlanets == null) throw new Exception("Could not convert data from the API to a starwars planet raw data object");
            foreach (var planet in listOfRawPlanets.results)
            {
                planets.Add(ConvertRawPlanetData(planet));
            }
            return planets;
        }

        private static StarWarsPlanet ConvertRawPlanetData(Result planet)
        {
            string name = planet.name;
            long? population = 0;
            long? diameter = 0;
            long? surfaceWater = 0;
            if (planet.population == null || planet.population.Equals("unknown"))
            {
                population = null;
            }
            else
            {
                population = long.Parse(planet.population);
            }
            if (planet.diameter == null || planet.diameter.Equals("unknown"))
            {
                diameter = null;
            }
            else
            {
                diameter = long.Parse(planet.diameter);
            }
            if (planet.surface_water == null || planet.surface_water.Equals("unknown"))
            {
                surfaceWater = null;
            }
            else
            {
                surfaceWater = long.Parse(planet.surface_water);
            }
            StarWarsPlanet newPlanetData = new(name, diameter, surfaceWater, population);
            return newPlanetData;
        }
    }
}